using Ideawrit.Data.Abstract;
using Ideawrit.Entities.Concrete;
using Ideawrit.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Ideawrit.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
