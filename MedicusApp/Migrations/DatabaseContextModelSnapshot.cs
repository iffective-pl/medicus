﻿// <auto-generated />
using System;
using MedicusApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicusApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DoctorSpec", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("SpecId")
                        .HasColumnType("integer");

                    b.HasKey("DoctorId", "SpecId");

                    b.HasIndex("SpecId");

                    b.ToTable("DoctorSpec");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            SpecId = 1
                        },
                        new
                        {
                            DoctorId = 2,
                            SpecId = 1
                        },
                        new
                        {
                            DoctorId = 2,
                            SpecId = 6
                        },
                        new
                        {
                            DoctorId = 3,
                            SpecId = 4
                        },
                        new
                        {
                            DoctorId = 4,
                            SpecId = 4
                        },
                        new
                        {
                            DoctorId = 5,
                            SpecId = 7
                        },
                        new
                        {
                            DoctorId = 6,
                            SpecId = 8
                        },
                        new
                        {
                            DoctorId = 7,
                            SpecId = 2
                        },
                        new
                        {
                            DoctorId = 8,
                            SpecId = 9
                        },
                        new
                        {
                            DoctorId = 9,
                            SpecId = 3
                        },
                        new
                        {
                            DoctorId = 2,
                            SpecId = 10
                        },
                        new
                        {
                            DoctorId = 10,
                            SpecId = 10
                        },
                        new
                        {
                            DoctorId = 11,
                            SpecId = 11
                        },
                        new
                        {
                            DoctorId = 3,
                            SpecId = 11
                        },
                        new
                        {
                            DoctorId = 1,
                            SpecId = 12
                        },
                        new
                        {
                            DoctorId = 2,
                            SpecId = 12
                        },
                        new
                        {
                            DoctorId = 10,
                            SpecId = 12
                        });
                });

            modelBuilder.Entity("MedicusApp.Model.Links.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Href")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsIndex")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Order"));

                    b.HasKey("Id");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Href = "/",
                            IsIndex = true,
                            Name = "Strona główna",
                            Order = 1
                        },
                        new
                        {
                            Id = 2,
                            Href = "about",
                            IsIndex = false,
                            Name = "O nas",
                            Order = 2
                        },
                        new
                        {
                            Id = 3,
                            Href = "register",
                            IsIndex = false,
                            Name = "Rejestracja",
                            Order = 3
                        },
                        new
                        {
                            Id = 4,
                            Href = "docs",
                            IsIndex = false,
                            Name = "Nasi specjaliści",
                            Order = 4
                        },
                        new
                        {
                            Id = 5,
                            Href = "usg",
                            IsIndex = false,
                            Name = "USG",
                            Order = 5
                        },
                        new
                        {
                            Id = 6,
                            Href = "echo",
                            IsIndex = false,
                            Name = "ECHO Serca",
                            Order = 6
                        },
                        new
                        {
                            Id = 7,
                            Href = "holter",
                            IsIndex = false,
                            Name = "Holter",
                            Order = 7
                        },
                        new
                        {
                            Id = 8,
                            Href = "contact",
                            IsIndex = false,
                            Name = "Kontakt",
                            Order = 8
                        });
                });

            modelBuilder.Entity("MedicusApp.Model.Links.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Href")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("LinkId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Order"));

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Href = "/cardiology",
                            LinkId = 4,
                            Name = "Kardiologia",
                            Order = 1
                        },
                        new
                        {
                            Id = 2,
                            Href = "/urology",
                            LinkId = 4,
                            Name = "Urologia",
                            Order = 2
                        },
                        new
                        {
                            Id = 3,
                            Href = "/orthopedy",
                            LinkId = 4,
                            Name = "Ortopedia",
                            Order = 3
                        },
                        new
                        {
                            Id = 4,
                            Href = "/ginecology",
                            LinkId = 4,
                            Name = "Ginekologia",
                            Order = 4
                        },
                        new
                        {
                            Id = 5,
                            Href = "/ginecology",
                            LinkId = 4,
                            Name = "Internista",
                            Order = 5
                        },
                        new
                        {
                            Id = 6,
                            Href = "/pediatri",
                            LinkId = 4,
                            Name = "Pediatria",
                            Order = 6
                        },
                        new
                        {
                            Id = 7,
                            Href = "/endokrynology",
                            LinkId = 4,
                            Name = "Endokrynologia",
                            Order = 7
                        },
                        new
                        {
                            Id = 8,
                            Href = "/kids",
                            LinkId = 5,
                            Name = "USG Dzieci",
                            Order = 1
                        },
                        new
                        {
                            Id = 9,
                            Href = "/adults",
                            LinkId = 5,
                            Name = "USG Dorosłych",
                            Order = 2
                        },
                        new
                        {
                            Id = 10,
                            Href = "/pregnancy",
                            LinkId = 5,
                            Name = "USG Ciąży",
                            Order = 3
                        },
                        new
                        {
                            Id = 11,
                            Href = "/kids",
                            LinkId = 6,
                            Name = "ECHO Dzieci",
                            Order = 1
                        },
                        new
                        {
                            Id = 12,
                            Href = "/adults",
                            LinkId = 6,
                            Name = "ECHO Dorosłych",
                            Order = 2
                        });
                });

            modelBuilder.Entity("MedicusApp.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Włocławek",
                            FirstName = "Wiesław",
                            LastName = "Nowakowski",
                            Title = "Dr n. med."
                        },
                        new
                        {
                            Id = 2,
                            City = "Włocławek",
                            FirstName = "Irena",
                            LastName = "Nowakowska",
                            Title = "Dr n. med."
                        },
                        new
                        {
                            Id = 3,
                            City = "Łódź",
                            FirstName = "Dorota",
                            LastName = "Nowakowska",
                            Title = "Prof. dr hab. med."
                        },
                        new
                        {
                            Id = 4,
                            City = "Włocławek",
                            FirstName = "Zbigniew",
                            LastName = "Placek",
                            Title = "Lek. med."
                        },
                        new
                        {
                            Id = 5,
                            City = "Łódź",
                            FirstName = "Ewa",
                            LastName = "Sewerynek",
                            Title = "Prof. dr hab. med."
                        },
                        new
                        {
                            Id = 6,
                            City = "Warszawa",
                            FirstName = "Tomasz",
                            LastName = "Kmieć",
                            Title = "Dr n. med."
                        },
                        new
                        {
                            Id = 7,
                            City = "Łódź",
                            FirstName = "Marek",
                            LastName = "Wrona",
                            Title = "Dr n. med."
                        },
                        new
                        {
                            Id = 8,
                            City = "Włocławek",
                            FirstName = "Janina",
                            LastName = "Wielicka",
                            Title = "Lek. med."
                        },
                        new
                        {
                            Id = 9,
                            City = "Włocławek",
                            FirstName = "Bogdan",
                            LastName = "Wojtecki",
                            Title = "Lek. med."
                        },
                        new
                        {
                            Id = 10,
                            City = "Włocławek",
                            FirstName = "Leszek",
                            LastName = "Dura",
                            Title = "Lek. med."
                        },
                        new
                        {
                            Id = 11,
                            City = "Włocławek",
                            FirstName = "Zbyszek",
                            LastName = "Ruszkowski",
                            Title = "Lek. med."
                        });
                });

            modelBuilder.Entity("MedicusApp.Models.Spec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Href")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Order"));

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassName = "heart",
                            Href = "cardiology",
                            Name = "Kardiologia",
                            Order = 1
                        },
                        new
                        {
                            Id = 2,
                            ClassName = "kidneys",
                            Href = "urology",
                            Name = "Urologia",
                            Order = 2
                        },
                        new
                        {
                            Id = 3,
                            ClassName = "leg",
                            Href = "ortopedy",
                            Name = "Ortopedia",
                            Order = 3
                        },
                        new
                        {
                            Id = 4,
                            ClassName = "pregnant",
                            Href = "ginecology",
                            Name = "Ginekologia",
                            Order = 4
                        },
                        new
                        {
                            Id = 5,
                            ClassName = "coughing",
                            Href = "internist",
                            Name = "Internista",
                            Order = 5
                        },
                        new
                        {
                            Id = 6,
                            ClassName = "lactation",
                            Href = "pediatrics",
                            Name = "Pediatria",
                            Order = 6
                        },
                        new
                        {
                            Id = 7,
                            ClassName = "stethoscope",
                            Href = "endocrinology",
                            Name = "Endokrynologia",
                            Order = 7
                        },
                        new
                        {
                            Id = 8,
                            ClassName = "neurology",
                            Href = "neurology",
                            Name = "Neurologia",
                            Order = 8
                        },
                        new
                        {
                            Id = 9,
                            ClassName = "allergies",
                            Href = "dermatology",
                            Name = "Dermatologia",
                            Order = 9
                        },
                        new
                        {
                            Id = 10,
                            ClassName = "echo",
                            Href = "echo",
                            Name = "ECHO",
                            Order = 10
                        },
                        new
                        {
                            Id = 11,
                            ClassName = "xray",
                            Href = "usg",
                            Name = "USG",
                            Order = 11
                        },
                        new
                        {
                            Id = 12,
                            ClassName = "blood_pressure",
                            Href = "holter",
                            Name = "Holter",
                            Order = 12
                        });
                });

            modelBuilder.Entity("MedicusApp.Models.WorkingHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Friday")
                        .HasColumnType("text");

                    b.Property<string>("Monday")
                        .HasColumnType("text");

                    b.Property<string>("Saturday")
                        .HasColumnType("text");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("integer");

                    b.Property<string>("Sunday")
                        .HasColumnType("text");

                    b.Property<string>("Thursday")
                        .HasColumnType("text");

                    b.Property<string>("Tuesday")
                        .HasColumnType("text");

                    b.Property<string>("Wednesday")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("WorkHours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoctorId = 1,
                            Friday = "15:30 - 17.00",
                            SpecializationId = 1,
                            Thursday = "15:30 - 17.00",
                            Tuesday = "15:30 - 17.00",
                            Wednesday = "15:30 - 17.00"
                        },
                        new
                        {
                            Id = 2,
                            DoctorId = 2,
                            Monday = "15:00 - 17.00",
                            SpecializationId = 1,
                            Thursday = "15:00 - 17.00",
                            Tuesday = "15:00 - 17.00",
                            Wednesday = "15:00 - 17.00"
                        },
                        new
                        {
                            Id = 3,
                            DoctorId = 2,
                            Monday = "15:00 - 17.00",
                            SpecializationId = 6,
                            Thursday = "15:00 - 17.00",
                            Tuesday = "15:00 - 17.00",
                            Wednesday = "15:00 - 17.00"
                        },
                        new
                        {
                            Id = 4,
                            DoctorId = 3,
                            Friday = "15:00 - 17.00",
                            Saturday = "15:00 - 17.00",
                            SpecializationId = 4
                        },
                        new
                        {
                            Id = 5,
                            DoctorId = 4,
                            SpecializationId = 4,
                            Thursday = "14:00 - 17.00",
                            Tuesday = "14:00 - 17.00",
                            Wednesday = "14:00 - 17.00"
                        },
                        new
                        {
                            Id = 6,
                            DoctorId = 5,
                            Saturday = "od 9:00 (raz w miesiącu)",
                            SpecializationId = 7
                        },
                        new
                        {
                            Id = 7,
                            DoctorId = 6,
                            Saturday = "od 9:00 (raz w miesiącu)",
                            SpecializationId = 8
                        },
                        new
                        {
                            Id = 8,
                            DoctorId = 7,
                            Saturday = "od 11:00 (raz w miesiącu)",
                            SpecializationId = 2
                        },
                        new
                        {
                            Id = 9,
                            DoctorId = 8,
                            SpecializationId = 9,
                            Thursday = "15:30 - 17.00",
                            Tuesday = "15:30 - 17.00",
                            Wednesday = "15:30 - 17.00"
                        },
                        new
                        {
                            Id = 10,
                            DoctorId = 9,
                            Friday = "16:00 - 17:00",
                            SpecializationId = 3,
                            Thursday = "15:30 - 17.00",
                            Tuesday = "15:30 - 17.00",
                            Wednesday = "15:30 - 17.00"
                        },
                        new
                        {
                            Id = 12,
                            DoctorId = 2,
                            SpecializationId = 10,
                            Wednesday = "15:00 - 17.00"
                        },
                        new
                        {
                            Id = 13,
                            DoctorId = 10,
                            SpecializationId = 10,
                            Tuesday = "14:00 - 16.00"
                        },
                        new
                        {
                            Id = 14,
                            DoctorId = 11,
                            SpecializationId = 11,
                            Thursday = "15:00 - 16.30"
                        },
                        new
                        {
                            Id = 15,
                            DoctorId = 3,
                            Friday = "12:00 - 18.00",
                            Saturday = "12:00 - 18.00",
                            SpecializationId = 11
                        },
                        new
                        {
                            Id = 16,
                            DoctorId = 1,
                            Friday = "15:30 - 17.00",
                            SpecializationId = 12,
                            Thursday = "15:30 - 17.00",
                            Tuesday = "15:30 - 17.00",
                            Wednesday = "15:30 - 17.00"
                        },
                        new
                        {
                            Id = 17,
                            DoctorId = 2,
                            Monday = "15:00 - 17.00",
                            SpecializationId = 12,
                            Thursday = "15:00 - 17.00",
                            Tuesday = "15:00 - 17.00",
                            Wednesday = "15:00 - 17.00"
                        },
                        new
                        {
                            Id = 18,
                            DoctorId = 10,
                            SpecializationId = 12,
                            Tuesday = "14:00 - 16.00"
                        });
                });

            modelBuilder.Entity("DoctorSpec", b =>
                {
                    b.HasOne("MedicusApp.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicusApp.Models.Spec", null)
                        .WithMany()
                        .HasForeignKey("SpecId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicusApp.Model.Links.Option", b =>
                {
                    b.HasOne("MedicusApp.Model.Links.Link", null)
                        .WithMany("Options")
                        .HasForeignKey("LinkId");
                });

            modelBuilder.Entity("MedicusApp.Models.WorkingHours", b =>
                {
                    b.HasOne("MedicusApp.Models.Doctor", "Doctor")
                        .WithMany("WorkingHours")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicusApp.Models.Spec", "Specialization")
                        .WithMany("WorkingHours")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("MedicusApp.Model.Links.Link", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("MedicusApp.Models.Doctor", b =>
                {
                    b.Navigation("WorkingHours");
                });

            modelBuilder.Entity("MedicusApp.Models.Spec", b =>
                {
                    b.Navigation("WorkingHours");
                });
#pragma warning restore 612, 618
        }
    }
}
