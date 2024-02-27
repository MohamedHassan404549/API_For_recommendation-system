﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using مشروع_التخرج.Models;

#nullable disable

namespace مشروع_التخرج.Migrations
{
    [DbContext(typeof(E_ComerceContext))]
    partial class E_ComerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Adminstrator", b =>
                {
                    b.Property<int>("Admin_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Admin_Id"), 1L, 1);

                    b.Property<string>("Admin_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Admin_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Admin_Id");

                    b.ToTable("Adminstrators");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle", b =>
                {
                    b.Property<int>("Bundle_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Bundle_Id"), 1L, 1);

                    b.Property<int>("Admin_Id")
                        .HasColumnType("int");

                    b.Property<string>("Bundle_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Bundle_Price")
                        .HasColumnType("int");

                    b.Property<byte[]>("Bundle_image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Bundle_Id");

                    b.HasIndex("Admin_Id");

                    b.ToTable("Bundles");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle_Cart", b =>
                {
                    b.Property<int>("Bundle_Id")
                        .HasColumnType("int");

                    b.Property<int>("Cart_Id")
                        .HasColumnType("int");

                    b.HasKey("Bundle_Id", "Cart_Id");

                    b.HasIndex("Cart_Id");

                    b.ToTable("Bundle_Carts");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle_Order", b =>
                {
                    b.Property<int>("B_Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("B_Order_Id"), 1L, 1);

                    b.Property<int>("Bundle_Id")
                        .HasColumnType("int");

                    b.Property<int>("Cus_Id")
                        .HasColumnType("int");

                    b.Property<string>("Order_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.HasKey("B_Order_Id");

                    b.HasIndex("Bundle_Id");

                    b.HasIndex("Cus_Id");

                    b.ToTable("Bundle_Orders");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle_Review", b =>
                {
                    b.Property<int>("B_Review_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("B_Review_Id"), 1L, 1);

                    b.Property<string>("B_Review_Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Bundle_Id")
                        .HasColumnType("int");

                    b.Property<int>("Cus_Id")
                        .HasColumnType("int");

                    b.Property<int>("Reting")
                        .HasColumnType("int");

                    b.HasKey("B_Review_Id");

                    b.HasIndex("Bundle_Id");

                    b.HasIndex("Cus_Id");

                    b.ToTable("Bundle_Reviews");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle_Wish_List", b =>
                {
                    b.Property<int>("W_Id")
                        .HasColumnType("int");

                    b.Property<int>("Bundle_Id")
                        .HasColumnType("int");

                    b.HasKey("W_Id", "Bundle_Id");

                    b.HasIndex("Bundle_Id");

                    b.ToTable("Bundle_Wish_Lists");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Cart", b =>
                {
                    b.Property<int>("Cart_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cart_Id"), 1L, 1);

                    b.Property<int>("Cart_Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Cart_Total_Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Cart_Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Category", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("C_Id"), 1L, 1);

                    b.Property<int>("Admin_Id")
                        .HasColumnType("int");

                    b.Property<string>("C_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("C_Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("C_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("C_Id");

                    b.HasIndex("Admin_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Customer", b =>
                {
                    b.Property<int>("Cus_Id")
                        .HasColumnType("int");

                    b.Property<int>("Cart_Id")
                        .HasColumnType("int");

                    b.Property<string>("Cus_City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cus_Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cus_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cus_Passaword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cus_Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cus_firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cus_lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cus_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("W_Id")
                        .HasColumnType("int");

                    b.HasKey("Cus_Id");

                    b.HasIndex("Cart_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product", b =>
                {
                    b.Property<int>("P_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("P_Id"), 1L, 1);

                    b.Property<int>("Admin_Id")
                        .HasColumnType("int");

                    b.Property<string>("P_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("P_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("P_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Sub_C_Id")
                        .HasColumnType("int");

                    b.Property<byte[]>("p_Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("P_Id");

                    b.HasIndex("Admin_Id");

                    b.HasIndex("Sub_C_Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Bundle", b =>
                {
                    b.Property<int>("P_Id")
                        .HasColumnType("int");

                    b.Property<int>("Bundle_Id")
                        .HasColumnType("int");

                    b.HasKey("P_Id", "Bundle_Id");

                    b.HasIndex("Bundle_Id");

                    b.ToTable("Product_Bundles");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Cart", b =>
                {
                    b.Property<int>("P_Id")
                        .HasColumnType("int");

                    b.Property<int>("Cart_Id")
                        .HasColumnType("int");

                    b.HasKey("P_Id", "Cart_Id");

                    b.HasIndex("Cart_Id");

                    b.ToTable("Product_Carts");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Order", b =>
                {
                    b.Property<int>("Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_Id"), 1L, 1);

                    b.Property<int>("Cus_Id")
                        .HasColumnType("int");

                    b.Property<string>("Order_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("P_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.HasKey("Order_Id");

                    b.HasIndex("Cus_Id");

                    b.HasIndex("P_Id");

                    b.ToTable("Product_Orders");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Review", b =>
                {
                    b.Property<int>("Review_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Review_Id"), 1L, 1);

                    b.Property<int>("Cus_Id")
                        .HasColumnType("int");

                    b.Property<int>("P_Id")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.HasKey("Review_Id");

                    b.HasIndex("Cus_Id");

                    b.HasIndex("P_Id");

                    b.ToTable("Product_Reviews");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Wish_List", b =>
                {
                    b.Property<int>("P_Id")
                        .HasColumnType("int");

                    b.Property<int>("W_Id")
                        .HasColumnType("int");

                    b.HasKey("P_Id", "W_Id");

                    b.HasIndex("W_Id");

                    b.ToTable("Product_Wish_Lists");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.SubCatagory", b =>
                {
                    b.Property<int>("Sub_C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sub_C_Id"), 1L, 1);

                    b.Property<int>("Admin_Id")
                        .HasColumnType("int");

                    b.Property<int>("C_Id")
                        .HasColumnType("int");

                    b.Property<byte[]>("Sub_C_image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("sub_c_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sub_C_Id");

                    b.HasIndex("Admin_Id");

                    b.HasIndex("C_Id");

                    b.ToTable("SubCatagories");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Wish_List", b =>
                {
                    b.Property<int>("W_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("W_Id"), 1L, 1);

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.HasKey("W_Id");

                    b.ToTable("Wish_Lists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Adminstrator", "Adminstrator")
                        .WithMany("Bundles")
                        .HasForeignKey("Admin_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adminstrator");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle_Cart", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Bundle", "Bundle")
                        .WithMany("Bundle_Carts")
                        .HasForeignKey("Bundle_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Cart", "Cart")
                        .WithMany("bundle_Carts")
                        .HasForeignKey("Cart_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bundle");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle_Order", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Bundle", "Bundle")
                        .WithMany("Bundle_Orders")
                        .HasForeignKey("Bundle_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Customer", "Customer")
                        .WithMany("Bundle_Orders")
                        .HasForeignKey("Cus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bundle");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle_Review", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Bundle", "Bundle")
                        .WithMany("Bundle_Reviews")
                        .HasForeignKey("Bundle_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Customer", "Customer")
                        .WithMany("Bundle_Reviews")
                        .HasForeignKey("Cus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bundle");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle_Wish_List", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Bundle", "Bundle")
                        .WithMany("Bundle_Wish_Lists")
                        .HasForeignKey("Bundle_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Wish_List", "Wish_List")
                        .WithMany("Bundle_Wish_Lists")
                        .HasForeignKey("W_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bundle");

                    b.Navigation("Wish_List");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Category", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Adminstrator", "Adminstrator")
                        .WithMany("Categories")
                        .HasForeignKey("Admin_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adminstrator");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Customer", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Cart", "Cart")
                        .WithMany("Customers")
                        .HasForeignKey("Cart_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Wish_List", "Wish_List")
                        .WithMany("customers")
                        .HasForeignKey("Cus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Wish_List");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Adminstrator", "Adminstrator")
                        .WithMany("Products")
                        .HasForeignKey("Admin_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.SubCatagory", "SubCatagory")
                        .WithMany("Products")
                        .HasForeignKey("Sub_C_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adminstrator");

                    b.Navigation("SubCatagory");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Bundle", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Bundle", "Bundle")
                        .WithMany("product_Bundles")
                        .HasForeignKey("Bundle_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Product", "Product")
                        .WithMany("product_Bundles")
                        .HasForeignKey("P_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bundle");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Cart", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Cart", "Cart")
                        .WithMany("product_Carts")
                        .HasForeignKey("Cart_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Product", "Product")
                        .WithMany("product_Carts")
                        .HasForeignKey("P_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Order", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Customer", "Customer")
                        .WithMany("Product_Orders")
                        .HasForeignKey("Cus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Product", "Product")
                        .WithMany("Product_Orders")
                        .HasForeignKey("P_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Review", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Customer", "Customer")
                        .WithMany("Product_Reviews")
                        .HasForeignKey("Cus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Product", "Product")
                        .WithMany("Product_Reviews")
                        .HasForeignKey("P_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product_Wish_List", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Product", "Product")
                        .WithMany("product_Wish_Lists")
                        .HasForeignKey("P_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Wish_List", "Wish_List")
                        .WithMany("product_Wish_Lists")
                        .HasForeignKey("W_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Wish_List");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.SubCatagory", b =>
                {
                    b.HasOne("مشروع_التخرج.Models.Adminstrator", "Adminstrator")
                        .WithMany("SubCatagories")
                        .HasForeignKey("Admin_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("مشروع_التخرج.Models.Category", "Category")
                        .WithMany("SubCatagories")
                        .HasForeignKey("C_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adminstrator");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Adminstrator", b =>
                {
                    b.Navigation("Bundles");

                    b.Navigation("Categories");

                    b.Navigation("Products");

                    b.Navigation("SubCatagories");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Bundle", b =>
                {
                    b.Navigation("Bundle_Carts");

                    b.Navigation("Bundle_Orders");

                    b.Navigation("Bundle_Reviews");

                    b.Navigation("Bundle_Wish_Lists");

                    b.Navigation("product_Bundles");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Cart", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("bundle_Carts");

                    b.Navigation("product_Carts");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Category", b =>
                {
                    b.Navigation("SubCatagories");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Customer", b =>
                {
                    b.Navigation("Bundle_Orders");

                    b.Navigation("Bundle_Reviews");

                    b.Navigation("Product_Orders");

                    b.Navigation("Product_Reviews");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Product", b =>
                {
                    b.Navigation("Product_Orders");

                    b.Navigation("Product_Reviews");

                    b.Navigation("product_Bundles");

                    b.Navigation("product_Carts");

                    b.Navigation("product_Wish_Lists");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.SubCatagory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("مشروع_التخرج.Models.Wish_List", b =>
                {
                    b.Navigation("Bundle_Wish_Lists");

                    b.Navigation("customers");

                    b.Navigation("product_Wish_Lists");
                });
#pragma warning restore 612, 618
        }
    }
}