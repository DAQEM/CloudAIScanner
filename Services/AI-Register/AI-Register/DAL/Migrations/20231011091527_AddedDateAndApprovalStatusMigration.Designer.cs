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
    [Migration("20231011091527_AddedDateAndApprovalStatusMigration")]
    partial class AddedDateAndApprovalStatusMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BusinessLogic.Entities.AISystemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("CertificateId")
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("DateAdded")
                        .HasColumnType("date");

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

                    b.ToTable("AISystems");
                });

            modelBuilder.Entity("BusinessLogic.Entities.AISystemFileEntity", b =>
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

                    b.ToTable("AISystemFiles");
                });

            modelBuilder.Entity("BusinessLogic.Entities.CertificateEntity", b =>
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

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("BusinessLogic.Entities.ProviderEntity", b =>
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

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("BusinessLogic.Entities.ScanCertificateEntity", b =>
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

                    b.ToTable("ScanCertificates");
                });

            modelBuilder.Entity("BusinessLogic.Entities.AISystemEntity", b =>
                {
                    b.HasOne("BusinessLogic.Entities.CertificateEntity", "CertificateEntity")
                        .WithOne("AISystemEntity")
                        .HasForeignKey("BusinessLogic.Entities.AISystemEntity", "CertificateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessLogic.Entities.ProviderEntity", "ProviderEntity")
                        .WithMany("aISystemEntity")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CertificateEntity");

                    b.Navigation("ProviderEntity");
                });

            modelBuilder.Entity("BusinessLogic.Entities.AISystemFileEntity", b =>
                {
                    b.HasOne("BusinessLogic.Entities.AISystemEntity", "AISystemEntity")
                        .WithMany("FileEntities")
                        .HasForeignKey("AISystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AISystemEntity");
                });

            modelBuilder.Entity("BusinessLogic.Entities.CertificateEntity", b =>
                {
                    b.HasOne("BusinessLogic.Entities.ScanCertificateEntity", "ScanCertificate")
                        .WithOne("Certificate")
                        .HasForeignKey("BusinessLogic.Entities.CertificateEntity", "ScannedCertificateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScanCertificate");
                });

            modelBuilder.Entity("BusinessLogic.Entities.AISystemEntity", b =>
                {
                    b.Navigation("FileEntities");
                });

            modelBuilder.Entity("BusinessLogic.Entities.CertificateEntity", b =>
                {
                    b.Navigation("AISystemEntity")
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessLogic.Entities.ProviderEntity", b =>
                {
                    b.Navigation("aISystemEntity");
                });

            modelBuilder.Entity("BusinessLogic.Entities.ScanCertificateEntity", b =>
                {
                    b.Navigation("Certificate")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
