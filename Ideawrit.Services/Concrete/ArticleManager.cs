﻿using AutoMapper;
using Ideawrit.Data.Abstract;
using Ideawrit.Entities.Concrete;
using Ideawrit.Entities.Dtos;
using Ideawrit.Services.Abstract;
using Ideawrit.Shared.Utilities.Results.Abstract;
using Ideawrit.Shared.Utilities.Results.ComplexTypes;
using Ideawrit.Shared.Utilities.Results.Concrete;

namespace Ideawrit.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitOfWork.Articles.AddAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} The article titled has been successfully added...");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAync(a => a.Id == articleId);
            if(result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} The article titled has been deleted successfully");
            }
            return new Result(ResultStatus.Error, "No such article found");
        }

        public  async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if(article!=null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "No such article found.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if(articles.Count>-1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success

                });

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Articles not found...", null);
        }

        public  async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAync(c => c.Id == categoryId);
            if(result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success

                    });

                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Articles not found...", null);

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "No such category found...", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success

                });

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Articles not found...", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success

                });

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Articles not found...", null);

        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} The article titled has been deleted successfully");
            }
            return new Result(ResultStatus.Error, "No such article found");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} The article titled has been successfully updated...");

        }
    }

   
      

       
}
