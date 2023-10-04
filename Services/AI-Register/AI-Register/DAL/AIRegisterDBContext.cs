using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AIRegisterDBContext : DbContext
    {
        public AIRegisterDBContext(DbContextOptions<AIRegisterDBContext> options) : base(options)
        {
        }

        DbSet<AISystemFileEntity> AISystemFiles { get; set; }
        DbSet<AISystemEntity> AISystems { get; set; }
        DbSet<CertificateEntity> Certificates { get; set; }
        DbSet<ProviderEntity> Providers { get; set; }
        DbSet<ScanCertificateEntity> ScanCertificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProviderEntity>()
                .HasMany(p => p.aISystemEntity)
                .WithOne(a => a.ProviderEntity)
                .HasForeignKey(a => a.ProviderId);

            modelBuilder.Entity<ScanCertificateEntity>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<CertificateEntity>()
                .HasOne(c => c.AISystemEntity)
                .WithOne(a => a.CertificateEntity)
                .HasForeignKey<AISystemEntity>(a => a.CertificateId);

            modelBuilder.Entity<AISystemEntity>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<AISystemEntity>()
                .HasMany(a => a.FileEntities)
                .WithOne(f => f.AISystemEntity)
                .HasForeignKey(f => f.AISystemId);

            modelBuilder.Entity<CertificateEntity>()
                .HasOne(c => c.ScanCertificate)
                .WithOne(s => s.Certificate)
                .HasForeignKey<CertificateEntity>(c => c.ScannedCertificateId);
        }
    }
}