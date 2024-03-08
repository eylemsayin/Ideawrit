using Ideawrit.Entities.Concrete;
using Ideawrit.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideawrit.Data.Abstract
{
    public interface IArticleRepository: IEntityRepository<Article>
    {
        
    }
}
