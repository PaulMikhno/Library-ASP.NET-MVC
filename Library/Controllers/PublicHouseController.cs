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
    public class PublicHouseController : Controller
    {
        PublicationHouseService publicHouseService;
      
       

        public PublicHouseController()
        {
            publicHouseService = new PublicationHouseService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            
        }

        public ActionResult PublicHouses()
        {

            return View(publicHouseService.Get());
        }

        [HttpPost]
        public ActionResult AddPublicHouse(PublicHouse pubHouse)
        {
            if (pubHouse.Name == null)
            {
                throw new ArgumentNullException(nameof(pubHouse));
            }

            publicHouseService.Create(pubHouse);
          
            return Json(pubHouse);

        }
       
      
        public ActionResult Delete(int id)
        {
            PublicHouse b = publicHouseService.Get(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            publicHouseService.Remove(id);

            return RedirectToAction("PublicHouses");
        }
    
        [HttpPost]
        public ActionResult EditPublicHouse(PublicHouse publicHouse)
        {
            if (publicHouse.Name == null)
            {
                return HttpNotFound();
            }
            publicHouseService.Update(publicHouse);
            return Json(publicHouse);
        }

        public JsonResult GetPublicationHouses(string text)
        {
            var  publicHouses = publicHouseService.Get();
            return this.Json(
           (from obj in publicHouses select new { Id = obj.Id, Name = obj.Name, Address=obj.Address })
           , JsonRequestBehavior.AllowGet
           );
        }

    }
}
