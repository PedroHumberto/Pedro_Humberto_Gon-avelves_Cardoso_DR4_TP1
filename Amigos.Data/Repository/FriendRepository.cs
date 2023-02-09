using Amigos.Application.Interfaces;
using Amigos.Application.ViewModels;
using Amigos.Data.Data;
using Amigos.Domain.Friend;
using Microsoft.EntityFrameworkCore;


namespace Amigos.Data.Repository
{
    public class FriendRepository : IFriendRepository
    {
        FriendsDbContext _context;

        public FriendRepository(FriendsDbContext context)
        {
            _context = context;
        }

        public async void AddFriendAsync(Friend friend)
        {
            _context.Friends.AddAsync(friend);
            //devo ter um return?
        }

        public async void DeleteFriendAsync(Guid id)
        {
            var deletedFriend = await _context.Friends.FirstOrDefaultAsync(f => f.Id == id);
            _context.Friends.Remove(deletedFriend);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Friend>> GetAllFriendAsync()
        {
           return await _context.Friends.ToListAsync();
        }
    }
}
