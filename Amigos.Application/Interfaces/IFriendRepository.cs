using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;


namespace Amigos.Application.Interfaces
{
    public interface IFriendRepository
    {
        Task<List<Friend>> GetAllFriendAsync();
        void AddFriendAsync(Friend model);
        void DeleteFriendAsync(Guid id);
    }
}
