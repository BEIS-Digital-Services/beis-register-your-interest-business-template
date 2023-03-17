using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Beis.RegisterYourInterest.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies_house_api_result",
                columns: table => new
                {
                    companies_house_api_result_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_number = table.Column<string>(type: "text", nullable: true),
                    date_of_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    UndeliverableRegisteredOfficeAddress = table.Column<bool>(type: "boolean", nullable: false),
                    company_name = table.Column<string>(type: "text", nullable: true),
                    sic_codes = table.Column<string>(type: "text", nullable: true),
                    registered_office_is_in_dispute = table.Column<bool>(type: "boolean", nullable: false),
                    company_status = table.Column<string>(type: "text", nullable: true),
                    has_insolvency_history = table.Column<bool>(type: "boolean", nullable: false),
                    jurisdiction = table.Column<string>(type: "text", nullable: true),
                    locality = table.Column<string>(type: "text", nullable: true),
                    activity = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies_house_api_result_id", x => x.companies_house_api_result_id);
                });

            migrationBuilder.CreateTable(
                name: "fcasociety",
                columns: table => new
                {
                    societyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    society_number = table.Column<int>(type: "integer", nullable: false),
                    society_suffix = table.Column<string>(type: "text", nullable: true),
                    full_registration_number = table.Column<string>(type: "text", nullable: true),
                    society_name = table.Column<string>(type: "text", nullable: true),
                    registered_as = table.Column<string>(type: "text", nullable: true),
                    society_address = table.Column<string>(type: "text", nullable: true),
                    registration_date = table.Column<string>(type: "text", nullable: true),
                    deregistration_date = table.Column<string>(type: "text", nullable: true),
                    registration_act = table.Column<string>(type: "text", nullable: true),
                    society_status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fcasociety", x => x.societyId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email_address = table.Column<string>(type: "text", nullable: false),
                    verification_code = table.Column<Guid>(type: "uuid", nullable: true),
                    verification_expiry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email_verified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    has_companies_house_number = table.Column<bool>(type: "boolean", nullable: true),
                    companies_house_number = table.Column<string>(type: "text", nullable: true),
                    has_fca_number = table.Column<bool>(type: "boolean", nullable: true),
                    fca_full_registration_number = table.Column<string>(type: "text", nullable: true),
                    applicant_phone_number = table.Column<string>(type: "text", nullable: true),
                    applicant_role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies_house_registered_office_address",
                columns: table => new
                {
                    companies_house_registered_office_address_id = table.Column<int>(type: "integer", nullable: false),
                    address_line_1 = table.Column<string>(type: "text", nullable: true),
                    address_line_2 = table.Column<string>(type: "text", nullable: true),
                    care_of = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    locality = table.Column<string>(type: "text", nullable: true),
                    po_box = table.Column<string>(type: "text", nullable: true),
                    postal_code = table.Column<string>(type: "text", nullable: true),
                    premises = table.Column<string>(type: "text", nullable: true),
                    region = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies_house_registered_office_address_id", x => x.companies_house_registered_office_address_id);
                    table.ForeignKey(
                        name: "FK_companies_house_api_result_companies_house_registered_office_address",
                        column: x => x.companies_house_registered_office_address_id,
                        principalTable: "companies_house_api_result",
                        principalColumn: "companies_house_api_result_id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "companies_house_registered_office_address");

            migrationBuilder.DropTable(
                name: "fcasociety");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "companies_house_api_result");
        }
    }
}
