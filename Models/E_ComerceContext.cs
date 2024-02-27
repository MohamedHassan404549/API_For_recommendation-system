using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Models.Class;

namespace مشروع_التخرج.Models
{
    public class E_ComerceContext : IdentityDbContext<ApplicationUser>
    {
        public E_ComerceContext(DbContextOptions<E_ComerceContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<Bundle_Cart>()
                .HasKey(bc => new { bc.Bundle_Id, bc.Cart_Id });

            modelBuilder.Entity<Bundle_Wish_List>()
                .HasKey(bc => new { bc.W_Id, bc.Bundle_Id });

            modelBuilder.Entity<Product_Bundle>()
                .HasKey(bc => new { bc.P_Id, bc.Bundle_Id });

            modelBuilder.Entity<Product_Cart>()
               .HasKey(bc => new { bc.P_Id, bc.Cart_Id });

            modelBuilder.Entity<Product_Wish_List>()
              .HasKey(bc => new { bc.P_Id, bc.W_Id });

            modelBuilder.Entity<SubCatagory>()
       .HasOne(sc => sc.Adminstrator)
       .WithMany(a => a.SubCatagories)
       .HasForeignKey(sc => sc.Admin_Id)
       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
     .HasOne(p => p.SubCatagory)
     .WithMany(sc => sc.Products)
     .HasForeignKey(p => p.Sub_C_Id)
     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubCatagory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.SubCatagories)
                .HasForeignKey(s => s.C_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
      .HasOne(p => p.Adminstrator)
      .WithMany(c => c.Products)
      .HasForeignKey(p => p.Admin_Id)
      .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
         .HasOne(p => p.Adminstrator)
         .WithMany(c => c.Products)
         .HasForeignKey(p => p.Admin_Id)
         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
       .HasOne(p => p.SubCatagory)
       .WithMany(c => c.Products)
       .HasForeignKey(p => p.Sub_C_Id)
       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
       .HasOne(p => p.SubCatagory)
       .WithMany(sc => sc.Products)
       .HasForeignKey(p => p.Sub_C_Id)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
      .HasOne(p => p.Adminstrator)
      .WithMany(c => c.Categories)
      .HasForeignKey(p => p.Admin_Id)
      .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
         .HasOne(p => p.Adminstrator)
         .WithMany(c => c.Categories)
         .HasForeignKey(p => p.Admin_Id)
         .OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<Product_Bundle>()
         .HasOne(pb => pb.Product)
         .WithMany(p => p.product_Bundles)
         .HasForeignKey(pb => pb.P_Id)
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product_Bundle>()
         .HasOne(pb => pb.Bundle)
         .WithMany(b => b.product_Bundles)
         .HasForeignKey(pb => pb.Bundle_Id)
         .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Bundle>()
        .HasOne(pb => pb.Adminstrator)
        .WithMany(p => p.Bundles)
        .HasForeignKey(pb => pb.Admin_Id)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bundle>()
         .HasOne(pb => pb.Adminstrator)
         .WithMany(b => b.Bundles)
         .HasForeignKey(pb => pb.Admin_Id)
         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bundle_Cart>()
         .HasOne(pb => pb.Bundle)
         .WithMany(p => p.Bundle_Carts)
         .HasForeignKey(pb => pb.Bundle_Id)
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bundle_Cart>()
         .HasOne(pb => pb.Cart)
         .WithMany(b => b.bundle_Carts)
         .HasForeignKey(pb => pb.Cart_Id)
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bundle_Order>()
        .HasOne(pb => pb.Bundle)
        .WithMany(p => p.Bundle_Orders)
        .HasForeignKey(pb => pb.Bundle_Id)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bundle_Order>()
         .HasOne(pb => pb.Customer)
         .WithMany(b => b.Bundle_Orders)
         .HasForeignKey(pb => pb.Cus_Id)
         .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Bundle_Review>()
        .HasOne(pb => pb.Bundle)
        .WithMany(p => p.Bundle_Reviews)
        .HasForeignKey(pb => pb.Bundle_Id)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bundle_Review>()
         .HasOne(pb => pb.Customer)
         .WithMany(b => b.Bundle_Reviews)
         .HasForeignKey(pb => pb.Cus_Id)
         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bundle_Wish_List>()
       .HasOne(pb => pb.Bundle)
       .WithMany(p => p.Bundle_Wish_Lists)
       .HasForeignKey(pb => pb.Bundle_Id)
       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bundle_Wish_List>()
         .HasOne(pb => pb.Wish_List)
         .WithMany(b => b.Bundle_Wish_Lists)
         .HasForeignKey(pb => pb.W_Id)
         .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Customer>()
     .HasOne(p => p.Cart)
     .WithMany(c => c.Customers)
     .HasForeignKey(p => p.Cart_Id)
     .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Customer>()
         .HasOne(p => p.Cart)
         .WithMany(c => c.Customers)
         .HasForeignKey(p => p.Cart_Id)
         .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Product_Cart>()
         .HasOne(pb => pb.Product)
         .WithMany(p => p.product_Carts)
         .HasForeignKey(pb => pb.P_Id)
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product_Cart>()
         .HasOne(pb => pb.Cart)
         .WithMany(b => b.product_Carts)
         .HasForeignKey(pb => pb.Cart_Id)
         .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Product_Order>()
        .HasOne(pb => pb.Product)
        .WithMany(p => p.Product_Orders)
        .HasForeignKey(pb => pb.P_Id)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product_Order>()
         .HasOne(pb => pb.Customer)
         .WithMany(b => b.Product_Orders)
         .HasForeignKey(pb => pb.Cus_Id)
         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product_Review>()
        .HasOne(pb => pb.Product)
        .WithMany(p => p.Product_Reviews)
        .HasForeignKey(pb => pb.P_Id)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product_Review>()
         .HasOne(pb => pb.Customer)
         .WithMany(b => b.Product_Reviews)
         .HasForeignKey(pb => pb.Cus_Id)
         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product_Wish_List>()
      .HasOne(pb => pb.Product)
      .WithMany(p => p.product_Wish_Lists)
      .HasForeignKey(pb => pb.P_Id)
      .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product_Wish_List>()
         .HasOne(pb => pb.Wish_List)
         .WithMany(b => b.product_Wish_Lists)
         .HasForeignKey(pb => pb.W_Id)
         .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Customer>()
     .HasOne(p => p.Wish_List)
     .WithMany(c => c.customers)
     .HasForeignKey(p => p.Cus_Id)
     .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Customer>()
         .HasOne(p => p.Wish_List)
         .WithMany(c => c.customers)
         .HasForeignKey(p => p.Cus_Id)
         .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Adminstrator> Adminstrators { get; set; }
        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<Bundle_Cart> Bundle_Carts { get; set; }
        public virtual DbSet<Bundle_Order> Bundle_Orders { get; set; }
        public virtual DbSet<Bundle_Review> Bundle_Reviews { get; set; }
        public virtual DbSet<Bundle_Wish_List> Bundle_Wish_Lists { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<SubCatagory> SubCatagories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Bundle> Product_Bundles { get; set; }
        public virtual DbSet<Product_Cart> Product_Carts { get; set; }
        public virtual DbSet<Product_Order> Product_Orders { get; set; }
        public virtual DbSet<Product_Review> Product_Reviews { get; set; }
        public virtual DbSet<Product_Wish_List> Product_Wish_Lists { get; set; }
        public virtual DbSet<Wish_List> Wish_Lists { get; set; }
     
    
        
    }


}