using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Library.Entities.Interfaces;
using Library.Entities.Models;
using Library.BLL.Servises;
using Library.BLL.Interfaces;
using System.Configuration;

namespace Library.WEB.Controllers
{
    public class BookController : Controller
    {
        BookServise _bookServise;

        PublicationHouseService _publicationHouseSevice;
    
        public BookController()
        {
            _bookServise = new BookServise(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            _publicationHouseSevice = new PublicationHouseService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
           
        }
        
        public ActionResult Books()
        {
            return View(_bookServise.Get());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddBook()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book book, int[] selectedPablicHouses)
        {

            List<PublicHouse> publicHouses = new List<PublicHouse>();

            if (book == null)
            {
                return HttpNotFound();
            }

            if (selectedPablicHouses != null)
            {


                publicHouses.AddRange(_bookServise.GetPublicHouses().Where(x => selectedPablicHouses.Contains(x.Id)).ToList());


                book.PublicHouses.AddRange(publicHouses);
            }

            _bookServise.Create(book);

            return RedirectToAction("Books");

        }

        public ActionResult Delete(int id)
        {
            Book b = _bookServise.Get(id);
            if (b == null)
            {
                return HttpNotFound("Delete failed");
            }
            _bookServise.Remove(id);
            return RedirectToAction("Books");
        }

        [HttpPost]
        public ActionResult EditBook(Book book, List<int> selectedPablicHouses)
        {
            List<PublicHouse> publicHouses = new List<PublicHouse>();

            if (book.Name == null)
            {
                return HttpNotFound();
            }

            if (selectedPablicHouses != null)
            {
                Book bookToUpdate = _bookServise.Get(book.Id);

                bookToUpdate.PublicHouses.Clear();

                var publicHousesToUpdate = _bookServise.GetPublicHouses().Where(x => selectedPablicHouses.Contains(x.Id)).ToList();

                bookToUpdate.PublicHouses.AddRange(publicHousesToUpdate);

                return Json(book);
            }
            _bookServise.Update(book);
            return Json(book);
        }

       
        public JsonResult Getbooks(string text)
        {
            var books = _bookServise.Get();
            return this.Json(books, JsonRequestBehavior.AllowGet);

           // return this.Json(
           //(from obj in books select new { Id = obj.Id, Name = obj.Name, Author = obj.Author, YearOfPublishing = obj.YearOfPublishing })
           //, JsonRequestBehavior.AllowGet
           //);

        }
        public JsonResult GetPublicationHouses(string text)
        {
            var books = _bookServise.Get();
            return this.Json(
           (from obj in books select new { obj.Id, obj.Name, obj.Author, obj.YearOfPublishing })
           , JsonRequestBehavior.AllowGet
           );
        }
      

    }
}
