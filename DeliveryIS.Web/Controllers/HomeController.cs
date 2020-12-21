using DeliveryIS.Web.Models;
using DomainLayer.Processors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace DeliveryIS.Web.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        public ActionResult Create(string type, int customerID, int sellerStorageID, int receiveStorageID,
                                     double pricePerG, string productIds)
        {

            ShipmentProcessor.CreateAndUpdateShipment(type, customerID, sellerStorageID, receiveStorageID,
                                              pricePerG, productIds);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult GetMessage()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
