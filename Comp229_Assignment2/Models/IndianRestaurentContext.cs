namespace Comp229_Assignment2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IndianRestaurentContext : DbContext
    {
        public IndianRestaurentContext()
            : base("name=IndianRestaurentContext")
        {
        }

        public virtual DbSet<Dessert> Desserts { get; set; }
        public virtual DbSet<Non_Vegfood> Non_Vegfood { get; set; }
        public virtual DbSet<Snack> Snacks { get; set; }
        public virtual DbSet<Vegfood> Vegfood { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dessert>()
                .Property(e => e.DessertsPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Non_Vegfood>()
                .Property(e => e.Non_VegfoodPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Non_Vegfood>()
                .Property(e => e.Non_VegfoodImage)
                .IsUnicode(false);

            modelBuilder.Entity<Snack>()
                .Property(e => e.SnacksPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Vegfood>()
                .Property(e => e.VegfoodPrice)
                .HasPrecision(18, 0);
        }
    }
}
