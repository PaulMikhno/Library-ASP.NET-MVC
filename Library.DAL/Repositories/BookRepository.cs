using Library.Entities.Interfaces;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class BookRepository :GenericRepository<Book>
    {
        private LibraryContext db;

        public BookRepository(LibraryContext dbContext)
            :base(dbContext)
        {
            
            this.db = dbContext;

        }

        public override void Update(Book item)
        {

            var books= db.Books.Include(x => x.PublicHouses).ToList();
        
            var book = books.Find(x => x.Id == item.Id);

            var publicHouses = db.PublicHouses.Where(x=>item.PublicHouses.Select(y=>y.Id).ToList().Contains(x.Id)).ToList();

            book.PublicHouses.Clear();
            book.Name = item.Name;
            book.Author = item.Author;
            book.YearOfPublishing = item.YearOfPublishing;

            foreach (var publicHouse in item.PublicHouses)
            {
                book.PublicHouses.Add(publicHouses.Find(x => x.Id == publicHouse.Id));
            }

            db.Entry(book).State = EntityState.Modified;

            db.SaveChanges();

        }

        public override IEnumerable<Book> Get()
        {
            return db.Books.Include(x => x.PublicHouses).ToList();
        }
    }
}
