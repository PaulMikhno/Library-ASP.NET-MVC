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
using Library.DAL;
using System.Data.Entity;
using System.Configuration;

namespace Library.WEB.Controllers
{
    public class HomeController : Controller
    {
        
        LibraryContext libraryContext = new LibraryContext();
        MagazineService magazineService;
        BrochureService brochureService;
        BookServise bookServise;

        public HomeController()
        {
            this.bookServise = new BookServise(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            this.magazineService=new MagazineService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            this.brochureService=new BrochureService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
    }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllPublications()
        {

            ViewData["Books"] = bookServise.Get();
            ViewData["Magazines"] = magazineService.Get();
            ViewData["Brochures"] = brochureService.Get();
            return View();
        }

    }


}



