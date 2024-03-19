using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users;
using Ribbons.Users.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public abstract class AdminDb : Database, IUserDatabase
    {
        public DbSet<DbServer> DbServers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerDbConfig> PartnerDbConfigs { get; set; }
        public DbSet<PartnerDeployment> PartnerDeployments { get; set; }

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
                })
                .ValueGeneratedOnAdd<Partner, long>(x => x.PartnerId)
                .HasData(new DbServer
                {
                    DbServerId = 1,
                    Name = "localhost",
                    Provider = DatabaseProvider.MsSql,
                    ConnectionString = "server=localhost;user id=sa;password=ASD123!@#;trustservercertificate=true"
                })
                .HasData(new DbServer
                {
                    DbServerId = 2,
                    Name = "host.docker.internal",
                    Provider = DatabaseProvider.MsSql,
                    ConnectionString = "server=host.docker.internal;user id=sa;password=ASD123!@#;trustservercertificate=true"
                });
        }
    }
}