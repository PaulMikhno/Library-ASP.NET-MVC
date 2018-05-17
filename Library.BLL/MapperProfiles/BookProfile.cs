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
   public class BookProfile:Profile 
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();
        }

    }
}
