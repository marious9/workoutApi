﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using workout_app.Data.Configuration;

namespace workout_app.Infrastructure.Migrations
{
    [DbContext(typeof(WorkoutAppDbContext))]
    [Migration("20210819200222_AddedExerciseTypeUpdatedEntry")]
    partial class AddedExerciseTypeUpdatedEntry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("workout_app.Core.Domain.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("TimeHeld")
                        .HasColumnType("int");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("workout_app.Core.Domain.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ExerciseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("TrainingId")
                        .HasColumnType("int");

                    b.Property<string>("VideoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("workout_app.Core.Domain.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("workout_app.Core.Domain.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("workout_app.Core.Domain.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("workout_app.Core.Domain.Entry", b =>
                {
                    b.HasOne("workout_app.Core.Domain.Exercise", "Exercise")
                        .WithMany("Entries")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("workout_app.Core.Domain.Exercise", b =>
                {
                    b.HasOne("workout_app.Core.Domain.Training", "Training")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("workout_app.Core.Domain.Subcategory", b =>
                {
                    b.HasOne("workout_app.Core.Domain.Exercise", "Exercise")
                        .WithMany("Subcategories")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("workout_app.Core.Domain.Training", b =>
                {
                    b.HasOne("workout_app.Core.Domain.Session", "Session")
                        .WithMany("Trainings")
                        .HasForeignKey("SessionId");
                });
#pragma warning restore 612, 618
        }
    }
}
