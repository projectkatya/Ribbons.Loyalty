using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users;
using Ribbons.Users.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public abstract class AdminDb : Database, IUserDatabase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected AdminDb(DatabaseProvider provider) : base(provider) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .SetupUserModel()
                .HasData(new UserType
                {
                    UserTypeId = LoyaltyUser.Admin.ConvertTo<int>(),
                    Code = "admin",
                    Name = "Administrator",
                    Description = "System administrator. Manages global settings for the loyalty platform"
                });
        }
    }
}