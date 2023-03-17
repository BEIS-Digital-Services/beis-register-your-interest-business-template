﻿// <auto-generated />
using System;
using Beis.RegisterYourInterest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Beis.RegisterYourInterest.Migrations
{
    [DbContext(typeof(RegisterYourInterestDbContext<Applicant>))]
    [Migration("20230317141652_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Beis.Common.Entities.Models.BaseUserEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email_address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("email_verified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("verification_code")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("verification_expiry_date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.HasIndex("email_address")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseUserEntity");
                });

            modelBuilder.Entity("Beis.Common.Entities.Models.companies_house_api_result", b =>
                {
                    b.Property<int>("companies_house_api_result_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("companies_house_api_result_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("companies_house_api_result_id"));

                    b.Property<string>("activity")
                        .HasColumnType("text")
                        .HasColumnName("activity");

                    b.Property<string>("company_name")
                        .HasColumnType("text")
                        .HasColumnName("company_name");

                    b.Property<string>("company_number")
                        .HasColumnType("text")
                        .HasColumnName("company_number");

                    b.Property<string>("company_status")
                        .HasColumnType("text")
                        .HasColumnName("company_status");

                    b.Property<DateTime>("date_of_creation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_creation");

                    b.Property<bool>("has_insolvency_history")
                        .HasColumnType("boolean")
                        .HasColumnName("has_insolvency_history");

                    b.Property<string>("jurisdiction")
                        .HasColumnType("text")
                        .HasColumnName("jurisdiction");

                    b.Property<string>("locality")
                        .HasColumnType("text")
                        .HasColumnName("locality");

                    b.Property<bool>("registered_office_is_in_dispute")
                        .HasColumnType("boolean")
                        .HasColumnName("registered_office_is_in_dispute");

                    b.Property<string>("sic_codes")
                        .HasColumnType("text")
                        .HasColumnName("sic_codes");

                    b.Property<string>("type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<bool>("undeliverable_registered_office_address")
                        .HasColumnType("boolean")
                        .HasColumnName("UndeliverableRegisteredOfficeAddress");

                    b.HasKey("companies_house_api_result_id")
                        .HasName("pk_companies_house_api_result_id");

                    b.ToTable("companies_house_api_result", (string)null);
                });

            modelBuilder.Entity("Beis.Common.Entities.Models.companies_house_registered_office_address", b =>
                {
                    b.Property<int>("companies_house_registered_office_address_id")
                        .HasColumnType("integer");

                    b.Property<string>("address_line_1")
                        .HasColumnType("text");

                    b.Property<string>("address_line_2")
                        .HasColumnType("text");

                    b.Property<string>("care_of")
                        .HasColumnType("text");

                    b.Property<string>("country")
                        .HasColumnType("text");

                    b.Property<string>("locality")
                        .HasColumnType("text");

                    b.Property<string>("po_box")
                        .HasColumnType("text");

                    b.Property<string>("postal_code")
                        .HasColumnType("text");

                    b.Property<string>("premises")
                        .HasColumnType("text");

                    b.Property<string>("region")
                        .HasColumnType("text");

                    b.HasKey("companies_house_registered_office_address_id")
                        .HasName("pk_companies_house_registered_office_address_id");

                    b.ToTable("companies_house_registered_office_address", (string)null);
                });

            modelBuilder.Entity("Beis.Common.Entities.Models.fcasociety", b =>
                {
                    b.Property<int>("societyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("societyId"));

                    b.Property<string>("deregistration_date")
                        .HasColumnType("text");

                    b.Property<string>("full_registration_number")
                        .HasColumnType("text");

                    b.Property<string>("registered_as")
                        .HasColumnType("text");

                    b.Property<string>("registration_act")
                        .HasColumnType("text");

                    b.Property<string>("registration_date")
                        .HasColumnType("text");

                    b.Property<string>("society_address")
                        .HasColumnType("text");

                    b.Property<string>("society_name")
                        .HasColumnType("text");

                    b.Property<int>("society_number")
                        .HasColumnType("integer");

                    b.Property<string>("society_status")
                        .HasColumnType("text");

                    b.Property<string>("society_suffix")
                        .HasColumnType("text");

                    b.HasKey("societyId");

                    b.ToTable("fcasociety", (string)null);
                });

            modelBuilder.Entity("Beis.RegisterYourInterest.Data.Applicant", b =>
                {
                    b.HasBaseType("Beis.Common.Entities.Models.BaseUserEntity");

                    b.Property<string>("applicant_phone_number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("applicant_role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("companies_house_number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fca_full_registration_number")
                        .HasColumnType("text");

                    b.Property<bool?>("has_companies_house_number")
                        .HasColumnType("boolean");

                    b.Property<bool?>("has_fca_number")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("Applicant");
                });

            modelBuilder.Entity("Beis.Common.Entities.Models.companies_house_registered_office_address", b =>
                {
                    b.HasOne("Beis.Common.Entities.Models.companies_house_api_result", "companies_house_api_result")
                        .WithOne("registered_office_address")
                        .HasForeignKey("Beis.Common.Entities.Models.companies_house_registered_office_address", "companies_house_registered_office_address_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_companies_house_api_result_companies_house_registered_office_address");

                    b.Navigation("companies_house_api_result");
                });

            modelBuilder.Entity("Beis.Common.Entities.Models.companies_house_api_result", b =>
                {
                    b.Navigation("registered_office_address");
                });
#pragma warning restore 612, 618
        }
    }
}