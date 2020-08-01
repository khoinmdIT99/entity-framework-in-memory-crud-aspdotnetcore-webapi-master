using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SimonGilbert.Blog.Context;
using SimonGilbert.Blog.Models;
using SimonGilbert.Blog.Repositories.Interfaces;

namespace SimonGilbert.Blog.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly IServiceScope _scope;
        private readonly BlogPostDatabaseContext _databaseContext;

        public BlogPostRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();

            _databaseContext = _scope.ServiceProvider.GetRequiredService<BlogPostDatabaseContext>();
        }

        public async Task<bool> Create(BlogPost blogPost)
        {
            var success = false;

            _databaseContext.BlogPosts.Add(blogPost);

            var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                success = true;

            return success;
        }

        public async Task<bool> Update(BlogPost blogPost)
        {
            var success = false;

            var existingBlogPost = Get(blogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Title = blogPost.Title;
                existingBlogPost.Description = blogPost.Description;
                existingBlogPost.LastUpdatedDateTimeUtc = blogPost.LastUpdatedDateTimeUtc;

                _databaseContext.BlogPosts.Attach(existingBlogPost);

                var numberOfItemsUpdated = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    success = true;
            }

            return success;
        }

        public BlogPost Get(string blogPostId)
        {
            var result = _databaseContext.BlogPosts
                                .Where(x => x.Id == blogPostId)
                                .FirstOrDefault();

            return result;
        }

        public IOrderedQueryable<BlogPost> GetAll()
        {
            var result = _databaseContext.BlogPosts
                                .OrderByDescending(x => x.LastUpdatedDateTimeUtc);

            return result;
        }

        public IOrderedQueryable<BlogPost> GetAllByUserAccountId(string userAccountId)
        {
            var result = _databaseContext.BlogPosts
                                .Where(x => x.UserAccountId == userAccountId)
                                .OrderByDescending(x => x.LastUpdatedDateTimeUtc);

            return result;
        }

        public async Task<bool> Delete(string blogPostId)
        {
            var success = false;

            var existingBlogPost = Get(blogPostId);

            if (existingBlogPost != null)
            {
                _databaseContext.BlogPosts.Remove(existingBlogPost);

                var numberOfItemsDeleted = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsDeleted == 1)
                    success = true;
            }

            return success;
        }
    }
}
