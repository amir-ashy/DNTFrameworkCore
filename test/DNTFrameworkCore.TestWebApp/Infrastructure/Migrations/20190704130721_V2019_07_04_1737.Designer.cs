﻿// <auto-generated />
using System;
using DNTFrameworkCore.TestWebApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DNTFrameworkCore.TestWebApp.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20190704130721_V2019_07_04_1737")]
    partial class V2019_07_04_1737
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DNTFrameworkCore.Caching.Cache", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(449);

                    b.Property<DateTimeOffset?>("AbsoluteExpiration");

                    b.Property<DateTimeOffset>("ExpiresAtTime");

                    b.Property<long?>("SlidingExpirationInSeconds");

                    b.Property<byte[]>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ExpiresAtTime")
                        .HasDatabaseName("IX_Cache_ExpiresAtTime");

                    b.ToTable("Cache","dbo");
                });

            modelBuilder.Entity("DNTFrameworkCore.Cryptography.ProtectionKey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FriendlyName")
                        .IsRequired();

                    b.Property<string>("XmlValue");

                    b.HasKey("Id");

                    b.HasIndex("FriendlyName")
                        .IsUnique()
                        .HasDatabaseName("IX_ProtectionKey_FriendlyName");

                    b.ToTable("ProtectionKey","dbo");
                });

            modelBuilder.Entity("DNTFrameworkCore.Logging.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LoggerName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<DateTimeOffset>("Timestamp");

                    b.Property<string>("UserBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("UserDisplayName")
                        .HasMaxLength(50);

                    b.Property<string>("UserIP")
                        .HasMaxLength(256);

                    b.Property<long?>("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Level")
                        .HasDatabaseName("IX_Log_Level");

                    b.HasIndex("LoggerName")
                        .HasDatabaseName("IX_Log_LoggerName");

                    b.ToTable("Log","dbo");
                });

            modelBuilder.Entity("DNTFrameworkCore.Numbering.NumberedEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<long>("NextNumber");

                    b.HasKey("Id");

                    b.HasIndex("EntityName")
                        .IsUnique()
                        .HasDatabaseName("UIX_NumberedEntity_EntityName");

                    b.ToTable("NumberedEntity");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Blogging.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedTitle")
                        .IsUnique()
                        .HasDatabaseName("Blog_NormalizedTitle");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Catalog.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("Number");

                    b.Property<decimal>("Price");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsGranted");

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("Discriminator")
                        .HasDatabaseName("IX_Permission_Discriminator");

                    b.ToTable("Permission");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Permission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("UIX_Role_NormalizedName");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<DateTimeOffset?>("LastLoggedInDateTime");

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("NormalizedDisplayName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedDisplayName")
                        .IsUnique()
                        .HasDatabaseName("UIX_User_NormalizedDisplayName");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UIX_User_NormalizedUserName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<long>("RoleId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Tasks.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Number");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<byte>("State");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedTitle")
                        .IsUnique()
                        .HasDatabaseName("UIX_Task_NormalizedTitle");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.RolePermission", b =>
                {
                    b.HasBaseType("DNTFrameworkCore.TestWebApp.Domain.Identity.Permission");

                    b.Property<long>("RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permission");

                    b.HasDiscriminator().HasValue("RolePermission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.UserPermission", b =>
                {
                    b.HasBaseType("DNTFrameworkCore.TestWebApp.Domain.Identity.Permission");

                    b.Property<long>("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Permission");

                    b.HasDiscriminator().HasValue("UserPermission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.RoleClaim", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestWebApp.Domain.Identity.Role", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.UserClaim", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestWebApp.Domain.Identity.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.UserRole", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestWebApp.Domain.Identity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DNTFrameworkCore.TestWebApp.Domain.Identity.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.RolePermission", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestWebApp.Domain.Identity.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestWebApp.Domain.Identity.UserPermission", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestWebApp.Domain.Identity.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
