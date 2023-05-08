using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ahtapot.Models
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AQGNSHA;Initial Catalog=AhtapotDb;Integrated Security=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Wiki> Wikis { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
    }
}