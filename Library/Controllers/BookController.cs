﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Library.BLL.Servises;
using Library.BLL.Interfaces;
using System.Configuration;
using ViewEntities.Models;

namespace Library.WEB.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        BookServise _bookServise;

        PublicationHouseService _publicationHouseSevice;
    
        public BookController()
        {
            _bookServise = new BookServise(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            _publicationHouseSevice = new PublicationHouseService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
           
        }
        [Authorize]
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddBook(BookViewModel book, int[] selectedPablicHouses)
        {

            List<PublicHouseViewModel> publicHouses = new List<PublicHouseViewModel>();

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

            return Json(book);

        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            BookViewModel b = _bookServise.Get(id);
            if (b == null)
            {
                return HttpNotFound("Delete failed");
            }
            _bookServise.Remove(id);
            return RedirectToAction("Books");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditBook(BookViewModel book, List<int> selectedPablicHouses)
        {
            List<PublicHouseViewModel> publicHouses = new List<PublicHouseViewModel>();

            if (book.Name == null)
            {
                return HttpNotFound();
            }

            if (selectedPablicHouses != null)
            {
                BookViewModel bookToUpdate = _bookServise.Get(book.Id);

                bookToUpdate.PublicHouses.Clear();

                //var publicHousesToUpdate = _bookServise.GetPublicHouses().Where(x => selectedPablicHouses.Contains(x.Id)).ToList();

                //bookToUpdate.PublicHouses.AddRange(publicHousesToUpdate);

                return Json(book);
            }
            _bookServise.Update(book);
            return Json(book);
        }

        
        public JsonResult Getbooks(string text)
        {
            var books = _bookServise.Get();

            //var publicHousesToAdd = _bookServise.GetPublicHouses();

            // books.ElementAt(0).PublicHouses.Add(publicHousesToAdd.ElementAt(0));

            foreach(var book in books)
            {
                foreach(var ph in book.PublicHouses)
                {
                    ph.Books = null;
                }
                
            }

            // return this.Json(
            //(from obj in books select new { Id = obj.Id, Name = obj.Name, Author = obj.Author, YearOfPublishing = obj.YearOfPublishing })
            //, JsonRequestBehavior.AllowGet
            //);
            return Json(books, JsonRequestBehavior.AllowGet);

        }

    }
}
