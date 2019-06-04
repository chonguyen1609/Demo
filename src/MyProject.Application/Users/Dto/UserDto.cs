using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using MyProject.Authorization.Users;

namespace MyProject.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }
    }
}
