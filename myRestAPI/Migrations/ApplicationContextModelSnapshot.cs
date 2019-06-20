﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myRestAPI;

namespace myRestAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("myRestAPI.Models.Assignee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("myRestAPI.Models.Todo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AssigneeId");

                    b.Property<int?>("CreatorId");

                    b.Property<string>("Description");

                    b.Property<bool>("Done");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("myRestAPI.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("myRestAPI.Models.Todo", b =>
                {
                    b.HasOne("myRestAPI.Models.Assignee", "Assignee")
                        .WithMany("TodoList")
                        .HasForeignKey("AssigneeId");

                    b.HasOne("myRestAPI.Models.User.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });
#pragma warning restore 612, 618
        }
    }
}
