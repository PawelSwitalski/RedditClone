using Microsoft.EntityFrameworkCore;
using RedditClone.Data;
using RedditClone.Models;

namespace RedditClone.Services
{
    public class PostRepository : Repository<Post>, IPostRepository
    {

        public PostRepository(ApplicationDbContext context) : base(context) 
        {
        }

        public async Task<IEnumerable<Post>> GetAllWithUserAsync()
        {
            return await _dbSet
                .Include(post => post.User)
                .ToListAsync();
        }
    }
}
