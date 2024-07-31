using LibraryManagementSystemAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace LibraryManagementSystemAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<UsersBook> UsersBooks { get; set; }

    }
}
