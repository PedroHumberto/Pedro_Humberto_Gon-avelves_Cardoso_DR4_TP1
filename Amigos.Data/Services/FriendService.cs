using Amigos.Application.Interfaces;
using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;
using AutoMapper;

namespace Amigos.Data.Services
{
    public class FriendService : IFriendService
    {
        public IFriendRepository _repository;
        public IMapper _mapper;

        public FriendService(IFriendRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Friend> AddFriendAsync(Friend friend)
        {

            _repository.AddFriendAsync(friend);
           
            return friend;
        }

        public void DeleteFriendAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FriendViewModel>> GetAllFriendAsync()
        {
            var friendList = await _repository.GetAllFriendAsync();

            var viewModel = _mapper.Map<List<FriendViewModel>>(friendList);

            return viewModel;
        }
    }
}
