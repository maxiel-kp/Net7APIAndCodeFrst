using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.DALs
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext(DbContextOptions<PracticeDbContext> context) : base(context)
        {
        }

        public DbSet<Students> Students { get; set; }
    }
}