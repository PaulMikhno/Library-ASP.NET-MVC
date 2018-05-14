using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities.Models;
using Library.Entities.Interfaces;


namespace Library.Entities.Interfaces
{
   public interface IBookRepository
   {
        IEnumerable<Book> GetBookList();
        Book GetBook(int id);
        void Create(Book item);
        void Update(Book item);
        void Delete(int id);
        void Save();
   }
}
