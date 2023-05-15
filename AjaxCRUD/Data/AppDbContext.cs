using Microsoft.EntityFrameworkCore;

namespace AjaxCRUD.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //     optionsBuilder.UseMySQL("server=localhost;database=BulkyBook;user=root;password=");
        // }
    }
}
