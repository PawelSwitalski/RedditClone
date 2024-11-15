using RedditClone.Models;

namespace RedditClone.Services
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllWithUserAsync();
    }
}
