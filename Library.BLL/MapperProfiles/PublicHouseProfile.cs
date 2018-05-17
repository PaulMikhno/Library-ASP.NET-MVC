using AutoMapper;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntities.Models;

namespace Library.BLL.MapperProfiles
{
    public class PublicHouseProfile : Profile
    {
        public PublicHouseProfile()
        {
            CreateMap<PublicHouse, PublicHouseViewModel>();
            CreateMap<PublicHouseViewModel, PublicHouse>();
        }

    }
}

