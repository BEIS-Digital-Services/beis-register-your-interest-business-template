using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Beis.RegisterYourInterest.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email_address = table.Column<string>(type: "text", nullable: false),
                    verification_code = table.Column<Guid>(type: "uuid", nullable: true),
                    verification_expiry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email_verified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    HasCompaniesHouseNumber = table.Column<bool>(type: "boolean", nullable: true),
                    CompaniesHouseNumber = table.Column<string>(type: "text", nullable: true),
                    HasFcaNumber = table.Column<bool>(type: "boolean", nullable: true),
                    FCAFullRegistrationNumber = table.Column<string>(type: "text", nullable: true),
                    ApplicantName = table.Column<string>(type: "text", nullable: true),
                    ApplicantPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ApplicantRole = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_email_address",
                table: "users",
                column: "email_address",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
