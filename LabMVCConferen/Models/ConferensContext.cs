using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabMVCConferen.Models
{
    public class ConferensContext:DbContext
    {
        public DbSet<Conferens> Conferens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; } 
        
        public ConferensContext(DbContextOptions<ConferensContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
       
        

    }
}
