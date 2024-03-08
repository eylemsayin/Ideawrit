namespace Ideawrit.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleRepository Articles { get; } //unitofwork.Articles
        ICategoryRepository Categories { get; } 
        ICommentRepository Comments { get; } 
        IRoleRepository Roles { get; } 
        IUserRepository Users { get; }  //_unitOfWork.Categories.AddAsync();

        Task SaveAsync();
    }
}
