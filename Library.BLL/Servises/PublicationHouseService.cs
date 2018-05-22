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
            IEnumerable<PublicHouse> publicHouseDB = _publicHouseRepository.Get();
            var publicHouses = Mapper.Map<IEnumerable<PublicHouse>, List<PublicHouseViewModel>>(publicHouseDB);

            return publicHouses;

        }

        public PublicHouseViewModel Get(int id)
        {
            PublicHouse publicHouseDB = _publicHouseRepository.Get(id);
           
            var publicHouse = Mapper.Map<PublicHouse, PublicHouseViewModel>(publicHouseDB);
            return publicHouse;
        }

        public void Remove(int id)
        {
            _publicHouseRepository.Remove(id);
        }

        public void Update(PublicHouseViewModel publicHouseView)
        {

            var publicHouse = Mapper.Map<PublicHouseViewModel, PublicHouse>(publicHouseView);

            _publicHouseRepository.Update(publicHouse);
        }
        public void Create(PublicHouseViewModel publicHousesView)
        {

            var publicHouses = Mapper.Map<PublicHouseViewModel, PublicHouse>(publicHousesView);
           
            _publicHouseRepository.Create(publicHouses);

        }

    }
}
