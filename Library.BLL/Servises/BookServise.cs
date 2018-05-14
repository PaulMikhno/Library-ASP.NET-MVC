using System;
using System.Collections.Generic;
using System.Text;
using Library.DAL;
using Library.Entities.Models;
using System.Data.Entity;

namespace Library.BLL.Servises
{
    public class BookServise
    {
        private DbContext _libraryContext;
        private GenericRepository<Book> _bookRepository;
        private GenericRepository<PublicHouse> _publicHouseRepository;

        public BookServise(string connectionString)
        {
            this._libraryContext =new LibraryContext(connectionString);
            this._bookRepository = new GenericRepository<Book>(_libraryContext);
            this._publicHouseRepository= new GenericRepository<PublicHouse>(_libraryContext);
            _libraryContext.Configuration.ProxyCreationEnabled = false;

        }

       public IEnumerable<Book> Get()
       {
           
            return _bookRepository.Get();
       }

       public Book Get(int id)
       {
            return _bookRepository.Get(id);
       }

       public void Remove(int id)
       {
            _bookRepository.Remove(id);
       }

       public void Update(Book book)
       {
            _bookRepository.Update(book);
       }
       public void Create(Book book)
       {

        _bookRepository.Create(book);

       }

        public IEnumerable<PublicHouse> GetPublicHouses()
        {
            return _publicHouseRepository.Get();
        }
    }

}

