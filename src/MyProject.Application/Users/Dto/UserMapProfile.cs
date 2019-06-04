using AutoMapper;
using MyProject.Authorization.Users;

namespace MyProject.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserLoginDto, UserLogin>();
            CreateMap<UserLoginDto, UserLogin>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<CreateUserLoginDto, UserLogin>();
            CreateMap<CreateUserLoginDto, UserLogin>().ForMember(x => x.Roles, opt => opt.Ignore());

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
