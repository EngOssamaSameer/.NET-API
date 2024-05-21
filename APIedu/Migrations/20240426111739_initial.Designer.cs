﻿// <auto-generated />
using System;
using APIedu.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIedu.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240426111739_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIedu.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("TbCourses");
                });

            modelBuilder.Entity("APIedu.Models.CourseStudentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<int>("StudentInfo_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TbCourseStudentInfo");
                });

            modelBuilder.Entity("APIedu.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contant")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("TbLessons");
                });

            modelBuilder.Entity("APIedu.Models.StudentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TbStudentInfo");
                });

            modelBuilder.Entity("CourseStudentInfo", b =>
                {
                    b.Property<int>("TbCoursesId")
                        .HasColumnType("int");

                    b.Property<int>("TbStudentInfoId")
                        .HasColumnType("int");

                    b.HasKey("TbCoursesId", "TbStudentInfoId");

                    b.HasIndex("TbStudentInfoId");

                    b.ToTable("CourseStudentInfo");
                });

            modelBuilder.Entity("APIedu.Models.Lesson", b =>
                {
                    b.HasOne("APIedu.Models.Course", null)
                        .WithMany("TbLesson")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("CourseStudentInfo", b =>
                {
                    b.HasOne("APIedu.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("TbCoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIedu.Models.StudentInfo", null)
                        .WithMany()
                        .HasForeignKey("TbStudentInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APIedu.Models.Course", b =>
                {
                    b.Navigation("TbLesson");
                });
#pragma warning restore 612, 618
        }
    }
}