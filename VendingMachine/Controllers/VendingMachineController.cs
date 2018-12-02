using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VendingMachine.Controllers
{
    public class VendingMachineController : Controller
    {
        // GET: VendingMachine
        public ActionResult Index()
        {
            return View();
        }

    }
}