using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using MyProject.Authorization.Users;
using MyProject.Users.Dto;

namespace MyProject.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<User, int> _useRepository;
        public UserService(IUnitOfWorkManager unitOfWork, IRepository<User, int> useRepository)
        {
            _unitOfWorkManager = unitOfWork;
            _useRepository = useRepository;
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public async Task<bool> CreateUser(UserDto entry)
        {
            if (entry.Id > 0)
            {
                throw new ArgumentException("Invalid data entry.");
            }

            await _useRepository.InsertAsync(entry.MapTo<User>());
            await _unitOfWorkManager.Current.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(UserDto entry)
        {
            var user = await _useRepository.FirstOrDefaultAsync(u => u.Id == entry.Id);

            if (user == null)
            {
                throw new KeyNotFoundException($"Not found user id {entry.Id}");
            }

            user.Address = entry.Address;
            user.Name = entry.Name;
            user.Age = entry.Age;

            await _useRepository.UpdateAsync(user);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get users.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<UserDto>> GetUsers(int page = 0, int? pageSize = null)
        {
            return !pageSize.HasValue ? _useRepository.GetAll().MapTo<List<UserDto>>() 
                : _useRepository.GetAll().Skip(page * pageSize.Value).Take(pageSize.Value).MapTo<List<UserDto>>();
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid data entry.");
            }

            var user = await _useRepository.FirstOrDefaultAsync(u => u.Id == userId);
            return user.MapTo<UserDto>();
        }
    }
}
