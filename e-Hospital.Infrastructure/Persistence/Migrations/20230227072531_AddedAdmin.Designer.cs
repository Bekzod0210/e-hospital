﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using e_Hospital.Infrastructure.Persistence;

#nullable disable

namespace e_Hospital.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230227072531_AddedAdmin")]
    partial class AddedAdmin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("e_Hospital.Domain.Entities.Ambulance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CallId")
                        .HasColumnType("integer");

                    b.Property<int>("HospitalId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CallId");

                    b.HasIndex("HospitalId");

                    b.ToTable("Ambulances");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Born", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<int>("HospitalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("UserId");

                    b.ToTable("Bornes");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Call", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Died", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HospitalId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("UserId");

                    b.ToTable("Dieds");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProfessionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.HospitalEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("HospitalId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("HospitalId");

                    b.ToTable("HospitalEmployees");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.MedicalExaminationResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QueueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QueueId");

                    b.ToTable("MedicalExaminationResults");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("TotalSum")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("PharmacyMedicineId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PharmacyMedicineId");

                    b.ToTable("OrdersDetails");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Pharmacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.PharmacyMedicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("PharmacyMedicines");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Queue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HospitalId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("ProfessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("e_Hospital.Domain.Entities.User");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Ambulance", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Call", "Call")
                        .WithMany("Ambulances")
                        .HasForeignKey("CallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Hospital.Domain.Entities.Hospital", "Hospital")
                        .WithMany("Ambulances")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Call");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Born", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Hospital", "Hospital")
                        .WithMany("Borns")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Hospital.Domain.Entities.User", "User")
                        .WithMany("Borns")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("User");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Died", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Hospital", "Hospital")
                        .WithMany("Dieds")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Hospital.Domain.Entities.User", "User")
                        .WithMany("Dieds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("User");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Employee", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Profession", "Profession")
                        .WithMany("Employees")
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profession");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.HospitalEmployee", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeHospitals")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Hospital.Domain.Entities.Hospital", "Hospital")
                        .WithMany("HospitalEmployees")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.MedicalExaminationResult", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Queue", "Queue")
                        .WithMany("MedicalExaminationResults")
                        .HasForeignKey("QueueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Queue");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Order", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Hospital.Domain.Entities.PharmacyMedicine", "PharmacyMedicine")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PharmacyMedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PharmacyMedicine");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.PharmacyMedicine", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Medicine", "Medicine")
                        .WithMany("PharmacyMedicines")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Hospital.Domain.Entities.Order", null)
                        .WithMany("PharmacyMedicines")
                        .HasForeignKey("OrderId");

                    b.HasOne("e_Hospital.Domain.Entities.Pharmacy", "Pharmacy")
                        .WithMany("PharmacyMedicines")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Queue", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.Hospital", "Hospital")
                        .WithMany("Queues")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Hospital.Domain.Entities.Profession", "Profession")
                        .WithMany("Queues")
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Hospital.Domain.Entities.User", "User")
                        .WithMany("Queues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("Profession");

                    b.Navigation("User");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Admin", b =>
                {
                    b.HasOne("e_Hospital.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("e_Hospital.Domain.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Call", b =>
                {
                    b.Navigation("Ambulances");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeHospitals");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Hospital", b =>
                {
                    b.Navigation("Ambulances");

                    b.Navigation("Borns");

                    b.Navigation("Dieds");

                    b.Navigation("HospitalEmployees");

                    b.Navigation("Queues");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Medicine", b =>
                {
                    b.Navigation("PharmacyMedicines");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("PharmacyMedicines");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Pharmacy", b =>
                {
                    b.Navigation("PharmacyMedicines");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.PharmacyMedicine", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Profession", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Queues");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.Queue", b =>
                {
                    b.Navigation("MedicalExaminationResults");
                });

            modelBuilder.Entity("e_Hospital.Domain.Entities.User", b =>
                {
                    b.Navigation("Borns");

                    b.Navigation("Dieds");

                    b.Navigation("Orders");

                    b.Navigation("Queues");
                });
#pragma warning restore 612, 618
        }
    }
}
