using Microsoft.EntityFrameworkCore;
using NewApiProject.Models;

namespace NewApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) //generated constructor
        {
        }

        public DbSet<Student> Student { get; set; } //to access the database
    }
}
