﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ribbons.Loyalty.Data.Databases;

#nullable disable

namespace Ribbons.Loyalty.Data.Migrations.PartnerDbMigrations.Sqlite
{
    [DbContext(typeof(PartnerDbSqlite))]
    partial class PartnerDbSqliteModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("Ribbons.Loyalty.Data.Partner", b =>
                {
                    b.Property<long>("PartnerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("partner_id");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT")
                        .HasColumnName("account_number");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT")
                        .HasColumnName("alias");

                    b.Property<string>("BillingAddress")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("billing_address");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(2)
                        .HasColumnType("TEXT")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_date");

                    b.Property<int>("DbServerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("db_server_id");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("State")
                        .HasMaxLength(5)
                        .HasColumnType("TEXT")
                        .HasColumnName("state");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("status");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("zipcode");

                    b.HasKey("PartnerId");

                    b.HasIndex("AccountNumber")
                        .IsUnique();

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.HasIndex("City");

                    b.HasIndex("Country");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("DbServerId");

                    b.HasIndex("ModifiedDate");

                    b.HasIndex("State");

                    b.HasIndex("Status");

                    b.HasIndex("ZipCode");

                    b.ToTable("t_partner");
                });

            modelBuilder.Entity("Ribbons.Users.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_date");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("modified_date");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("status");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("TEXT")
                        .HasColumnName("username");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("INTEGER")
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
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("TEXT")
                        .HasColumnName("email_address");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_verified");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("modified_date");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_type_id");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("TEXT")
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
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("expiry_date");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_expired");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("modified_date");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("BLOB")
                        .HasColumnName("password_hash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("BLOB")
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
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_verified");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("modified_date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("phone_number");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_type_id");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("TEXT")
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
                        .HasColumnType("BLOB")
                        .HasColumnName("user_session_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("expiry_date");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_expired");

                    b.Property<bool>("IsLoggedOut")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_logged_out");

                    b.Property<DateTime?>("LogoutDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("logout_date");

                    b.Property<byte[]>("SessionSecretHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("BLOB")
                        .HasColumnName("session_secret_hash");

                    b.Property<byte[]>("SessionSecretSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("BLOB")
                        .HasColumnName("session_secret_salt");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER")
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
                        .HasColumnType("BLOB")
                        .HasColumnName("user_token_id");

                    b.Property<DateTime?>("ConsumedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("consumed_date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("expiry_date");

                    b.Property<bool>("IsConsumed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_consumed");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_expired");

                    b.Property<byte[]>("TokenSecretHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("BLOB")
                        .HasColumnName("token_secret_hash");

                    b.Property<byte[]>("TokenSecretSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("BLOB")
                        .HasColumnName("token_secret_salt");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER")
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
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_type_id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("UserTypeId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("t_user_type");

                    b.HasData(
                        new
                        {
                            UserTypeId = 2,
                            Code = "partner_admin",
                            Description = "Partner administrator. Manages settings for the partner",
                            Name = "Partner Administrator"
                        },
                        new
                        {
                            UserTypeId = 3,
                            Code = "member",
                            Description = "Members who signed up for this partners' loyalty programs",
                            Name = "Member"
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
