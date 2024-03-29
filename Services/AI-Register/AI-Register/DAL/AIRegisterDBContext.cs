﻿using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AIRegisterDBContext : DbContext
    {
        public AIRegisterDBContext(DbContextOptions<AIRegisterDBContext> options) : base(options)
        {
        }

        public DbSet<AISystemFileEntity> AISystemFiles { get; set; }
        public DbSet<AISystemEntity> AISystems { get; set; }
        public DbSet<CertificateEntity> Certificates { get; set; }
        public DbSet<ProviderEntity> Providers { get; set; }
        public DbSet<ScanCertificateEntity> ScanCertificates { get; set; }
        public DbSet<AuthorisedRepresentativesEntity> AuthorisedRepresentatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProviderEntity>()
                .HasMany(p => p.aISystemEntity)
                .WithOne(a => a.ProviderEntity)
                .HasForeignKey(a => a.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScanCertificateEntity>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<CertificateEntity>()
                .HasOne(c => c.AISystemEntity)
                .WithOne(a => a.CertificateEntity)
                .HasForeignKey<AISystemEntity>(a => a.CertificateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AISystemEntity>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<AISystemEntity>()
                .HasMany(a => a.FileEntities)
                .WithOne(f => f.AISystemEntity)
                .HasForeignKey(f => f.AISystemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CertificateEntity>()
                .HasOne(c => c.ScanCertificate)
                .WithOne(s => s.Certificate)
                .HasForeignKey<CertificateEntity>(c => c.ScannedCertificateId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ProviderEntity>()
                .HasMany(p => p.authorisedReperesentitiveEntity)
                .WithOne(a => a.Provider)
                .HasForeignKey(a => a.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AISystemEntity>()
                .HasIndex(a => a.UnambiguousReference)
                .IsUnique();
        }
    }
}