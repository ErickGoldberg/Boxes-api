using boxes_api.Data;
using Microsoft.EntityFrameworkCore;

namespace boxes_api.DbConnection
{
    public class BoxesContext : DbContext
    {
        public BoxesContext(DbContextOptions<BoxesContext> options)
            : base(options)
        {

        }

        public DbSet<Cashiers> Cashiers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<CashierEvent> CashierEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashierEvent>()
                .HasKey(ce => new { ce.CashierId, ce.EventId });

            modelBuilder.Entity<CashierEvent>()
                .HasOne(ce => ce.Cashier)
                .WithMany(c => c.CashierEvents)
                .HasForeignKey(ce => ce.CashierId);

            modelBuilder.Entity<CashierEvent>()
                .HasOne(ce => ce.Event)
                .WithMany(e => e.CashierEvents)
                .HasForeignKey(ce => ce.EventId);
        }
    }
}
