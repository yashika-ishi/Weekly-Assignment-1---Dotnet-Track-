using Microsoft.EntityFrameworkCore;
using StudentManagementCQRS_Yashika.Models;

namespace StudentManagementCQRS_Yashika.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
    }
}
