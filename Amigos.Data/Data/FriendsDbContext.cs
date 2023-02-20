using Amigos.Domain.Friend;
using Microsoft.EntityFrameworkCore;


namespace Amigos.Data.Data
{
    public class FriendsDbContext : DbContext
    {
        public FriendsDbContext(DbContextOptions<FriendsDbContext> options) : base(options)
        {
                
        }

        public DbSet<Friend> Friends { get; set; }
    }
}
