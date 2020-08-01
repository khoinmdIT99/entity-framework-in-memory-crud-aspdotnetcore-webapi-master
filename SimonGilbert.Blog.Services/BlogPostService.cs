using System;
using System.Linq;
using System.Threading.Tasks;
using SimonGilbert.Blog.Models;
using SimonGilbert.Blog.Repositories.Interfaces;
using SimonGilbert.Blog.Services.Interfaces;

namespace SimonGilbert.Blog.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _repository;

        public BlogPostService(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<BlogPost> Create(BlogPost blogPost)
        {
            blogPost.LastUpdatedDateTimeUtc = DateTime.UtcNow;

            var success = await _repository.Create(blogPost);

            if (success)
                return blogPost;
            else
                return null;
        }

        public async Task<BlogPost> Update(BlogPost blogPost)
        {
            blogPost.LastUpdatedDateTimeUtc = DateTime.UtcNow;

            var success = await _repository.Update(blogPost);

            if (success)
                return blogPost;
            else
                return null;
        }

        public BlogPost Get(string blogPostId)
        {
            var result = _repository.Get(blogPostId);

            return result;
        }

        public IOrderedQueryable<BlogPost> GetAll()
        {
            var result = _repository.GetAll();

            return result;
        }

        public IOrderedQueryable<BlogPost> GetAllByUserAccountId(string userAccountId)
        {
            var result = _repository.GetAllByUserAccountId(userAccountId);

            return result;
        }

        public async Task<bool> Delete(string blogPostId)
        {
            var success = await _repository.Delete(blogPostId);

            return success;
        }
    }
}
