using boxes_api.Data;
using Microsoft.EntityFrameworkCore;
using System;

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

        // Passar os relacionamentos
        /* 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de relacionamento, chaves primárias e estrangeiras, etc.
            // Ex:
            // modelBuilder.Entity<Cashier>().HasMany(c => c.Events).WithOne(e => e.Cashier);
            // modelBuilder.Entity<Event>().HasOne(e => e.Cashier).WithMany(c => c.Events);
        }
        */
    }
}
