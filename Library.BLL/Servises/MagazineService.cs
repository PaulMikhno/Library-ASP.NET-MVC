using Library.DAL;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Servises
{
    public class MagazineService
    {
        private LibraryContext _libraryContext;
        private GenericRepository<Magazine> _brochureRepository;

        public MagazineService(string connectionString)
        {
            this._libraryContext = new LibraryContext(connectionString);
            this._brochureRepository = new GenericRepository<Magazine>(_libraryContext);
        }

        public IEnumerable<Magazine> Get()
        {
            return _brochureRepository.Get();
        }

        public Magazine Get(int id)
        {
            return _brochureRepository.Get(id);
        }

        public void Remove(int id)
        {
            _brochureRepository.Remove(id);
        }

        public void Update(Magazine book)
        {
            _brochureRepository.Update(book);
        }
        public void Create(Magazine book)
        {

            _brochureRepository.Create(book);

        }
    }
}
