using Shop.Data.Infrastructure;
using Shop.Model.Models;

namespace Shop.Data.Repositories
{

    public interface IProductQuantityRepository : IRepository<ProductQuantity>
    {
    }

    public class ProductQuantityRepository : RepositoryBase<ProductQuantity>, IProductQuantityRepository
    {
        public ProductQuantityRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
