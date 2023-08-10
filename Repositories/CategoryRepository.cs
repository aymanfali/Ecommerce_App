using Ecommerce_App.Data;
using Ecommerce_App.Models;

namespace Ecommerce_App.Repositories
{
    public class CategoryRepository : IEcommerceRepository<Category>
    {
        readonly EcommerceAppDbContext _dbContext;

        public CategoryRepository(EcommerceAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Category entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = FindById(id);
            _dbContext.Remove(category);
            _dbContext.SaveChanges();
        }

        public Category FindById(int id)
        {
            return _dbContext.Categories.SingleOrDefault(c => c.Id == id);
        }

        public IList<Category> List()
        {
            return _dbContext.Categories.ToList();
        }

        public List<Category> Search(string term)
        {
            var results = _dbContext.Categories.Where(b => b.Name.Contains(term)).ToList();
            return results;
        }

        public void Update(int id, Category entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
