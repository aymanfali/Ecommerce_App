using Ecommerce_App.Data;
using Ecommerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Repositories
{
    public class ProductRepository : IEcommerceRepository<Product>
    {
        readonly EcommerceAppDbContext _dbContext;

        public ProductRepository(EcommerceAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Product entity)
        {
            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = FindById(id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public Product FindById(int id)
        {
            return _dbContext.Products.Include(c => c.Categories).SingleOrDefault(p => p.Id == id);
        }

        public IList<Product> List()
        {
            return _dbContext.Products.Include(c => c.Categories).ToList();
        }

        public List<Product> Search(string term)
        {
            var results = _dbContext.Products.Include(c => c.Categories).Where(p => p.Name.Contains(term)
            || p.Description.Contains(term)
            || p.Categories.Name.Contains(term)).ToList();
            return results;
        }

        public void Update(int id, Product entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
