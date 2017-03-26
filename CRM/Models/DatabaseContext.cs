using Microsoft.EntityFrameworkCore;

namespace CRM.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Annotations> Annotations { get; set; }
    }
}
