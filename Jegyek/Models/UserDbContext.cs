using Jegyek.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Jegyek.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {

        }

        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=localhost; database=Jegyek; user=root; password=";

                optionsBuilder.UseMySQL(conn);
            }
        }

        public DbSet<User> Tantargy { get; set; } = null!;
    }
}