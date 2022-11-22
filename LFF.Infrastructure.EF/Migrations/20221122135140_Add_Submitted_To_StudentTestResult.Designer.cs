﻿// <auto-generated />
using System;
using LFF.Infrastructure.EF.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LFF.Infrastructure.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221122135140_Add_Submitted_To_StudentTestResult")]
    partial class Add_Submitted_To_StudentTestResult
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LFF.Core.Entities.Classroom", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("NumberOfLessons")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TeacherId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_Classroom_Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("LFF.Core.Entities.Course", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id")
                        .HasName("PK_Course_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LFF.Core.Entities.Lecture", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LessonId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Lecture_Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Lecture");
                });

            modelBuilder.Entity("LFF.Core.Entities.Lesson", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("LessonContent")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("PK_Lesson_Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("LFF.Core.Entities.Question", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TestId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_Question_Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("LFF.Core.Entities.Register", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RegistrationDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StudentId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_Register_Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("LFF.Core.Entities.StudentTest", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StudentId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TestId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_StudentTest_Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestId");

                    b.ToTable("StudentTests");
                });

            modelBuilder.Entity("LFF.Core.Entities.StudentTestResult", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("QuestionId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentTestId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("SubmittedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("PK_StudentTestResult_Id")
                        .IsClustered(false);

                    b.HasAlternateKey("QuestionId", "StudentTestId")
                        .IsClustered();

                    b.HasIndex("StudentTestId");

                    b.ToTable("StudentTestResults");
                });

            modelBuilder.Entity("LFF.Core.Entities.Test", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LessonId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfAttempts")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("Time")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Test_Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("LFF.Core.Entities.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id")
                        .HasName("PK_User_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LFF.Core.Entities.Classroom", b =>
                {
                    b.HasOne("LFF.Core.Entities.Course", "Course")
                        .WithMany("Classrooms")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LFF.Core.Entities.User", "Teacher")
                        .WithMany("Classrooms")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LFF.Core.Entities.Lecture", b =>
                {
                    b.HasOne("LFF.Core.Entities.Lesson", "Lesson")
                        .WithMany("Lectures")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LFF.Core.Entities.Lesson", b =>
                {
                    b.HasOne("LFF.Core.Entities.Classroom", "Class")
                        .WithMany("Lessons")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("LFF.Core.Entities.Question", b =>
                {
                    b.HasOne("LFF.Core.Entities.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("LFF.Core.Entities.Register", b =>
                {
                    b.HasOne("LFF.Core.Entities.Classroom", "Class")
                        .WithMany("Registers")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LFF.Core.Entities.User", "Student")
                        .WithMany("Registers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LFF.Core.Entities.StudentTest", b =>
                {
                    b.HasOne("LFF.Core.Entities.User", "Student")
                        .WithMany("StudentTests")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LFF.Core.Entities.Test", "Test")
                        .WithMany("StudentTests")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("LFF.Core.Entities.StudentTestResult", b =>
                {
                    b.HasOne("LFF.Core.Entities.Question", "Question")
                        .WithMany("StudentTestResults")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LFF.Core.Entities.StudentTest", "StudentTest")
                        .WithMany("StudentTestResults")
                        .HasForeignKey("StudentTestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("StudentTest");
                });

            modelBuilder.Entity("LFF.Core.Entities.Test", b =>
                {
                    b.HasOne("LFF.Core.Entities.Lesson", "Lesson")
                        .WithMany("Tests")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LFF.Core.Entities.Classroom", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Registers");
                });

            modelBuilder.Entity("LFF.Core.Entities.Course", b =>
                {
                    b.Navigation("Classrooms");
                });

            modelBuilder.Entity("LFF.Core.Entities.Lesson", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("LFF.Core.Entities.Question", b =>
                {
                    b.Navigation("StudentTestResults");
                });

            modelBuilder.Entity("LFF.Core.Entities.StudentTest", b =>
                {
                    b.Navigation("StudentTestResults");
                });

            modelBuilder.Entity("LFF.Core.Entities.Test", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("StudentTests");
                });

            modelBuilder.Entity("LFF.Core.Entities.User", b =>
                {
                    b.Navigation("Classrooms");

                    b.Navigation("Registers");

                    b.Navigation("StudentTests");
                });
#pragma warning restore 612, 618
        }
    }
}