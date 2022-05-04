﻿// <auto-generated />
using System;
using AdventureApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdventureApp.DataAccess.Migrations
{
    [DbContext(typeof(AdventureDbContext))]
    partial class AdventureDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdventureApp.DataAccess.Entities.Adventure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RootQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RootQuestionId");

                    b.ToTable("Adventure");
                });

            modelBuilder.Entity("AdventureApp.DataAccess.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("Value")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("AdventureApp.DataAccess.Entities.Adventure", b =>
                {
                    b.HasOne("AdventureApp.DataAccess.Entities.Question", "RootQuestion")
                        .WithMany()
                        .HasForeignKey("RootQuestionId");

                    b.Navigation("RootQuestion");
                });

            modelBuilder.Entity("AdventureApp.DataAccess.Entities.Question", b =>
                {
                    b.HasOne("AdventureApp.DataAccess.Entities.Question", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("AdventureApp.DataAccess.Entities.Question", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
