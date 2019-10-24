using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Library.BLL.Servises;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.BLL.MapperProfiles;

namespace Test.Library
{
    [TestClass]
    public class BookTest
    {
        private const string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        [TestInitialize]
        public void Initialize()
        {
            try
            {
                AutoMapper.Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile(new BookProfile());
                    cfg.AddProfile(new MagazineProfile());
                    cfg.AddProfile(new BrochureProfile());
                    cfg.AddProfile(new PublicHouseProfile());
                });
            }
            catch (Exception)
            {

            }
        }

        [TestMethod]
        public void Create_Test()
        {
            var bookService = new BookServise(_connectionString);

            bookService.Create(new ViewEntities.Models.BookViewModel { Name = "-Test Create Book-", Author = "Test Author", YearOfPublishing = "1997" });

            var allBooks = bookService.Get().ToList();

            var result = allBooks.FirstOrDefault(x => x.Name == "-Test Create Book-");

            Assert.IsTrue(result != null);

            bookService.Remove(result.Id);
        }

        [TestMethod]
        public void Delete_Test()
        {
            var bookService = new BookServise(_connectionString);

            bookService.Create(new ViewEntities.Models.BookViewModel { Name = "-Test Delete Book-", Author = "Test Author", YearOfPublishing = "1997" });

            var allBooks = bookService.Get().ToList();

            var bookToDelete = allBooks.FirstOrDefault(x => x.Name == "-Test Delete Book-");

            if (bookToDelete != null)
            {
                bookService.Remove(bookToDelete.Id);

                var result = bookService.Get(bookToDelete.Id);

                Assert.IsTrue(result == null);
            }
        }
    }
}
