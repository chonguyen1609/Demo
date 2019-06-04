using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using MyProject.Users.Dto;

namespace MyProject.Users
{
    public interface IUserService : ITransientDependency
    {
        Task<bool> CreateUser(UserDto entry);
        Task<bool> UpdateUser(UserDto entry);
        Task<List<UserDto>> GetUsers(int page = 0, int? pageSize = null);
        Task<UserDto> GetUserById(int userId);
    }
}
