using Ideawrit.Entities.Concrete;
using Ideawrit.Shared.Data.Abstract;

namespace Ideawrit.Entities.Dtos
{
    public class CategoryDto :DtoGetBase
    {
        public Category Category { get; set; }
    }

}
