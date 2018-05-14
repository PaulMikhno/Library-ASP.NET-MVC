using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities.Models;
using Library.Entities.Interfaces;

namespace Library.Entities.Interfaces
{
   public interface IBrochureRepository
   {
        IEnumerable<Brochure> GetBrochureList();
        Brochure GetBrochure(int id);
        void Create(Brochure item);
        void Update(Brochure item);
        void Delete(int id);
        void Save();
   }
}
