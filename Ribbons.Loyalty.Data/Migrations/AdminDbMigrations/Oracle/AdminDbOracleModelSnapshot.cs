﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using Ribbons.Loyalty.Data.Databases;

#nullable disable

namespace Ribbons.Loyalty.Data.Migrations.AdminDbMigrations.Oracle
{
    [DbContext(typeof(AdminDbOracle))]
    partial class AdminDbOracleModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ribbons.Loyalty.Data.DbServer", b =>
                {
                    b.Property<long>("DbServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("db_server_id");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DbServerId"));

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("connection_string");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("name");

                    b.Property<int>("Provider")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("provider");

                    b.HasKey("DbServerId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Provider");

                    b.ToTable("t_db_server");

                    b.HasData(
                        new
                        {
                            DbServerId = 1L,
                            ConnectionString = "server=localhost;user id=sa;password=ASD123!@#;trustservercertificate=true",
                            Name = "localhost",
                            Provider = 1
                        },
                        new
                        {
                            DbServerId = 2L,
                            ConnectionString = "server=host.docker.internal;user id=sa;password=ASD123!@#;trustservercertificate=true",
                            Name = "host.docker.internal",
                            Provider = 1
                        });
                });

            modelBuilder.Entity("Ribbons.Loyalty.Data.Partner", b =>
                {
                    b.Property<long>("PartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("partner_id");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PartnerId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("NVARCHAR2(12)")
                        .HasColumnName("account_number");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR2(128)")
                        .HasColumnName("alias");

                    b.Property<string>("BillingAddress")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("billing_address");

                    b.Property<string>("BusinessName")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("business_name");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(2)
                        .HasColumnType("NVARCHAR2(2)")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("name");

                    b.Property<string>("State")
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR2(5)")
                        .HasColumnName("state");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("status");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("zipcode");

                    b.HasKey("PartnerId");

                    b.HasIndex("AccountNumber")
                        .IsUnique();

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.HasIndex("City");

                    b.HasIndex("Country");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("ModifiedDate");

                    b.HasIndex("State");

                    b.HasIndex("Status");

                    b.HasIndex("ZipCode");

                    b.ToTable("t_partner");
                });

            modelBuilder.Entity("Ribbons.Loyalty.Data.PartnerDbConfig", b =>
                {
                    b.Property<long>("PartnerId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("partner_id");

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("connection_string");

                    b.Property<int>("Provider")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("provider");

                    b.HasKey("PartnerId");

                    b.HasIndex("Provider");

                    b.ToTable("t_partner_db_config");
                });

            modelBuilder.Entity("Ribbons.Loyalty.Data.PartnerDeployment", b =>
                {
                    b.Property<long>("PartnerDeploymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("partner_deployment_id");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PartnerDeploymentId"));

                    b.Property<DateTime?>("DbMigrationFinishDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("db_migration_finish_date");

                    b.Property<DateTime?>("DbMigrationStartDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("db_migration_start_date");

                    b.Property<int?>("DbMigrationStatus")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("db_migration_status");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("finish_date");

                    b.Property<long>("PartnerId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("partner_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("start_date");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("status");

                    b.HasKey("PartnerDeploymentId");

                    b.HasIndex("DbMigrationFinishDate");

                    b.HasIndex("DbMigrationStartDate");

                    b.HasIndex("DbMigrationStatus");

                    b.HasIndex("FinishDate");

                    b.HasIndex("PartnerId");

                    b.HasIndex("StartDate");

                    b.HasIndex("Status");

                    b.ToTable("t_partner_deployment");
                });

            modelBuilder.Entity("Ribbons.Users.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("user_id");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("created_date");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("modified_date");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("status");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("NVARCHAR2(320)")
                        .HasColumnName("username");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("user_type_id");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("ModifiedDate");

                    b.HasIndex("Status");

                    b.HasIndex("UserName");

                    b.HasIndex("UserTypeId");

                    b.HasIndex("UserTypeId", "UserName")
                        .IsUnique();

                    b.ToTable("t_user");
                });

            modelBuilder.Entity("Ribbons.Users.UserEmail", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("created_date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("NVARCHAR2(320)")
                        .HasColumnName("email_address");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("is_verified");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("modified_date");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("user_type_id");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("verified_date");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("EmailAddress");

                    b.HasIndex("IsVerified");

                    b.HasIndex("ModifiedDate");

                    b.HasIndex("UserTypeId");

                    b.HasIndex("VerifiedDate");

                    b.HasIndex("UserTypeId", "EmailAddress")
                        .IsUnique();

                    b.ToTable("t_user_email");
                });

            modelBuilder.Entity("Ribbons.Users.UserPassword", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("expiry_date");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("is_expired");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("modified_date");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("RAW(128)")
                        .HasColumnName("password_hash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("RAW(128)")
                        .HasColumnName("password_salt");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("ExpiryDate");

                    b.HasIndex("IsExpired");

                    b.HasIndex("ModifiedDate");

                    b.ToTable("t_user_password");
                });

            modelBuilder.Entity("Ribbons.Users.UserPhone", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("is_verified");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("modified_date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("phone_number");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("user_type_id");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("verified_date");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("IsVerified");

                    b.HasIndex("ModifiedDate");

                    b.HasIndex("PhoneNumber");

                    b.HasIndex("UserTypeId");

                    b.HasIndex("VerifiedDate");

                    b.HasIndex("UserTypeId", "PhoneNumber")
                        .IsUnique();

                    b.ToTable("t_user_phone");
                });

            modelBuilder.Entity("Ribbons.Users.UserSession", b =>
                {
                    b.Property<byte[]>("UserSessionId")
                        .HasMaxLength(128)
                        .HasColumnType("RAW(128)")
                        .HasColumnName("user_session_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("expiry_date");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("is_expired");

                    b.Property<bool>("IsLoggedOut")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("is_logged_out");

                    b.Property<DateTime?>("LogoutDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("logout_date");

                    b.Property<byte[]>("SessionSecretHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("RAW(128)")
                        .HasColumnName("session_secret_hash");

                    b.Property<byte[]>("SessionSecretSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("RAW(128)")
                        .HasColumnName("session_secret_salt");

                    b.Property<long>("UserId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("user_id");

                    b.HasKey("UserSessionId");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("ExpiryDate");

                    b.HasIndex("IsExpired");

                    b.HasIndex("IsLoggedOut");

                    b.HasIndex("LogoutDate");

                    b.HasIndex("UserId");

                    b.ToTable("t_user_session");
                });

            modelBuilder.Entity("Ribbons.Users.UserToken", b =>
                {
                    b.Property<byte[]>("UserTokenId")
                        .HasMaxLength(128)
                        .HasColumnType("RAW(128)")
                        .HasColumnName("user_token_id");

                    b.Property<DateTime?>("ConsumedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("consumed_date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("expiry_date");

                    b.Property<bool>("IsConsumed")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("is_consumed");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("is_expired");

                    b.Property<byte[]>("TokenSecretHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("RAW(128)")
                        .HasColumnName("token_secret_hash");

                    b.Property<byte[]>("TokenSecretSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("RAW(128)")
                        .HasColumnName("token_secret_salt");

                    b.Property<int>("Type")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("type");

                    b.Property<long>("UserId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("user_id");

                    b.HasKey("UserTokenId");

                    b.HasIndex("ConsumedDate");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("ExpiryDate");

                    b.HasIndex("IsConsumed");

                    b.HasIndex("IsExpired");

                    b.HasIndex("Type");

                    b.HasIndex("UserId");

                    b.ToTable("t_user_token");
                });

            modelBuilder.Entity("Ribbons.Users.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("user_type_id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("NVARCHAR2(64)")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("name");

                    b.HasKey("UserTypeId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("t_user_type");

                    b.HasData(
                        new
                        {
                            UserTypeId = 1,
                            Code = "admin",
                            Description = "System administrator. Manages global settings for the loyalty platform",
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("Ribbons.Users.User", b =>
                {
                    b.HasOne("Ribbons.Users.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Ribbons.Users.UserEmail", b =>
                {
                    b.HasOne("Ribbons.Users.User", "User")
                        .WithOne("UserEmail")
                        .HasForeignKey("Ribbons.Users.UserEmail", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Ribbons.Users.UserType", "UserType")
                        .WithMany("UserEmails")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Ribbons.Users.UserPassword", b =>
                {
                    b.HasOne("Ribbons.Users.User", "User")
                        .WithOne("UserPassword")
                        .HasForeignKey("Ribbons.Users.UserPassword", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ribbons.Users.UserPhone", b =>
                {
                    b.HasOne("Ribbons.Users.User", "User")
                        .WithOne("UserPhone")
                        .HasForeignKey("Ribbons.Users.UserPhone", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Ribbons.Users.UserType", "UserType")
                        .WithMany("UserPhones")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Ribbons.Users.UserSession", b =>
                {
                    b.HasOne("Ribbons.Users.User", "User")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ribbons.Users.UserToken", b =>
                {
                    b.HasOne("Ribbons.Users.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ribbons.Users.User", b =>
                {
                    b.Navigation("UserEmail");

                    b.Navigation("UserPassword");

                    b.Navigation("UserPhone");

                    b.Navigation("UserSessions");

                    b.Navigation("UserTokens");
                });

            modelBuilder.Entity("Ribbons.Users.UserType", b =>
                {
                    b.Navigation("UserEmails");

                    b.Navigation("UserPhones");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
