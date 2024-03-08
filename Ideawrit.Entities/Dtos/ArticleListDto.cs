using Ideawrit.Entities.Concrete;
using Ideawrit.Shared.Data.Abstract;

namespace Ideawrit.Entities.Dtos
{
    public class ArticleListDto :DtoGetBase
    {
        public IList<Article> Articles { get; set; }
        
    }
}
