using IysService.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DataAccessLayer.Concrete
{
    
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=31.186.11.162;initial catalog=BitirmeMsSqlDb;user id=BitirmeDbUser;password=i#Kaz86jSk_g7vAl;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True");
        }
        public DbSet<Contact> Contacts { get; set; }
      public DbSet<Appointment> Appointments { get; set; }
      public DbSet<XRayResult> XRayResults { get; set; }
      public DbSet<Image> Images { get; set; }
      public DbSet<Activity> Activitys { get; set; }
    }
}
