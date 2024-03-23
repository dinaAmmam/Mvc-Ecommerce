using Microsoft.AspNetCore.Mvc;
using Repoteq_task.Models;
using Repoteq_task.Repository;
using System.Diagnostics;

namespace Repoteq_task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepo _productRepo;
        private readonly IOrderRepo _orderRepo;

        public HomeController(ILogger<HomeController> logger, IProductRepo productRepo, IOrderRepo orderRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
            _orderRepo = orderRepo;
        }

        public IActionResult Index()
        {
            int productCount = _productRepo.GetAll().Count;
            int orderCount = _orderRepo.GetAll().Count;

            ViewData["ProductCount"] = productCount;
            ViewData["OrderCount"] = orderCount;

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
