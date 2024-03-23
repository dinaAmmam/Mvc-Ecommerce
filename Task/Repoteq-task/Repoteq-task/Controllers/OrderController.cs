using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repoteq_task.Models;
using Repoteq_task.Repository;

namespace Repoteq_task.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepo orderRepo;
        IProductRepo productRepo;
        public OrderController(IOrderRepo _orderRepo , IProductRepo _productRepo)
        {
            orderRepo = _orderRepo;  
            productRepo = _productRepo;
        }
        public IActionResult Index()
        {
            var model = orderRepo.GetAll();
            return View(model);
        }

        //public IActionResult Create()
        //{
        //    var products = productRepo.GetAll(); 
        //    ViewBag.products = new SelectList(products, "ProductId", "Name" , "Price");
        //    return View();

        //}
        public IActionResult Create()
        {
            var products = productRepo.GetAll();
            // Construct a SelectList containing both product name and price
            ViewBag.Products = new SelectList(products.Select(p => new { Value = p.ProductId, Text = $"{p.Name} - ${p.Price}" }), "Value", "Text");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order model)
        {
            if (ModelState.IsValid)
            {
                orderRepo.Add(model);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
    }
}
