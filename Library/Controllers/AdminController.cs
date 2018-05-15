using Library.BLL.Servises;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        BookServise _bookServise;
        PublicationHouseService _publicationHouseSevice;
        BrochureService _brochureService;
        MagazineService _magazineService;

        public AdminController()
        {
            _bookServise = new BookServise(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            _publicationHouseSevice = new PublicationHouseService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            _brochureService = new BrochureService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            _magazineService = new MagazineService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
        }


        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Getbooks(string text)
        {
            var books = _bookServise.Get();
            return this.Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}