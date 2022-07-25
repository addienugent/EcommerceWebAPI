using System;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebAPI.Models
{
    public partial class CartDBContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Cart> CartProds { get; set; } = null!;

        public CartDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cart>(entity =>{ entity.HasKey(e => e.UserName);});
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

