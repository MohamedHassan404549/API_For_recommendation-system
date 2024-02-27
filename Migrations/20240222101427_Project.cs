using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace مشروع_التخرج.Migrations
{
    public partial class Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminstrators",
                columns: table => new
                {
                    Admin_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Admin_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminstrators", x => x.Admin_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Cart_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cart_Quantity = table.Column<int>(type: "int", nullable: false),
                    Cart_Total_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Cart_Id);
                });

            migrationBuilder.CreateTable(
                name: "Wish_Lists",
                columns: table => new
                {
                    W_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wish_Lists", x => x.W_Id);
                });

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Bundle_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bundle_Price = table.Column<int>(type: "int", nullable: false),
                    Bundle_image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Bundle_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Bundle_Id);
                    table.ForeignKey(
                        name: "FK_Bundles_Adminstrators_Admin_Id",
                        column: x => x.Admin_Id,
                        principalTable: "Adminstrators",
                        principalColumn: "Admin_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    C_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.C_Id);
                    table.ForeignKey(
                        name: "FK_Categories_Adminstrators_Admin_Id",
                        column: x => x.Admin_Id,
                        principalTable: "Adminstrators",
                        principalColumn: "Admin_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Cus_Id = table.Column<int>(type: "int", nullable: false),
                    Cus_firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cus_lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cus_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cus_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cus_Passaword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cus_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cus_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cus_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cart_Id = table.Column<int>(type: "int", nullable: false),
                    W_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Cus_Id);
                    table.ForeignKey(
                        name: "FK_Customers_Carts_Cart_Id",
                        column: x => x.Cart_Id,
                        principalTable: "Carts",
                        principalColumn: "Cart_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Wish_Lists_Cus_Id",
                        column: x => x.Cus_Id,
                        principalTable: "Wish_Lists",
                        principalColumn: "W_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bundle_Carts",
                columns: table => new
                {
                    Bundle_Id = table.Column<int>(type: "int", nullable: false),
                    Cart_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundle_Carts", x => new { x.Bundle_Id, x.Cart_Id });
                    table.ForeignKey(
                        name: "FK_Bundle_Carts_Bundles_Bundle_Id",
                        column: x => x.Bundle_Id,
                        principalTable: "Bundles",
                        principalColumn: "Bundle_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bundle_Carts_Carts_Cart_Id",
                        column: x => x.Cart_Id,
                        principalTable: "Carts",
                        principalColumn: "Cart_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bundle_Wish_Lists",
                columns: table => new
                {
                    W_Id = table.Column<int>(type: "int", nullable: false),
                    Bundle_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundle_Wish_Lists", x => new { x.W_Id, x.Bundle_Id });
                    table.ForeignKey(
                        name: "FK_Bundle_Wish_Lists_Bundles_Bundle_Id",
                        column: x => x.Bundle_Id,
                        principalTable: "Bundles",
                        principalColumn: "Bundle_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bundle_Wish_Lists_Wish_Lists_W_Id",
                        column: x => x.W_Id,
                        principalTable: "Wish_Lists",
                        principalColumn: "W_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCatagories",
                columns: table => new
                {
                    Sub_C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sub_C_image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    sub_c_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Id = table.Column<int>(type: "int", nullable: false),
                    C_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCatagories", x => x.Sub_C_Id);
                    table.ForeignKey(
                        name: "FK_SubCatagories_Adminstrators_Admin_Id",
                        column: x => x.Admin_Id,
                        principalTable: "Adminstrators",
                        principalColumn: "Admin_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCatagories_Categories_C_Id",
                        column: x => x.C_Id,
                        principalTable: "Categories",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bundle_Orders",
                columns: table => new
                {
                    B_Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bundle_Id = table.Column<int>(type: "int", nullable: false),
                    Cus_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundle_Orders", x => x.B_Order_Id);
                    table.ForeignKey(
                        name: "FK_Bundle_Orders_Bundles_Bundle_Id",
                        column: x => x.Bundle_Id,
                        principalTable: "Bundles",
                        principalColumn: "Bundle_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bundle_Orders_Customers_Cus_Id",
                        column: x => x.Cus_Id,
                        principalTable: "Customers",
                        principalColumn: "Cus_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bundle_Reviews",
                columns: table => new
                {
                    B_Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B_Review_Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reting = table.Column<int>(type: "int", nullable: false),
                    Cus_Id = table.Column<int>(type: "int", nullable: false),
                    Bundle_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundle_Reviews", x => x.B_Review_Id);
                    table.ForeignKey(
                        name: "FK_Bundle_Reviews_Bundles_Bundle_Id",
                        column: x => x.Bundle_Id,
                        principalTable: "Bundles",
                        principalColumn: "Bundle_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bundle_Reviews_Customers_Cus_Id",
                        column: x => x.Cus_Id,
                        principalTable: "Customers",
                        principalColumn: "Cus_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    P_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    P_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    P_Quantity = table.Column<int>(type: "int", nullable: false),
                    Admin_Id = table.Column<int>(type: "int", nullable: false),
                    Sub_C_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.P_Id);
                    table.ForeignKey(
                        name: "FK_Products_Adminstrators_Admin_Id",
                        column: x => x.Admin_Id,
                        principalTable: "Adminstrators",
                        principalColumn: "Admin_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubCatagories_Sub_C_Id",
                        column: x => x.Sub_C_Id,
                        principalTable: "SubCatagories",
                        principalColumn: "Sub_C_Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_Bundles",
                columns: table => new
                {
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    Bundle_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Bundles", x => new { x.P_Id, x.Bundle_Id });
                    table.ForeignKey(
                        name: "FK_Product_Bundles_Bundles_Bundle_Id",
                        column: x => x.Bundle_Id,
                        principalTable: "Bundles",
                        principalColumn: "Bundle_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Bundles_Products_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Products",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Carts",
                columns: table => new
                {
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    Cart_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Carts", x => new { x.P_Id, x.Cart_Id });
                    table.ForeignKey(
                        name: "FK_Product_Carts_Carts_Cart_Id",
                        column: x => x.Cart_Id,
                        principalTable: "Carts",
                        principalColumn: "Cart_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Carts_Products_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Products",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cus_Id = table.Column<int>(type: "int", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Orders", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_Product_Orders_Customers_Cus_Id",
                        column: x => x.Cus_Id,
                        principalTable: "Customers",
                        principalColumn: "Cus_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Orders_Products_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Products",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Reviews",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    Cus_Id = table.Column<int>(type: "int", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Reviews", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Product_Reviews_Customers_Cus_Id",
                        column: x => x.Cus_Id,
                        principalTable: "Customers",
                        principalColumn: "Cus_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Reviews_Products_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Products",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Wish_Lists",
                columns: table => new
                {
                    W_Id = table.Column<int>(type: "int", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Wish_Lists", x => new { x.P_Id, x.W_Id });
                    table.ForeignKey(
                        name: "FK_Product_Wish_Lists_Products_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Products",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Wish_Lists_Wish_Lists_W_Id",
                        column: x => x.W_Id,
                        principalTable: "Wish_Lists",
                        principalColumn: "W_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_Carts_Cart_Id",
                table: "Bundle_Carts",
                column: "Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_Orders_Bundle_Id",
                table: "Bundle_Orders",
                column: "Bundle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_Orders_Cus_Id",
                table: "Bundle_Orders",
                column: "Cus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_Reviews_Bundle_Id",
                table: "Bundle_Reviews",
                column: "Bundle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_Reviews_Cus_Id",
                table: "Bundle_Reviews",
                column: "Cus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_Wish_Lists_Bundle_Id",
                table: "Bundle_Wish_Lists",
                column: "Bundle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bundles_Admin_Id",
                table: "Bundles",
                column: "Admin_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Admin_Id",
                table: "Categories",
                column: "Admin_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Cart_Id",
                table: "Customers",
                column: "Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Bundles_Bundle_Id",
                table: "Product_Bundles",
                column: "Bundle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Carts_Cart_Id",
                table: "Product_Carts",
                column: "Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_Cus_Id",
                table: "Product_Orders",
                column: "Cus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_P_Id",
                table: "Product_Orders",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Reviews_Cus_Id",
                table: "Product_Reviews",
                column: "Cus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Reviews_P_Id",
                table: "Product_Reviews",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Wish_Lists_W_Id",
                table: "Product_Wish_Lists",
                column: "W_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Admin_Id",
                table: "Products",
                column: "Admin_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sub_C_Id",
                table: "Products",
                column: "Sub_C_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCatagories_Admin_Id",
                table: "SubCatagories",
                column: "Admin_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCatagories_C_Id",
                table: "SubCatagories",
                column: "C_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bundle_Carts");

            migrationBuilder.DropTable(
                name: "Bundle_Orders");

            migrationBuilder.DropTable(
                name: "Bundle_Reviews");

            migrationBuilder.DropTable(
                name: "Bundle_Wish_Lists");

            migrationBuilder.DropTable(
                name: "Product_Bundles");

            migrationBuilder.DropTable(
                name: "Product_Carts");

            migrationBuilder.DropTable(
                name: "Product_Orders");

            migrationBuilder.DropTable(
                name: "Product_Reviews");

            migrationBuilder.DropTable(
                name: "Product_Wish_Lists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Wish_Lists");

            migrationBuilder.DropTable(
                name: "SubCatagories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Adminstrators");
        }
    }
}
