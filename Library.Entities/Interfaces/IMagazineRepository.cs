using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities.Models;
using Library.Entities.Interfaces;

namespace Library.Entities.Interfaces
{
    public interface IMagazineRepository
    {
        IEnumerable<Magazine> GetMagazineList();
        Magazine GetMagazine(int id);
        void Create(Magazine item);
        void Update(Magazine item);
        void Delete(int id);
        void Save();
    }
    
}
