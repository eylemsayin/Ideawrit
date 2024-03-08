using Ideawrit.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideawrit.Entities.Concrete
{
    public class Category : EntityBase, IEntity //Category classı EntityBase den türüyor ve IEntity i implament'e ediyorsun demiş olduk.
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
