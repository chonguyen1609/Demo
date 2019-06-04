using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Authorization.Users
{
    public class User : Entity<int>
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
