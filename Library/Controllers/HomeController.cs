using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Library.BLL.Servises;
using Library.BLL.Interfaces;
using System.Data.Entity;
using System.Configuration;

namespace Library.WEB.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        { 
        }

        public ActionResult Index()
        {
            return View();
        }

       

    }


}



