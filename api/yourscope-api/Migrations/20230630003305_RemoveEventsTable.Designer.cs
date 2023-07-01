﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using yourscope_api;

#nullable disable

namespace yourscope_api.Migrations
{
    [DbContext(typeof(YourScopeContext))]
    [Migration("20230630003305_RemoveEventsTable")]
    partial class RemoveEventsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("yourscope_api.Models.DbModels.Company", b =>
                {
                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Fax")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<int?>("UnitNumber")
                        .HasColumnType("int");

                    b.HasKey("CompanyName");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.JobApplication", b =>
                {
                    b.Property<int>("JobApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("JobPostingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("responses")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("JobApplicationId");

                    b.HasIndex("JobPostingId");

                    b.HasIndex("UserId");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.JobPosting", b =>
                {
                    b.Property<int>("JobPostingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ApplicationDeadline")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("JobPostingId");

                    b.HasIndex("UserId");

                    b.ToTable("JobPostings");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.JobQuestion", b =>
                {
                    b.Property<int>("JobQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("JobPostingId")
                        .HasColumnType("int");

                    b.Property<int>("MaxWords")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("JobQuestionId");

                    b.HasIndex("JobPostingId");

                    b.ToTable("JobQuestions");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.School", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.HasKey("Name");

                    b.ToTable("School");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Affiliation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<short?>("Grade")
                        .HasColumnType("smallint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.JobApplication", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.JobPosting", "JobPosting")
                        .WithMany()
                        .HasForeignKey("JobPostingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("yourscope_api.Models.DbModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPosting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.JobPosting", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.JobQuestion", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.JobPosting", "JobPosting")
                        .WithMany()
                        .HasForeignKey("JobPostingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPosting");
                });
#pragma warning restore 612, 618
        }
    }
}