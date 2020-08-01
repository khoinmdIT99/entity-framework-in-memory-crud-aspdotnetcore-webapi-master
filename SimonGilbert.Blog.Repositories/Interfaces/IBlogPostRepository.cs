using System.Linq;
using System.Threading.Tasks;
using SimonGilbert.Blog.Models;

namespace SimonGilbert.Blog.Repositories.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<bool> Create(BlogPost blogPost);

        Task<bool> Update(BlogPost blogPost);

        BlogPost Get(string blogPostId);

        IOrderedQueryable<BlogPost> GetAll();

        IOrderedQueryable<BlogPost> GetAllByUserAccountId(string userAccountId);

        Task<bool> Delete(string blogPostId);
    }
}
