using Amigos.Application.Interfaces;
using Amigos.Application.ViewModels;
using Amigos.Data.Data;
using Amigos.Domain.Friend;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Amigos.Data.Repository
{
    public class FriendRepository : IFriendRepository
    {
        FriendsDbContext _context;

        public FriendRepository(FriendsDbContext context)
        {
            _context = context;
        }

        public async Task<Friend> AddFriendAsync(Friend friend)
        {
            await _context.Friends.AddAsync(friend);
            await _context.SaveChangesAsync();

            Console.WriteLine("Salvo no db");

            return friend;
        }

        public async void DeleteFriendAsync(Friend friend)
        {
            _context.Friends.Remove(friend);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Friend>> GetAllFriendAsync()
        {
            var allFriends = await _context.Friends.ToListAsync();
            if (allFriends.IsNullOrEmpty()) return new List<Friend>();

            return await _context.Friends.ToListAsync();
        }
    }
}
