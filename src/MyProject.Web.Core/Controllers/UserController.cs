using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MyProject.Users;
using MyProject.Users.Dto;

namespace MyProject.Controllers
{
    [Route("api/users")]
    [WrapResult(false)]
    public class UserController : AbpController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> CreateUser([FromBody] UserDto entry)
        {
            return await _userService.CreateUser(entry);
        }

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> UpdateUser([FromBody] UserDto entry)
        {
            return await _userService.UpdateUser(entry);
        }

        /// <summary>
        /// Get Users.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserDto>> GetUsers([FromQuery] int page = 0, [FromQuery] int? pageSize = null)
        {
            return await _userService.GetUsers(page, pageSize);
        }

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<UserDto> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }
    }
}
