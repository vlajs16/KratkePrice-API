using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class PriceContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Pitanje> Pitanja { get; set; }
        public DbSet<Odgovor> Odgovori { get; set; }
        public DbSet<Prica> Price { get; set; }

        public PriceContext(DbContextOptions<PriceContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Odgovor>(o =>
            {
                o.HasKey(x => new { x.PitanjeID, x.OdgovorID });
                o.Property(x => x.OdgovorID).ValueGeneratedOnAdd();
            });

        }
    }
}
