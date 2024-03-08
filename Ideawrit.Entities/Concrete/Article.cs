using Ideawrit.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideawrit.Entities.Concrete
{
    public class Article: EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; } 
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public string SeoAuthor { get; set; } //Seo: Arama motoru optimizasyonu, web sitelerini arama motorlarının daha rahat anlayabilmesine(tarayabilmesine) olanak sağlayacak şekilde arama motorlarının kriterlerine uygun hale getirilerek web sitesinin optimize edilmesini hedeflenen anahtar kelimelere ait arama motoru aramalarında yükseltilmesidir.tr.wikipedia.org
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } //Navigation Property
        public int UserId { get; set; }
        public User User  { get; set; } //Navigation Property
        public ICollection<Comment> Comments { get; set; }











    }
}
