using Ecommerce_App.Models;
using Ecommerce_App.Repositories;
using Ecommerce_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IEcommerceRepository<Product> _productRepository;
        private readonly IEcommerceRepository<Category> _categoryRepository;

        private IWebHostEnvironment Hosting { get; set; }

        public ProductController(IEcommerceRepository<Product> productRepository,
            IEcommerceRepository<Category> categoryRepository,
            IWebHostEnvironment hosting)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            Hosting = hosting;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var products = _productRepository.List();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var products = _productRepository.FindById(id);
            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var model = new ProductCategoryViewModel
            {
                Categories = DefaultSelection()
            };
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategoryViewModel model)
        {
            try
            {
                string fileName = UploadFile(model.File) ?? string.Empty;

                var category = _categoryRepository.FindById(model.CategoryId);
                Product product = new Product
                {
                    Id = model.ProductId,
                    Name = model.ProductName,
                    Description = model.ProductDescription,
                    Price = model.ProductPrice,
                    Categories = category,
                    ImageUrl = fileName
                };

                _productRepository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var products = _productRepository.FindById(id);
            var categoryId = products.Categories == null ? products.Categories.Id = 0 : products.Categories.Id;

            var ViewModel = new ProductCategoryViewModel
            {
                ProductId = products.Id,
                ProductName = products.Name,
                ProductDescription = products.Description,
                ProductPrice = products.Price,
                CategoryId = categoryId,
                Categories = _categoryRepository.List().ToList(),
                ImageUrl = products.ImageUrl
            };

            return View(ViewModel);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategoryViewModel ViewModel)
        {
            try
            {
                string fileName = UploadFile(ViewModel.File, ViewModel.ImageUrl);
                var category = _categoryRepository.FindById(ViewModel.CategoryId);

                Product product = new Product
                {
                    Id = ViewModel.ProductId,
                    Name = ViewModel.ProductName,
                    Description = ViewModel.ProductDescription,
                    Price = ViewModel.ProductPrice,
                    Categories = category,
                    ImageUrl = fileName
                };

                _productRepository.Update(ViewModel.ProductId, product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productRepository.FindById(id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                _productRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<Category> DefaultSelection()
        {
            var categories = _categoryRepository.List().ToList();
            categories.Insert(0, new Category { Id = -1, Name = " - Please Select a Category - " });
            return categories;
        }

        public string UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string uploads = Path.Combine(Hosting.WebRootPath, "uploads");
                string fullPath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(fullPath, FileMode.Create));

                return file.FileName;
            }

            return null;
        }

        public string UploadFile(IFormFile file, string imageUrl)
        {
            if (file != null)
            {
                string uploads = Path.Combine(Hosting.WebRootPath, "uploads");
                string newPath = Path.Combine(uploads, file.FileName);
                string OldPath = Path.Combine(uploads, imageUrl);

                if (OldPath != newPath)
                {
                    System.IO.File.Delete(OldPath);
                    file.CopyTo(new FileStream(newPath, FileMode.Create));
                }

                return file.FileName;
            }
            return imageUrl;
        }
    }
}
