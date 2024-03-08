using Ideawrit.Entities.Concrete;
using Ideawrit.Shared.Data.Abstract;

namespace Ideawrit.Entities.Dtos
{
    public class CategoryListDto: DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
