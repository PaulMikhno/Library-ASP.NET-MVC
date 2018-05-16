using Library.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities.Models;
using System.Data.Entity;
using ViewEntities.Models;
using AutoMapper;

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

        public IEnumerable<PublicHouseViewModel> Get()
        {
            IEnumerable<PublicHouse> pH = _publicHouseRepository.Get();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PublicHouse, PublicHouseViewModel>()).CreateMapper();
            var pHouses = mapper.Map<IEnumerable<PublicHouse>, List<PublicHouseViewModel>>(pH);

            return pHouses;

        }

        public PublicHouseViewModel Get(int id)
        {
            PublicHouse pH = _publicHouseRepository.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PublicHouse, PublicHouseViewModel>()).CreateMapper();
            var PHouse = mapper.Map<PublicHouse, PublicHouseViewModel>(pH);
            return PHouse;
        }

        public void Remove(int id)
        {
            _publicHouseRepository.Remove(id);
        }

        public void Update(PublicHouseViewModel book)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PublicHouseViewModel, PublicHouse>()).CreateMapper();
            var PHose = mapper.Map<PublicHouseViewModel, PublicHouse>(book);

            _publicHouseRepository.Update(PHose);
        }
        public void Create(PublicHouseViewModel book)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PublicHouseViewModel, PublicHouse>()).CreateMapper();
            var pHouse = mapper.Map<PublicHouseViewModel, PublicHouse>(book);
           
            _publicHouseRepository.Create(pHouse);

        }

    }
}
