IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Adminstrators] (
        [Admin_Id] int NOT NULL IDENTITY,
        [Admin_Name] nvarchar(100) NOT NULL,
        [Admin_Type] nvarchar(max) NOT NULL,
        [Admin_Email] nvarchar(max) NOT NULL,
        [Admin_Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Adminstrators] PRIMARY KEY ([Admin_Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Carts] (
        [Cart_Id] int NOT NULL IDENTITY,
        [Cart_Quantity] int NOT NULL,
        [Cart_Total_Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Carts] PRIMARY KEY ([Cart_Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Wish_Lists] (
        [W_Id] int NOT NULL IDENTITY,
        [data] datetime2 NOT NULL,
        CONSTRAINT [PK_Wish_Lists] PRIMARY KEY ([W_Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Bundles] (
        [Bundle_Id] int NOT NULL IDENTITY,
        [Bundle_Price] int NOT NULL,
        [Bundle_image] varbinary(max) NOT NULL,
        [Bundle_Description] nvarchar(max) NOT NULL,
        [Admin_Id] int NOT NULL,
        CONSTRAINT [PK_Bundles] PRIMARY KEY ([Bundle_Id]),
        CONSTRAINT [FK_Bundles_Adminstrators_Admin_Id] FOREIGN KEY ([Admin_Id]) REFERENCES [Adminstrators] ([Admin_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Categories] (
        [C_Id] int NOT NULL IDENTITY,
        [C_Name] nvarchar(max) NOT NULL,
        [C_Image] varbinary(max) NOT NULL,
        [C_Description] nvarchar(max) NOT NULL,
        [Admin_Id] int NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([C_Id]),
        CONSTRAINT [FK_Categories_Adminstrators_Admin_Id] FOREIGN KEY ([Admin_Id]) REFERENCES [Adminstrators] ([Admin_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Customers] (
        [Cus_Id] int NOT NULL,
        [Cus_firstName] nvarchar(max) NOT NULL,
        [Cus_lastName] nvarchar(max) NOT NULL,
        [Cus_phone] nvarchar(max) NOT NULL,
        [Cus_Email] nvarchar(max) NOT NULL,
        [Cus_Passaword] nvarchar(max) NOT NULL,
        [Cus_Country] nvarchar(max) NOT NULL,
        [Cus_City] nvarchar(max) NOT NULL,
        [Cus_Street] nvarchar(max) NOT NULL,
        [Cart_Id] int NOT NULL,
        [W_Id] int NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Cus_Id]),
        CONSTRAINT [FK_Customers_Carts_Cart_Id] FOREIGN KEY ([Cart_Id]) REFERENCES [Carts] ([Cart_Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Customers_Wish_Lists_Cus_Id] FOREIGN KEY ([Cus_Id]) REFERENCES [Wish_Lists] ([W_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Bundle_Carts] (
        [Bundle_Id] int NOT NULL,
        [Cart_Id] int NOT NULL,
        CONSTRAINT [PK_Bundle_Carts] PRIMARY KEY ([Bundle_Id], [Cart_Id]),
        CONSTRAINT [FK_Bundle_Carts_Bundles_Bundle_Id] FOREIGN KEY ([Bundle_Id]) REFERENCES [Bundles] ([Bundle_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Bundle_Carts_Carts_Cart_Id] FOREIGN KEY ([Cart_Id]) REFERENCES [Carts] ([Cart_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Bundle_Wish_Lists] (
        [W_Id] int NOT NULL,
        [Bundle_Id] int NOT NULL,
        CONSTRAINT [PK_Bundle_Wish_Lists] PRIMARY KEY ([W_Id], [Bundle_Id]),
        CONSTRAINT [FK_Bundle_Wish_Lists_Bundles_Bundle_Id] FOREIGN KEY ([Bundle_Id]) REFERENCES [Bundles] ([Bundle_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Bundle_Wish_Lists_Wish_Lists_W_Id] FOREIGN KEY ([W_Id]) REFERENCES [Wish_Lists] ([W_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [SubCatagories] (
        [Sub_C_Id] int NOT NULL IDENTITY,
        [Sub_C_image] varbinary(max) NOT NULL,
        [sub_c_Description] nvarchar(max) NOT NULL,
        [Admin_Id] int NOT NULL,
        [C_Id] int NOT NULL,
        CONSTRAINT [PK_SubCatagories] PRIMARY KEY ([Sub_C_Id]),
        CONSTRAINT [FK_SubCatagories_Adminstrators_Admin_Id] FOREIGN KEY ([Admin_Id]) REFERENCES [Adminstrators] ([Admin_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_SubCatagories_Categories_C_Id] FOREIGN KEY ([C_Id]) REFERENCES [Categories] ([C_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Bundle_Orders] (
        [B_Order_Id] int NOT NULL IDENTITY,
        [Order_status] nvarchar(max) NOT NULL,
        [data] datetime2 NOT NULL,
        [Bundle_Id] int NOT NULL,
        [Cus_Id] int NOT NULL,
        CONSTRAINT [PK_Bundle_Orders] PRIMARY KEY ([B_Order_Id]),
        CONSTRAINT [FK_Bundle_Orders_Bundles_Bundle_Id] FOREIGN KEY ([Bundle_Id]) REFERENCES [Bundles] ([Bundle_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Bundle_Orders_Customers_Cus_Id] FOREIGN KEY ([Cus_Id]) REFERENCES [Customers] ([Cus_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Bundle_Reviews] (
        [B_Review_Id] int NOT NULL IDENTITY,
        [B_Review_Comment] nvarchar(max) NOT NULL,
        [Reting] int NOT NULL,
        [Cus_Id] int NOT NULL,
        [Bundle_Id] int NOT NULL,
        CONSTRAINT [PK_Bundle_Reviews] PRIMARY KEY ([B_Review_Id]),
        CONSTRAINT [FK_Bundle_Reviews_Bundles_Bundle_Id] FOREIGN KEY ([Bundle_Id]) REFERENCES [Bundles] ([Bundle_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Bundle_Reviews_Customers_Cus_Id] FOREIGN KEY ([Cus_Id]) REFERENCES [Customers] ([Cus_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Products] (
        [P_Id] int NOT NULL IDENTITY,
        [P_Name] nvarchar(max) NOT NULL,
        [P_Description] nvarchar(max) NOT NULL,
        [p_Image] varbinary(max) NOT NULL,
        [P_Price] decimal(18,2) NOT NULL,
        [P_Quantity] int NOT NULL,
        [Admin_Id] int NOT NULL,
        [Sub_C_Id] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([P_Id]),
        CONSTRAINT [FK_Products_Adminstrators_Admin_Id] FOREIGN KEY ([Admin_Id]) REFERENCES [Adminstrators] ([Admin_Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Products_SubCatagories_Sub_C_Id] FOREIGN KEY ([Sub_C_Id]) REFERENCES [SubCatagories] ([Sub_C_Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Product_Bundles] (
        [P_Id] int NOT NULL,
        [Bundle_Id] int NOT NULL,
        CONSTRAINT [PK_Product_Bundles] PRIMARY KEY ([P_Id], [Bundle_Id]),
        CONSTRAINT [FK_Product_Bundles_Bundles_Bundle_Id] FOREIGN KEY ([Bundle_Id]) REFERENCES [Bundles] ([Bundle_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Product_Bundles_Products_P_Id] FOREIGN KEY ([P_Id]) REFERENCES [Products] ([P_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Product_Carts] (
        [P_Id] int NOT NULL,
        [Cart_Id] int NOT NULL,
        CONSTRAINT [PK_Product_Carts] PRIMARY KEY ([P_Id], [Cart_Id]),
        CONSTRAINT [FK_Product_Carts_Carts_Cart_Id] FOREIGN KEY ([Cart_Id]) REFERENCES [Carts] ([Cart_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Product_Carts_Products_P_Id] FOREIGN KEY ([P_Id]) REFERENCES [Products] ([P_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Product_Orders] (
        [Order_Id] int NOT NULL IDENTITY,
        [Order_status] nvarchar(max) NOT NULL,
        [data] datetime2 NOT NULL,
        [Cus_Id] int NOT NULL,
        [P_Id] int NOT NULL,
        CONSTRAINT [PK_Product_Orders] PRIMARY KEY ([Order_Id]),
        CONSTRAINT [FK_Product_Orders_Customers_Cus_Id] FOREIGN KEY ([Cus_Id]) REFERENCES [Customers] ([Cus_Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Product_Orders_Products_P_Id] FOREIGN KEY ([P_Id]) REFERENCES [Products] ([P_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Product_Reviews] (
        [Review_Id] int NOT NULL IDENTITY,
        [comment] nvarchar(max) NOT NULL,
        [rating] int NOT NULL,
        [Cus_Id] int NOT NULL,
        [P_Id] int NOT NULL,
        CONSTRAINT [PK_Product_Reviews] PRIMARY KEY ([Review_Id]),
        CONSTRAINT [FK_Product_Reviews_Customers_Cus_Id] FOREIGN KEY ([Cus_Id]) REFERENCES [Customers] ([Cus_Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Product_Reviews_Products_P_Id] FOREIGN KEY ([P_Id]) REFERENCES [Products] ([P_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE TABLE [Product_Wish_Lists] (
        [W_Id] int NOT NULL,
        [P_Id] int NOT NULL,
        CONSTRAINT [PK_Product_Wish_Lists] PRIMARY KEY ([P_Id], [W_Id]),
        CONSTRAINT [FK_Product_Wish_Lists_Products_P_Id] FOREIGN KEY ([P_Id]) REFERENCES [Products] ([P_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Product_Wish_Lists_Wish_Lists_W_Id] FOREIGN KEY ([W_Id]) REFERENCES [Wish_Lists] ([W_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Bundle_Carts_Cart_Id] ON [Bundle_Carts] ([Cart_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Bundle_Orders_Bundle_Id] ON [Bundle_Orders] ([Bundle_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Bundle_Orders_Cus_Id] ON [Bundle_Orders] ([Cus_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Bundle_Reviews_Bundle_Id] ON [Bundle_Reviews] ([Bundle_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Bundle_Reviews_Cus_Id] ON [Bundle_Reviews] ([Cus_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Bundle_Wish_Lists_Bundle_Id] ON [Bundle_Wish_Lists] ([Bundle_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Bundles_Admin_Id] ON [Bundles] ([Admin_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Categories_Admin_Id] ON [Categories] ([Admin_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Customers_Cart_Id] ON [Customers] ([Cart_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Product_Bundles_Bundle_Id] ON [Product_Bundles] ([Bundle_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Product_Carts_Cart_Id] ON [Product_Carts] ([Cart_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Product_Orders_Cus_Id] ON [Product_Orders] ([Cus_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Product_Orders_P_Id] ON [Product_Orders] ([P_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Product_Reviews_Cus_Id] ON [Product_Reviews] ([Cus_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Product_Reviews_P_Id] ON [Product_Reviews] ([P_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Product_Wish_Lists_W_Id] ON [Product_Wish_Lists] ([W_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Products_Admin_Id] ON [Products] ([Admin_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_Products_Sub_C_Id] ON [Products] ([Sub_C_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_SubCatagories_Admin_Id] ON [SubCatagories] ([Admin_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    CREATE INDEX [IX_SubCatagories_C_Id] ON [SubCatagories] ([C_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240222101427_Project')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240222101427_Project', N'6.0.27');
END;
GO

COMMIT;
GO

