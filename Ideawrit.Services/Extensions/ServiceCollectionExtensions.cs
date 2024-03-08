using Ideawrit.Data.Abstract;
using Ideawrit.Data.Concrete;
using Ideawrit.Data.Concrete.EntityFramework.Contexts;
using Ideawrit.Services.Abstract;
using Ideawrit.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Ideawrit.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices (this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<IdeawritContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped< IArticleService, ArticleManager>();
            return serviceCollection;
        }
    }
}
