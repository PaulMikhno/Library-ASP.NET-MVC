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
        public override void Create(Book item)
        {
            var book = new Book
            {
                Name = item.Name,
                Author = item.Author,
                YearOfPublishing = item.YearOfPublishing
            };

            var publicHousesIndexes = item.PublicHouses.Where(x => x != null).Select(y => y.Id).ToList();
            if (publicHousesIndexes != null && publicHousesIndexes.Count != 0)
            {
                var publicHouses = db.PublicHouses.Where(x => publicHousesIndexes.Contains(x.Id)).ToList();
                book.PublicHouses.AddRange(publicHouses);
            }
            db.Books.Add(book);
            db.SaveChanges();
        }
        public override void Update(Book item)
        {

            var books= db.Books.Include(x => x.PublicHouses).ToList();
        
            var book = books.Find(x => x.Id == item.Id);

            var publicHousesIndexes = item.PublicHouses.Select(y => y.Id).ToList();

            var publicHouses = db.PublicHouses.Where(x=>publicHousesIndexes.Contains(x.Id)).ToList();
           

            book.PublicHouses.Clear();
            book.Name = item.Name;
            book.Author = item.Author;
            book.YearOfPublishing = item.YearOfPublishing;

            book.PublicHouses.AddRange(publicHouses);
            
            db.Entry(book).State = EntityState.Modified;

            db.SaveChanges();

        }

        public override IEnumerable<Book> Get()
        {
            return db.Books.Include(x => x.PublicHouses).ToList();
        }
    }
}
