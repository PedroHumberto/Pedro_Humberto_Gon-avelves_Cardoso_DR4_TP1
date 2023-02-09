using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigos.Application.Interfaces
{
    public interface IFriendService
    {
        Task<List<Friend>> GetAllFriendAsync();
        Task<Friend> AddFriendAsync(Friend model);
        void DeleteFriendAsync(Guid id);
    }
}
