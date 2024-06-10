﻿// <auto-generated />
using System;
using CourseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseLibrary.Migrations
{
    [DbContext(typeof(ProjetVoilierContext))]
    [Migration("20240528090330_newMig")]
    partial class newMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CourseLibrary.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("CourseLibrary.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("longtext");

                    b.Property<string>("VoilierEnCourseCode")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("VoilierEnCourseCode");

                    b.ToTable("Entreprise");
                });

            modelBuilder.Entity("CourseLibrary.Epreuve", b =>
                {
                    b.Property<int>("Num")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .HasColumnType("longtext");

                    b.Property<int>("Ordre")
                        .HasColumnType("int");

                    b.Property<string>("VoilierEnCourseCode")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Num");

                    b.HasIndex("CourseId");

                    b.HasIndex("VoilierEnCourseCode");

                    b.ToTable("Epreuves");
                });

            modelBuilder.Entity("CourseLibrary.Penalite", b =>
                {
                    b.Property<int>("VoilierEnCourseId")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<int?>("EpreuveNum")
                        .HasColumnType("int");

                    b.Property<string>("TypePenaliteCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VoilierEnCourseCode")
                        .HasColumnType("varchar(255)");

                    b.HasKey("VoilierEnCourseId", "Latitude", "Longitude");

                    b.HasIndex("EpreuveNum");

                    b.HasIndex("TypePenaliteCode");

                    b.HasIndex("VoilierEnCourseCode");

                    b.ToTable("Penalite");
                });

            modelBuilder.Entity("CourseLibrary.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .HasColumnType("longtext");

                    b.Property<string>("CodePostal")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .HasColumnType("longtext");

                    b.Property<string>("Pays")
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .HasColumnType("longtext");

                    b.Property<string>("Ville")
                        .HasColumnType("longtext");

                    b.Property<string>("VoilierCode")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("VoilierCode");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("CourseLibrary.TypePenalite", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .HasColumnType("longtext");

                    b.HasKey("Code");

                    b.ToTable("TypePenalite");
                });

            modelBuilder.Entity("CourseLibrary.Voilier", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)");

                    b.HasKey("Code");

                    b.ToTable("Voilier");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Voilier");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CourseLibrary.VoilierEnCourse", b =>
                {
                    b.HasBaseType("CourseLibrary.Voilier");

                    b.Property<string>("CodeInscritption")
                        .HasColumnType("longtext");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("Desistement")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TempsBrut")
                        .HasColumnType("int");

                    b.HasIndex("CourseId");

                    b.HasDiscriminator().HasValue("VoilierEnCourse");
                });

            modelBuilder.Entity("CourseLibrary.Entreprise", b =>
                {
                    b.HasOne("CourseLibrary.VoilierEnCourse", null)
                        .WithMany("Sponsors")
                        .HasForeignKey("VoilierEnCourseCode");
                });

            modelBuilder.Entity("CourseLibrary.Epreuve", b =>
                {
                    b.HasOne("CourseLibrary.Course", "Course")
                        .WithMany("Epreuves")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseLibrary.VoilierEnCourse", null)
                        .WithMany("EpreuvesEffectuees")
                        .HasForeignKey("VoilierEnCourseCode");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseLibrary.Penalite", b =>
                {
                    b.HasOne("CourseLibrary.Epreuve", "Epreuve")
                        .WithMany()
                        .HasForeignKey("EpreuveNum");

                    b.HasOne("CourseLibrary.TypePenalite", "TypePenalite")
                        .WithMany()
                        .HasForeignKey("TypePenaliteCode");

                    b.HasOne("CourseLibrary.VoilierEnCourse", null)
                        .WithMany("Penalites")
                        .HasForeignKey("VoilierEnCourseCode");

                    b.Navigation("Epreuve");

                    b.Navigation("TypePenalite");
                });

            modelBuilder.Entity("CourseLibrary.Personne", b =>
                {
                    b.HasOne("CourseLibrary.Voilier", null)
                        .WithMany("Equipage")
                        .HasForeignKey("VoilierCode");
                });

            modelBuilder.Entity("CourseLibrary.VoilierEnCourse", b =>
                {
                    b.HasOne("CourseLibrary.Course", "Course")
                        .WithMany("Participants")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseLibrary.Course", b =>
                {
                    b.Navigation("Epreuves");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("CourseLibrary.Voilier", b =>
                {
                    b.Navigation("Equipage");
                });

            modelBuilder.Entity("CourseLibrary.VoilierEnCourse", b =>
                {
                    b.Navigation("EpreuvesEffectuees");

                    b.Navigation("Penalites");

                    b.Navigation("Sponsors");
                });
#pragma warning restore 612, 618
        }
    }
}