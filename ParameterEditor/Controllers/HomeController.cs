using ParameterEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using ParameterEditor.Pagination;
using PagedList;

namespace ParameterEditor.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.message = "Please select a parameter in the drop-down menu above \n or click the links provided in the header and the footer!";

            return View();

        
        }
    }
}
