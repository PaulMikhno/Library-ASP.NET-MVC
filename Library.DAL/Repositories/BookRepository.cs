using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class BookRepository 
    {
        private LibraryContext db;
        private bool disposed = false;

        public BookRepository(LibraryContext dbContext)
        {
            this.db = dbContext;
        }

        public void Create(Book item)
        {
            db.Books.Add(item);
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            Book product = db.Books.Find(id);
            if (product != null)
            {
                db.Books.Remove(product);
                db.SaveChanges();

            }

        }
        
        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Book> Get()
        {
           return db.Books.Include(x => x.PublicHouses).AsNoTracking().ToList();
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }


    }
}
