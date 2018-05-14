using Library.DAL;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Servises
{
    public class BrochureService
    {
        private LibraryContext _libraryContext;

        private GenericRepository<Brochure> _brochureRepository;

        public BrochureService(string connectionString)
        {
            this._libraryContext = new LibraryContext(connectionString);
            this._brochureRepository = new GenericRepository<Brochure>(_libraryContext);
        }

        public IEnumerable<Brochure> Get()
        {
            return _brochureRepository.Get();
        }

        public Brochure Get(int id)
        {
            return _brochureRepository.Get(id);
        }

        public void Remove(int id)
        {
            _brochureRepository.Remove(id);
        }

        public void Update(Brochure book)
        {
            _brochureRepository.Update(book);
        }
        public void Create(Brochure book)
        {

            _brochureRepository.Create(book);

        }
    }
}
