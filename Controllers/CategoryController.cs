using Ecommerce_App.Models;
using Ecommerce_App.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IEcommerceRepository<Category> _categoryRepository;

        private IWebHostEnvironment Hosting { get; set; }
        public CategoryController(IEcommerceRepository<Category> categoryRepository,
            IWebHostEnvironment hosting)
        {
            _categoryRepository = categoryRepository;
            Hosting = hosting;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var categoeies = _categoryRepository.List();
            return View(categoeies);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var categories = _categoryRepository.FindById(id);
            return View(categories);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                _categoryRepository.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryRepository.FindById(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                _categoryRepository.Update(id, category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categoryRepository.FindById(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                _categoryRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
