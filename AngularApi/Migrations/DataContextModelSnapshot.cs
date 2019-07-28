﻿// <auto-generated />
using AngularApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularApi.Models.Equpment", b =>
                {
                    b.Property<long>("Equipment_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Brand")
                        .HasMaxLength(50);

                    b.Property<int>("EquipmentName_ID");

                    b.Property<string>("Model")
                        .HasMaxLength(50);

                    b.Property<string>("PurchaseTime")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Pyear")
                        .HasMaxLength(10);

                    b.Property<string>("TechSpec");

                    b.Property<int>("Usage");

                    b.HasKey("Equipment_ID");

                    b.HasIndex("EquipmentName_ID");

                    b.ToTable("equpments");
                });

            modelBuilder.Entity("AngularApi.Models.EqupmentName", b =>
                {
                    b.Property<int>("EquipmentName_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("EquipmentName_ID");

                    b.ToTable("equpmentNames");
                });

            modelBuilder.Entity("AngularApi.Models.Locatio", b =>
                {
                    b.Property<int>("Location_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("location")
                        .IsRequired();

                    b.HasKey("Location_id");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("AngularApi.Models.Quez", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ownerid");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Quezes");
                });

            modelBuilder.Entity("AngularApi.Models.Room", b =>
                {
                    b.Property<int>("room_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("location_id");

                    b.Property<string>("room")
                        .IsRequired();

                    b.HasKey("room_id");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("AngularApi.Models.Set", b =>
                {
                    b.Property<int>("set_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("room_id");

                    b.Property<string>("usagetype");

                    b.Property<string>("username");

                    b.HasKey("set_id");

                    b.HasIndex("room_id");

                    b.ToTable("sets");
                });

            modelBuilder.Entity("AngularApi.Models.TestQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer1");

                    b.Property<string>("Answer2");

                    b.Property<string>("Answer3");

                    b.Property<string>("CorrectAnswer");

                    b.Property<string>("Text");

                    b.Property<int>("quezID");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("AngularApi.Models.Equpment", b =>
                {
                    b.HasOne("AngularApi.Models.EqupmentName", "eequpment")
                        .WithMany("equpequpments")
                        .HasForeignKey("EquipmentName_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AngularApi.Models.Set", b =>
                {
                    b.HasOne("AngularApi.Models.Room", "rom")
                        .WithMany("sets")
                        .HasForeignKey("room_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
