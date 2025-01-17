﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechAppointmentApp.Data;

#nullable disable

namespace TechAppointmentApp.Migrations
{
    [DbContext(typeof(TechAppointmentAppDbContext))]
    [Migration("20250117173702_AppointmentTableAddedFixedv3")]
    partial class AppointmentTableAddedFixedv3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechAppointmentApp.Data.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TechnicianId");

                    b.HasIndex(new[] { "AppointmentDate" }, "IX_Appointments_AppointmentDate");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AreaName" }, "IX_Areas_AreaName");

                    b.ToTable("Areas", (string)null);
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<int?>("AreadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("ServiceId");

                    b.HasIndex(new[] { "UserId" }, "IX_Customer_UserId")
                        .IsUnique();

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ServiceName" }, "IX_Services_ServiceName");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Technician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("ServiceId");

                    b.HasIndex(new[] { "UserId" }, "IX_Technician_UserId")
                        .IsUnique();

                    b.ToTable("Technicians", (string)null);
                });

            modelBuilder.Entity("TechAppointmentApp.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_Users_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "PhoneNumber" }, "IX_Users_Phonenumber")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "IX_Users_Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Appointment", b =>
                {
                    b.HasOne("TechAppointmentApp.Data.Area", "Area")
                        .WithMany("Appointments")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TechAppointmentApp.Data.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TechAppointmentApp.Data.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TechAppointmentApp.Data.Technician", "Technician")
                        .WithMany("Appointments")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Customer");

                    b.Navigation("Service");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Customer", b =>
                {
                    b.HasOne("TechAppointmentApp.Data.Area", "Area")
                        .WithMany("Customers")
                        .HasForeignKey("AreaId");

                    b.HasOne("TechAppointmentApp.Data.Service", "Service")
                        .WithMany("Customers")
                        .HasForeignKey("ServiceId");

                    b.HasOne("TechAppointmentApp.Data.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("TechAppointmentApp.Data.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Technician", b =>
                {
                    b.HasOne("TechAppointmentApp.Data.Area", "Area")
                        .WithMany("Technicians")
                        .HasForeignKey("AreaId");

                    b.HasOne("TechAppointmentApp.Data.Service", "Service")
                        .WithMany("Technicians")
                        .HasForeignKey("ServiceId");

                    b.HasOne("TechAppointmentApp.Data.User", "User")
                        .WithOne("Technician")
                        .HasForeignKey("TechAppointmentApp.Data.Technician", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Area", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Customers");

                    b.Navigation("Technicians");
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Service", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Customers");

                    b.Navigation("Technicians");
                });

            modelBuilder.Entity("TechAppointmentApp.Data.Technician", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("TechAppointmentApp.Data.User", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
