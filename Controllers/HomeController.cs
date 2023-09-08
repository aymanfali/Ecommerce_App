using Ecommerce_App.Models;
using Ecommerce_App.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecommerce_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEcommerceRepository<Product> _productsRepository;

        public HomeController(IEcommerceRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var products = _productsRepository.List();
            return View(products);
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}