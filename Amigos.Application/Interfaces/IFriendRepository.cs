using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;


namespace Amigos.Application.Interfaces
{
    public interface IFriendRepository
    {
        Task<List<Friend>> GetAllFriendAsync();
        Task<Friend> AddFriendAsync(Friend model);
        void DeleteFriendAsync(Friend id);
    }
}
