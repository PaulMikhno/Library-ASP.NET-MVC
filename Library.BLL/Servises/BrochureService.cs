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
            IEnumerable<Brochure> brochur = _brochureRepository.Get();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Brochure, BrochureViewModel>()).CreateMapper();
            var brochures = mapper.Map<IEnumerable<Brochure>, List<BrochureViewModel>>(brochur);

            return brochures;
        }

        public BrochureViewModel Get(int id)
        {
            Brochure brochur = _brochureRepository.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Brochure, BrochureViewModel>()).CreateMapper();
            var brochure = mapper.Map<Brochure, BrochureViewModel>(brochur);
            return brochure;
        }

        public void Remove(int id)
        {
            _brochureRepository.Remove(id);
        }

        public void Update(BrochureViewModel book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrochureViewModel, Brochure>()).CreateMapper();
            var brochur = mapper.Map<BrochureViewModel, Brochure>(book);
            _brochureRepository.Update(brochur);
        }
        public void Create(BrochureViewModel book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrochureViewModel, Brochure>()).CreateMapper();
            var brochur = mapper.Map<BrochureViewModel, Brochure>(book);

            _brochureRepository.Create(brochur);

        }
    }
}
