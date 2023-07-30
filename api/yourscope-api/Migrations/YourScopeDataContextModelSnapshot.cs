﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using yourscope_api;

#nullable disable

namespace yourscope_api.Migrations
{
    [DbContext(typeof(YourScopeContext))]
    partial class YourScopeDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("yourscope_api.Models.DbModels.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyName")
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

                    b.HasKey("CompanyID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte>("Credits")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte>("Grade")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prerequisites")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.CourseYear", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "YearId");

                    b.HasIndex("YearId");

                    b.ToTable("CourseYear");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.CoverLetter", b =>
                {
                    b.Property<int>("CoverLetterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Conclusion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("SalesPitch1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SalesPitch2")
                        .HasColumnType("longtext");

                    b.Property<string>("SalesPitch3")
                        .HasColumnType("longtext");

                    b.HasKey("CoverLetterId");

                    b.HasIndex("ProfileId");

                    b.ToTable("CoverLetters");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EndDate")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("StartDate")
                        .HasColumnType("int");

                    b.Property<bool>("isWorkExperience")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ExperienceId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.JobApplication", b =>
                {
                    b.Property<int>("JobApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CoverLetterId")
                        .HasColumnType("int");

                    b.Property<int>("JobPostingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("JobApplicationId");

                    b.HasIndex("CoverLetterId");

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

            modelBuilder.Entity("yourscope_api.Models.DbModels.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Awards")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IntrestsHobbies")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Skills")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId");

                    b.HasIndex("StudentId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SchoolId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.SchoolCourse", b =>
                {
                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("SchoolId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("SchoolCourse");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.UniProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GradeRange")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prerequisites")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniPrograms");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Affiliation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("AffiliationID")
                        .HasColumnType("int");

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

            modelBuilder.Entity("yourscope_api.Models.DbModels.Year", b =>
                {
                    b.Property<int>("YearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("YearNumber")
                        .HasColumnType("int");

                    b.HasKey("YearId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.CourseYear", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.Course", "Course")
                        .WithMany("CourseYears")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("yourscope_api.Models.DbModels.Year", "Year")
                        .WithMany("CourseYears")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.CoverLetter", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.Profile", null)
                        .WithMany("CoverLetters")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Event", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId");

                    b.HasOne("yourscope_api.Models.DbModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("School");

                    b.Navigation("User");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Experience", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.Profile", null)
                        .WithMany("Experiences")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.JobApplication", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.CoverLetter", "CoverLetter")
                        .WithMany()
                        .HasForeignKey("CoverLetterId");

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

                    b.Navigation("CoverLetter");

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

            modelBuilder.Entity("yourscope_api.Models.DbModels.Profile", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Schedule", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.SchoolCourse", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.Course", "Course")
                        .WithMany("SchoolCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("yourscope_api.Models.DbModels.School", "School")
                        .WithMany("SchoolCourses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("School");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.UniProgram", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.University", null)
                        .WithMany("UniPrograms")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Year", b =>
                {
                    b.HasOne("yourscope_api.Models.DbModels.Schedule", "Schedule")
                        .WithMany("Years")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Course", b =>
                {
                    b.Navigation("CourseYears");

                    b.Navigation("SchoolCourses");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Profile", b =>
                {
                    b.Navigation("CoverLetters");

                    b.Navigation("Experiences");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Schedule", b =>
                {
                    b.Navigation("Years");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.School", b =>
                {
                    b.Navigation("SchoolCourses");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.University", b =>
                {
                    b.Navigation("UniPrograms");
                });

            modelBuilder.Entity("yourscope_api.Models.DbModels.Year", b =>
                {
                    b.Navigation("CourseYears");
                });
#pragma warning restore 612, 618
        }
    }
}
