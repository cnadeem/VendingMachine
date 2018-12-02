using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingMachine.Helper;
namespace VendingMachine.Controllers
{
    public class VendingMachineController : Controller
    {
        // GET: VendingMachine
        public ActionResult Index()
        {
            VendingMachineHelper.InitializeVendingMachine();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string btnSubmit,string productID,string amount,string paymentMethod)
        {
            switch(btnSubmit)
            {
                case "Initialize":
                    ViewBag.Result = VendingMachineHelper.GetVendingMachineDetails();
                    break;

                case "SaleRecords":
                    ViewBag.Result = VendingMachineHelper.GetSaleRecords();
                    break;

                case "PaymentRecords":
                    ViewBag.Result = VendingMachineHelper.GetPaymentRecords();
                    break;

                case "VendingMachineDetails":
                    ViewBag.Result = VendingMachineHelper.GetVendingMachineDetails();
                    break;

                case "Refill":
                    ViewBag.Result = VendingMachineHelper.RefillVendingMachine();
                    break;
                case "ViewProducts":
                    ViewBag.Result = VendingMachineHelper.GetProductsList();
                    break;
                case "PurchaseProduct":
                    ViewBag.Result = VendingMachineHelper.PurchaseProduct(productID,amount,paymentMethod);
                    break;
            }
           
            return View();
        }
    }
}