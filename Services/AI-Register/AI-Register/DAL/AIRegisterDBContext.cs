using Microsoft.EntityFrameworkCore;
using BusinessLogic.DTOs;

namespace DAL
{
    public class AIRegisterDBContext : DbContext
    {
        public AIRegisterDBContext(DbContextOptions<AIRegisterDBContext> options) : base(options)
        {
        }

        DbSet<AISystemFileDTO> AISystemFile { get; set; }
        DbSet<AISystemDTO> AISystem { get; set; }
        DbSet<CertificateDTO> Certificate { get; set; }
        DbSet<ProviderDTO> Provider { get; set; }
        DbSet<ScanCertificateDTO> ScanCertificate { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderDTO>()
                .HasKey(x => x.Id);
                
            modelBuilder.Entity<ProviderDTO>()
                .HasMany(p => p.aISystemDTO)
                .WithOne(a => a.providerDTO)
                .HasForeignKey(a => a.ProviderId);

            modelBuilder.Entity<ScanCertificateDTO>()
                .HasKey(m => m.Id);
            modelBuilder.Entity<CertificateDTO>()
                .HasOne(c => c.AISystemDTO)
                .WithOne(a => a.certificateDTO)
                .HasForeignKey<AISystemDTO>(a => a.CertificateId);

            modelBuilder.Entity<AISystemDTO>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<AISystemDTO>()
                .HasMany(a => a.fileDTOs)
                .WithOne(f => f.AISystemDTO)
                .HasForeignKey(f => f.AISystemId);
            modelBuilder.Entity<CertificateDTO>()
                .HasOne(c => c.ScanCertificate)
                .WithOne(s => s.Certificate)
                .HasForeignKey<CertificateDTO>(c => c.ScannedCertificateId);
        }
    }
}