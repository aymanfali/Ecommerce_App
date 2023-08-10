namespace Ecommerce_App.Repositories
{
    public interface IEcommerceRepository<TEntity>
    {
        IList<TEntity> List();
        TEntity FindById(int id);
        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
        List<TEntity> Search(string term);
    }
}
