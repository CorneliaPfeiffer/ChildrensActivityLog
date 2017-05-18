using ChildrensActivityLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChildrensActivityLog.Data
{
    public class ChildrensActivityLogContext : DbContext

   
    {
        //public ChildrensActivityLogContext(DbContextOptions<ChildrensActivityLogContext> options) : base(options)
        //{  }
        
        public DbSet<Child> Children { get; set; }       
        public DbSet<SleepingPeriod> SleepingPeriods { get; set; }
        public DbSet<PlayEvent> PlayEvents { get; set; }
        public DbSet<ChildrensPlayEvents> ChildrensPlayEvents { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChildrensPlayEvents>()
                .HasKey(c => new { c.ChildId, c.PlayEventId });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = ChildrensActivityLog; Trusted_Connection = True; ");
        }
    }
}
