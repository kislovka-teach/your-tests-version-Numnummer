﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240316213420_AddRoleToUser")]
    partial class AddRoleToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Repository.Models.Excercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApproachesCount")
                        .HasColumnType("integer")
                        .HasAnnotation("AnnotationName:MinimumValue", 1);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<float>("Duration")
                        .HasColumnType("real")
                        .HasAnnotation("AnnotationName:MinimumValue", 1);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<float>("RestDuration")
                        .HasColumnType("real")
                        .HasAnnotation("AnnotationName:MinimumValue", 1);

                    b.HasKey("Id");

                    b.ToTable("Excercises");
                });

            modelBuilder.Entity("Repository.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("TrainingId")
                        .HasColumnType("integer");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserLogin");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Repository.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasAnnotation("AnnotationName:MinimumValue", 1);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Repository.Models.TrainingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExcerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("TrainingId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.HasIndex("TrainingId");

                    b.ToTable("TrainingPlans");
                });

            modelBuilder.Entity("Repository.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasAnnotation("AnnotationName:MinimumValue", 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("AnnotationName:MinimumValue", 1);

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Login");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Repository.Models.Review", b =>
                {
                    b.HasOne("Repository.Models.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository.Models.TrainingPlan", b =>
                {
                    b.HasOne("Repository.Models.Excercise", "Excercise")
                        .WithMany()
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Models.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excercise");

                    b.Navigation("Training");
                });
#pragma warning restore 612, 618
        }
    }
}
