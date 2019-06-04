using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.MultiTenancy;

namespace MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, UserLogin, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> UserModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>(u => { u.HasIndex(e => new {e.Id}); });
        }

    }
}
