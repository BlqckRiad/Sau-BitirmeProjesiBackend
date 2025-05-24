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
            optionsBuilder.UseSqlServer("data source=MILANOPC;initial catalog=BitirmeDb;user id=ps;password=12345Aa!;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True");
        }
      public DbSet<Contact> Contacts { get; set; }
      public DbSet<Appointment> Appointments { get; set; }
      public DbSet<XRayResult> XRayResults { get; set; }
      public DbSet<Image> Images { get; set; }
    }
}
