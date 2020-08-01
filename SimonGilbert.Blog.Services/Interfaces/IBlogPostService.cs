using System.Linq;
using System.Threading.Tasks;
using SimonGilbert.Blog.Models;

namespace SimonGilbert.Blog.Services.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPost> Create(BlogPost blogPost);

        Task<BlogPost> Update(BlogPost blogPost);

        BlogPost Get(string blogPostId);

        IOrderedQueryable<BlogPost> GetAll();

        IOrderedQueryable<BlogPost> GetAllByUserAccountId(string userAccountId);

        Task<bool> Delete(string blogPostId);
    }
}
