using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ribbons.Loyalty.Data.Migrations.AdminDbMigrations.MySql
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_db_server",
                columns: table => new
                {
                    db_server_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    provider = table.Column<int>(type: "int", nullable: false),
                    connection_string = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_db_server", x => x.db_server_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_partner",
                columns: table => new
                {
                    partner_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    account_number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    alias = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    is_deployed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    deployed_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    business_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    billing_address = table.Column<string>(type: "longtext", nullable: false),
                    country = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    state = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    city = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    zipcode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_partner", x => x.partner_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_partner_db_config",
                columns: table => new
                {
                    partner_id = table.Column<long>(type: "bigint", nullable: false),
                    provider = table.Column<int>(type: "int", nullable: false),
                    connection_string = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_partner_db_config", x => x.partner_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_user_type",
                columns: table => new
                {
                    user_type_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_type", x => x.user_type_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_type_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    username = table.Column<string>(type: "varchar(320)", maxLength: 320, nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_user_email",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_type_id = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    email_address = table.Column<string>(type: "varchar(320)", maxLength: 320, nullable: false),
                    is_verified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    verified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_email", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_email_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                    table.ForeignKey(
                        name: "FK_t_user_email_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_user_password",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    password_salt = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    password_hash = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    is_expired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_password", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_password_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_user_phone",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_type_id = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    phone_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    is_verified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    verified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_phone", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_phone_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                    table.ForeignKey(
                        name: "FK_t_user_phone_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_user_session",
                columns: table => new
                {
                    user_session_id = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_expired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    session_secret_salt = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    session_secret_hash = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    is_logged_out = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    logout_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_session", x => x.user_session_id);
                    table.ForeignKey(
                        name: "FK_t_user_session_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_user_token",
                columns: table => new
                {
                    user_token_id = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_expired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    token_secret_salt = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    token_secret_hash = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    is_consumed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    consumed_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_token", x => x.user_token_id);
                    table.ForeignKey(
                        name: "FK_t_user_token_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "t_db_server",
                columns: new[] { "db_server_id", "connection_string", "name", "provider" },
                values: new object[,]
                {
                    { 1L, "server=localhost;user id=sa;password=ASD123!@#;trustservercertificate=true", "localhost", 1 },
                    { 2L, "server=host.docker.internal;user id=sa;password=ASD123!@#;trustservercertificate=true", "host.docker.internal", 1 }
                });

            migrationBuilder.InsertData(
                table: "t_user_type",
                columns: new[] { "user_type_id", "code", "description", "name" },
                values: new object[] { 1, "admin", "System administrator. Manages global settings for the loyalty platform", "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_t_db_server_name",
                table: "t_db_server",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_db_server_provider",
                table: "t_db_server",
                column: "provider");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_account_number",
                table: "t_partner",
                column: "account_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_alias",
                table: "t_partner",
                column: "alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_city",
                table: "t_partner",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_country",
                table: "t_partner",
                column: "country");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_created_date",
                table: "t_partner",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_deployed_date",
                table: "t_partner",
                column: "deployed_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_is_deployed",
                table: "t_partner",
                column: "is_deployed");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_modified_date",
                table: "t_partner",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_state",
                table: "t_partner",
                column: "state");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_status",
                table: "t_partner",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_zipcode",
                table: "t_partner",
                column: "zipcode");

            migrationBuilder.CreateIndex(
                name: "IX_t_partner_db_config_provider",
                table: "t_partner_db_config",
                column: "provider");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_created_date",
                table: "t_user",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_modified_date",
                table: "t_user",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_status",
                table: "t_user",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_user_type_id",
                table: "t_user",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_user_type_id_username",
                table: "t_user",
                columns: new[] { "user_type_id", "username" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_username",
                table: "t_user",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_created_date",
                table: "t_user_email",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_email_address",
                table: "t_user_email",
                column: "email_address");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_is_verified",
                table: "t_user_email",
                column: "is_verified");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_modified_date",
                table: "t_user_email",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_user_type_id",
                table: "t_user_email",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_user_type_id_email_address",
                table: "t_user_email",
                columns: new[] { "user_type_id", "email_address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_verified_date",
                table: "t_user_email",
                column: "verified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_password_created_date",
                table: "t_user_password",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_password_expiry_date",
                table: "t_user_password",
                column: "expiry_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_password_is_expired",
                table: "t_user_password",
                column: "is_expired");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_password_modified_date",
                table: "t_user_password",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_phone_created_date",
                table: "t_user_phone",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_phone_is_verified",
                table: "t_user_phone",
                column: "is_verified");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_phone_modified_date",
                table: "t_user_phone",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_phone_phone_number",
                table: "t_user_phone",
                column: "phone_number");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_phone_user_type_id",
                table: "t_user_phone",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_phone_user_type_id_phone_number",
                table: "t_user_phone",
                columns: new[] { "user_type_id", "phone_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_phone_verified_date",
                table: "t_user_phone",
                column: "verified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_created_date",
                table: "t_user_session",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_expiry_date",
                table: "t_user_session",
                column: "expiry_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_is_expired",
                table: "t_user_session",
                column: "is_expired");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_is_logged_out",
                table: "t_user_session",
                column: "is_logged_out");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_logout_date",
                table: "t_user_session",
                column: "logout_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_user_id",
                table: "t_user_session",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_consumed_date",
                table: "t_user_token",
                column: "consumed_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_created_date",
                table: "t_user_token",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_expiry_date",
                table: "t_user_token",
                column: "expiry_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_is_consumed",
                table: "t_user_token",
                column: "is_consumed");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_is_expired",
                table: "t_user_token",
                column: "is_expired");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_type",
                table: "t_user_token",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_user_id",
                table: "t_user_token",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_type_code",
                table: "t_user_type",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_db_server");

            migrationBuilder.DropTable(
                name: "t_partner");

            migrationBuilder.DropTable(
                name: "t_partner_db_config");

            migrationBuilder.DropTable(
                name: "t_user_email");

            migrationBuilder.DropTable(
                name: "t_user_password");

            migrationBuilder.DropTable(
                name: "t_user_phone");

            migrationBuilder.DropTable(
                name: "t_user_session");

            migrationBuilder.DropTable(
                name: "t_user_token");

            migrationBuilder.DropTable(
                name: "t_user");

            migrationBuilder.DropTable(
                name: "t_user_type");
        }
    }
}
