using Microsoft.EntityFrameworkCore;
using App_Cafe.Models;

namespace App_Cafe.Data
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}