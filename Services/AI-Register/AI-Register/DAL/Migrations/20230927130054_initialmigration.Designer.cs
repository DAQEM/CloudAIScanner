﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AIRegisterDBContext))]
    [Migration("20230927130054_initialmigration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BusinessLogic.DTOs.AISystemDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CertificateId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TechnicalDocumentationLink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CertificateId")
                        .IsUnique();

                    b.HasIndex("ProviderId");

                    b.ToTable("AISystem");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.AISystemFileDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AISystemId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Filepath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Filetype")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AISystemId");

                    b.ToTable("AISystemFile");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.CertificateDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdNotifiedBody")
                        .HasColumnType("int");

                    b.Property<string>("NameNotifiedBody")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("ScannedCertificateId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ScannedCertificateId")
                        .IsUnique();

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.ProviderDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.ScanCertificateDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Filepath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ScanCertificate");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.AISystemDTO", b =>
                {
                    b.HasOne("BusinessLogic.DTOs.CertificateDTO", "certificateDTO")
                        .WithOne("AISystemDTO")
                        .HasForeignKey("BusinessLogic.DTOs.AISystemDTO", "CertificateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessLogic.DTOs.ProviderDTO", "providerDTO")
                        .WithMany("aISystemDTO")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("certificateDTO");

                    b.Navigation("providerDTO");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.AISystemFileDTO", b =>
                {
                    b.HasOne("BusinessLogic.DTOs.AISystemDTO", "AISystemDTO")
                        .WithMany("fileDTOs")
                        .HasForeignKey("AISystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AISystemDTO");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.CertificateDTO", b =>
                {
                    b.HasOne("BusinessLogic.DTOs.ScanCertificateDTO", "ScanCertificate")
                        .WithOne("Certificate")
                        .HasForeignKey("BusinessLogic.DTOs.CertificateDTO", "ScannedCertificateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScanCertificate");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.AISystemDTO", b =>
                {
                    b.Navigation("fileDTOs");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.CertificateDTO", b =>
                {
                    b.Navigation("AISystemDTO")
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessLogic.DTOs.ProviderDTO", b =>
                {
                    b.Navigation("aISystemDTO");
                });

            modelBuilder.Entity("BusinessLogic.DTOs.ScanCertificateDTO", b =>
                {
                    b.Navigation("Certificate")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
