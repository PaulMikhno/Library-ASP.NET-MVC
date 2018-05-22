using System;
using System.Collections.Generic;
using System.Text;
using Library.DAL;
using Library.Entities.Models;
using System.Data.Entity;
using ViewEntities.Models;
using AutoMapper;
using Library.DAL.Repositories;

namespace Library.BLL.Servises
{
    public class BookServise
    {
        private LibraryContext _libraryContext;
        private BookRepository _bookRepository;
        private GenericRepository<PublicHouse> _publicHouseRepository;

        public BookServise(string connectionString)
        {
            this._libraryContext =new LibraryContext(connectionString);
            this._bookRepository = new BookRepository(_libraryContext);
            this._publicHouseRepository= new GenericRepository<PublicHouse>(_libraryContext);
            _libraryContext.Configuration.ProxyCreationEnabled = false;

        }

       public IEnumerable<BookViewModel> Get()
       {
            IEnumerable<Book> books = _bookRepository.Get();
            
            var bookRes = Mapper.Map<IEnumerable<Book>, List<BookViewModel>>(books);
            return bookRes;
       }

       public BookViewModel Get(int id)
       {
            Book book = _bookRepository.Get(id);
           
            var bookRes = Mapper.Map<Book, BookViewModel>(book);
            return bookRes;
        }

       public void Remove(int id)
       {

            _bookRepository.Remove(id);
       }

       public void Update(BookViewModel book)
       {
            var bookUpdate = Mapper.Map<BookViewModel, Book>(book);

            _bookRepository.Update(bookUpdate);
       }
       public void Create(BookViewModel book)
       {
            
            var bookUpdate = Mapper.Map<BookViewModel, Book>(book);

            _bookRepository.Create(bookUpdate);

       }

        public IEnumerable<PublicHouseViewModel> GetPublicHouses()
        {
            IEnumerable<PublicHouse> publicHousesDB = _publicHouseRepository.Get();
          
            var publicHouses = Mapper.Map<IEnumerable<PublicHouse>, List<PublicHouseViewModel>>(publicHousesDB);

            return publicHouses;
        }
    }

}

