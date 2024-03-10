﻿using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Users;
using Ribbons.Users.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public abstract class PartnerDb : Database, IUserDatabase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected PartnerDb(DatabaseProvider provider) : base(provider) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .SetupUserModel()
                .HasData(new UserType
                {
                    UserTypeId = 2,
                    Code = "partner_admin",
                    Name = "Partner Administrator",
                    Description = "Partner administrator. Manages settings for the partner"
                })
                .HasData(new UserType
                {
                    UserTypeId = 3,
                    Code = "member",
                    Name = "Member",
                    Description = "Members who signed up for this partners' loyalty programs"
                });
        }
    }
}