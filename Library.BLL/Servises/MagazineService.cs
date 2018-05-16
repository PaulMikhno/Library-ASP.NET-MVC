using AutoMapper;
using Library.DAL;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewEntities.Models;

namespace Library.BLL.Servises
{
    public class MagazineService
    {
        private LibraryContext _libraryContext;
        private GenericRepository<Magazine> _magazineRepository;

        public MagazineService(string connectionString)
        {
            this._libraryContext = new LibraryContext(connectionString);
            this._magazineRepository = new GenericRepository<Magazine>(_libraryContext);
        }

        public IEnumerable<MagazineViewModel> Get()
        {
            IEnumerable<Magazine> magaz = _magazineRepository.Get();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Magazine, MagazineViewModel>()).CreateMapper();
            var magazines = mapper.Map<IEnumerable<Magazine>, List<MagazineViewModel>>(magaz);

            return magazines;
        }

        public MagazineViewModel Get(int id)
        {
            Magazine magaz = _magazineRepository.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Magazine, MagazineViewModel>()).CreateMapper();
            var magazine = mapper.Map<Magazine, MagazineViewModel>(magaz);
            return magazine;
        }

        public void Remove(int id)
        {
            _magazineRepository.Remove(id);
        }

        public void Update(MagazineViewModel book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MagazineViewModel, Magazine>()).CreateMapper();
            var magazine = mapper.Map<MagazineViewModel, Magazine>(book);
            _magazineRepository.Update(magazine);
        }
        public void Create(MagazineViewModel book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MagazineViewModel, Magazine>()).CreateMapper();
            var magazine = mapper.Map<MagazineViewModel, Magazine>(book);
            _magazineRepository.Create(magazine);

        }
    }
}
