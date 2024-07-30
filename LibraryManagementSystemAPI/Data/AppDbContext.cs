using LibraryManagementSystemAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace LibraryManagementSystemAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } 
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
