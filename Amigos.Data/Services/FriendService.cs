using Amigos.Application.Interfaces;
using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigos.Data.Services
{
    public class FriendService : IFriendService
    {
        public IFriendRepository _repository;
        public async Task<Friend> AddFriendAsync(Friend friend)
        {

            _repository.AddFriendAsync(friend);
           
            return friend;
        }

        public void DeleteFriendAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Friend>> GetAllFriendAsync()
        {
            return await _repository.GetAllFriendAsync();
        }
    }
}
