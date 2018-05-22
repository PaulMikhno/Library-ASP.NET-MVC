using AutoMapper;
using Library.DAL;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewEntities.Models;

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

        public IEnumerable<BrochureViewModel> Get()
        {
            IEnumerable<Brochure> brochureFromDB = _brochureRepository.Get();
            
            var brochures = Mapper.Map<IEnumerable<Brochure>, List<BrochureViewModel>>(brochureFromDB);

            return brochures;
        }

        public BrochureViewModel Get(int id)
        {
            Brochure brochureFromDB = _brochureRepository.Get(id);
          
            var brochure = Mapper.Map<Brochure, BrochureViewModel>(brochureFromDB);
            return brochure;
        }

        public void Remove(int id)
        {
            _brochureRepository.Remove(id);
        }

        public void Update(BrochureViewModel brochureView)
        {
            var brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureView);
            _brochureRepository.Update(brochure);
        }
        public void Create(BrochureViewModel brochureView)
        {
            var brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureView);

            _brochureRepository.Create(brochure);

        }
    }
}
