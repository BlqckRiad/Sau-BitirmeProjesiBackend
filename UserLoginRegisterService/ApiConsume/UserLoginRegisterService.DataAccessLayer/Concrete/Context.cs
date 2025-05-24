using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserLoginRegisterService.EntityLayer.Concrete;

namespace UserLoginRegisterService.DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=31.186.11.162;initial catalog=BitirmeMsSqlDb;user id=BitirmeDbUser;password=i#Kaz86jSk_g7vAl;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
