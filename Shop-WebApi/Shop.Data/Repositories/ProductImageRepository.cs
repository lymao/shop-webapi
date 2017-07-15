using Shop.Data.Infrastructure;
using Shop.Model.Models;

namespace Shop.Data.Repositories
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
    }

    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
