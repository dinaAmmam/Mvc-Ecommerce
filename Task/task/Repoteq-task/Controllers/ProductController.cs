using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repoteq_task.Models;
using Repoteq_task.Repository;

namespace Repoteq_task.Controllers
{
    public class ProductController : Controller
    {
        IProductRepo productRepo;
        public ProductController(IProductRepo _productRepo)
        {
            productRepo = _productRepo;
        }
        public IActionResult Index()
        {
            var model = productRepo.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                productRepo.Add(model);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = productRepo.GetById(id.Value);

            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Product prod, int id)
        {
            prod.ProductId = id;
            productRepo.Update(prod);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            productRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
