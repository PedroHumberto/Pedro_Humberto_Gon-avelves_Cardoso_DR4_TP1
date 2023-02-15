using Amigos.Application.ViewModels;
using Amigos.Domain.Friend;
using AutoMapper;


namespace Amigos.Data.Profiles
{
    public class FriendProfile : Profile
    {
        public FriendProfile()
        {
            CreateMap<FriendViewModel, Friend>();
            CreateMap<Friend, FriendViewModel>();

        }
    }
}
