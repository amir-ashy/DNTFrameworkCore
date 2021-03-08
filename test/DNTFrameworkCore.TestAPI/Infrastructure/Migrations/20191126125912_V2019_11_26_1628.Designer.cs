﻿// <auto-generated />
using System;
using DNTFrameworkCore.TestAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DNTFrameworkCore.TestAPI.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20191126125912_V2019_11_26_1628")]
    partial class V2019_11_26_1628
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DNTFrameworkCore.Caching.Cache", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(449)")
                        .HasMaxLength(449);

                    b.Property<DateTimeOffset?>("AbsoluteExpiration")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ExpiresAtTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("SlidingExpirationInSeconds")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("Value")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExpiresAtTime")
                        .HasDatabaseName("IX_Cache_ExpiresAtTime");

                    b.ToTable("Cache","dbo");
                });

            modelBuilder.Entity("DNTFrameworkCore.Cryptography.ProtectionKey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FriendlyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("XmlValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FriendlyName")
                        .IsUnique()
                        .HasDatabaseName("IX_ProtectionKey_FriendlyName");

                    b.ToTable("ProtectionKey","dbo");
                });

            modelBuilder.Entity("DNTFrameworkCore.Logging.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ImpersonatorTenantId")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ImpersonatorUserId")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LoggerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("TenantName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("UserDisplayName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserIP")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<long>("NextNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EntityName")
                        .IsUnique()
                        .HasDatabaseName("UIX_NumberedEntity_EntityName");

                    b.ToTable("NumberedEntity");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Blogging.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModificationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedTitle")
                        .IsUnique()
                        .HasDatabaseName("Blog_NormalizedTitle");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsGranted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("Discriminator")
                        .HasDatabaseName("IX_Permission_Discriminator");

                    b.ToTable("Permission");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Permission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<DateTime?>("ModificationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("UIX_Role_NormalizedName");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastLoggedInDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModificationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("NormalizedDisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedDisplayName")
                        .IsUnique()
                        .HasDatabaseName("UIX_User_NormalizedDisplayName");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UIX_User_NormalizedUserName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("TokenExpirationDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TokenHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TokenHash")
                        .HasDatabaseName("IX_UserToken_TokenHash");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Tasks.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BranchId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<DateTime?>("ModificationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierBrowserName")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedTitle")
                        .IsUnique()
                        .HasDatabaseName("UIX_Task_NormalizedTitle");

                    b.HasIndex("Number", "BranchId")
                        .HasDatabaseName("UIX_Task_Number_BranchId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.RolePermission", b =>
                {
                    b.HasBaseType("DNTFrameworkCore.TestAPI.Domain.Identity.Permission");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasIndex("RoleId");

                    b.HasDiscriminator().HasValue("RolePermission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserPermission", b =>
                {
                    b.HasBaseType("DNTFrameworkCore.TestAPI.Domain.Identity.Permission");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("UserPermission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.RoleClaim", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.Role", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserClaim", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserRole", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserToken", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.RolePermission", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserPermission", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
