using Microsoft.EntityFrameworkCore;
using project_pp.Model;

namespace project_pp.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
}
