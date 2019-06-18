﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myRestAPI;

namespace myRestAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190618115432_AddDoneBooleanToTodo")]
    partial class AddDoneBooleanToTodo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("myRestAPI.Models.Assignee", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("myRestAPI.Models.Todo", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("assigneeid");

                    b.Property<string>("description");

                    b.Property<bool>("done");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("assigneeid");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("myRestAPI.Models.Todo", b =>
                {
                    b.HasOne("myRestAPI.Models.Assignee", "assignee")
                        .WithMany("Student")
                        .HasForeignKey("assigneeid");
                });
#pragma warning restore 612, 618
        }
    }
}
