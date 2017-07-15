using Shop.Data.Infrastructure;
using Shop.Model.Models;

namespace Shop.Data.Repositories
{
    public interface ISizeRepository : IRepository<Size>
    {
    }

    public class SizeRepository : RepositoryBase<Size>, ISizeRepository
    {
        public SizeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}