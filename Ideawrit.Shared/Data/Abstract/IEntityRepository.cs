using Ideawrit.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ideawrit.Shared.Data.Abstract
{
    //Generic Repository Pattern-IEntityRepository<T>: Tüm DAL class larımızda ortak kullanacağımız metodları bu repository içerisine eklicez.örn kullanıcalrın, makalelerin listelenmesi, getirilmesi...
    public interface IEntityRepository<T> where T :class, IEntity,new()
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T, object>>[] includeProperties); //var kullanici= repository.GetAsync(k=>k.Name==Eylem);

        //EXPRESSION<FUNC<T,BOOL>>PREDICATE : ID'si 10 olan makaleyi getirmek istiyoruz. var makale = repository.Get(m => m.Id =15); Bizim vereceğimiz lambda ezpression'lar "filtre", yani predicate'dir.
        //PARAMS EXPRESSION<FUNC<T, OBJECT>>[] INCLUDEPROPERTIES> : 25 Id'li makaleyi getiriken, makale ile birlikte kullanıcıyı ve yorumlarıda include etmek(birlikte getirmek) istiyoruz. var makale=repository.GetAsync(m =>m.Id==25, m=>m.User,m=>m.Comments);
        

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        //ADD(),UPDATE(),DELETE() ÖRN: Kategori eklemek için; _categoryRepository.AddAsync(Category category); Kullanıcı eklmek güncellemek için; _userRepository.UpdateAsync(User user); Yorum silmek için; _commentRepository.DeleteAsync(Comment comment);

     //ANY(),COUNT() : Eylem isimli bir kullanıcı var mı? var result = _userRepository.AnyAsnyc(u=>u.FirstName=="Eylem"); İşlemlerin sonucunda true/false dönecektir.  var count = _articleRepository.CountAsync(); Tüm makalalerin sayısını dönecektir. var commentCount = _commentRepository.CountAsync(c=>c.ArticleId==20); ID'si 20 olan makalelerin sayısını dönecektir.









    }
}
