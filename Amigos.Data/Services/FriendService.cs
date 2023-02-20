using Amigos.Application.Interfaces;
using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Friend> AddFriendAsync(FriendViewModel model)
        {
            var friend = _mapper.Map<Friend>(model);

            await _repository.AddFriendAsync(friend);
           
            return friend;
        }

        public void DeleteFriendAsync(Guid id)
        {
            var delete = _repository.GetAllFriendAsync().Result.FirstOrDefault(friend => friend.Id == id);

            _repository.DeleteFriendAsync(delete);
        }

        public async Task<List<FriendViewModel>> GetAllFriendAsync()
        {
            var friendList = await _repository.GetAllFriendAsync();

            var viewModel = _mapper.Map<List<FriendViewModel>>(friendList);

            return viewModel;
        }

        public async Task<List<FriendViewModel>> GetSelectedFriends(List<Guid> selected)
        {
            var friendList = await _repository.GetAllFriendAsync();

            var viewModel = _mapper.Map<List<FriendViewModel>>(friendList);

            return viewModel.Where(f => selected.Contains(f.Id)).ToList();
        }
    }
}
