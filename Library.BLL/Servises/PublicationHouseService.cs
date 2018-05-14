using Library.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities.Models;
using System.Data.Entity;

namespace Library.BLL.Servises
{
    public class PublicationHouseService
    {
        private DbContext _libraryContext;
        private GenericRepository<PublicHouse> _publicHouseRepository;

        public PublicationHouseService(string connectionString)
        {
            _libraryContext = new LibraryContext(connectionString);
            _publicHouseRepository = new GenericRepository<PublicHouse>(_libraryContext);
        }

        public IEnumerable<PublicHouse> Get()
        {
            return _publicHouseRepository.Get();
        }

        public PublicHouse Get(int id)
        {
            return _publicHouseRepository.Get(id);
        }

        public void Remove(int id)
        {
            _publicHouseRepository.Remove(id);
        }

        public void Update(PublicHouse book)
        {
            _publicHouseRepository.Update(book);
        }
        public void Create(PublicHouse book)
        {
            _publicHouseRepository.Create(book);

        }

    }
}
