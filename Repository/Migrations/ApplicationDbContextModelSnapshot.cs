﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DbContexts;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectStages")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AsignedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Estimate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoryPoints")
                        .HasColumnType("int");

                    b.Property<Guid>("TaskStageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AsignedUserId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskStageId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Models.TaskStage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskStages");
                });

            modelBuilder.Entity("Domain.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LeaderId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CVUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.UserSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("Domain.Models.Project", b =>
                {
                    b.HasOne("Domain.Models.Company", null)
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Models.Task", b =>
                {
                    b.HasOne("Domain.Models.User", "AsignedUser")
                        .WithMany()
                        .HasForeignKey("AsignedUserId");

                    b.HasOne("Domain.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Domain.Models.Project", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Domain.Models.TaskStage", "TaskStage")
                        .WithMany()
                        .HasForeignKey("TaskStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AsignedUser");

                    b.Navigation("Creator");

                    b.Navigation("TaskStage");
                });

            modelBuilder.Entity("Domain.Models.Team", b =>
                {
                    b.HasOne("Domain.Models.Company", null)
                        .WithMany("Teams")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.User", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Project", null)
                        .WithMany("Teams")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Company", null)
                        .WithMany("Workers")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.Team", null)
                        .WithMany("Users")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Domain.Models.UserSkill", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.Models.Company", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Teams");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("Domain.Models.Project", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Domain.Models.Team", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
