using Microsoft.EntityFrameworkCore;

namespace StartEquity.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary keys (EF would infer this, but explicit is fine)
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Round>().HasKey(r => r.Id);
            modelBuilder.Entity<Investor>().HasKey(i => i.Id);
            modelBuilder.Entity<Investment>().HasKey(i => i.Id);
            modelBuilder.Entity<Transfer>().HasKey(t => t.Id);

            // Company -> Rounds (1-M)
            modelBuilder.Entity<Round>()
                .HasOne(r => r.Company)
                .WithMany(c => c.Rounds)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Cascade); // if you delete company, delete rounds

            // Company -> Investments (1-M)
            modelBuilder.Entity<Investment>()
                .HasOne(i => i.Company)
                .WithMany(c => c.Investments)
                .HasForeignKey(i => i.CompanyId)
                .OnDelete(DeleteBehavior.Restrict); // keep investment history safe

            // Round -> Investments (1-M)
            modelBuilder.Entity<Investment>()
                .HasOne(i => i.Round)
                .WithMany(r => r.Investments)
                .HasForeignKey(i => i.RoundId)
                .OnDelete(DeleteBehavior.Restrict);

            // Investor -> Investments (1-M)
            modelBuilder.Entity<Investment>()
                .HasOne(i => i.Investor)
                .WithMany(inv => inv.Investments)
                .HasForeignKey(i => i.InvestorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transfers: FromInvestor, ToInvestor (both restrict deletes)
            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.FromInvestor)
                .WithMany(i => i.TransfersSent)
                .HasForeignKey(t => t.FromInvestorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.ToInvestor)
                .WithMany(i => i.TransfersReceived)
                .HasForeignKey(t => t.ToInvestorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal precision (make sure property names match your model)
            modelBuilder.Entity<Company>().Property(s => s.TotalRaised).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Round>().Property(r => r.ValuationAtRound).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Round>().Property(r => r.EquityTargetPercent).HasColumnType("decimal(5,2)");
            modelBuilder.Entity<Round>().Property(r => r.RaisedAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Investor>().Property(i => i.Balance).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Investment>().Property(i => i.Amount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Investment>().Property(i => i.EquityPercent).HasColumnType("decimal(12,6)");
            modelBuilder.Entity<Transfer>().Property(t => t.EquityPercent).HasColumnType("decimal(12,6)");
            modelBuilder.Entity<Transfer>().Property(t => t.Price).HasColumnType("decimal(18,2)");

            // Optional: useful indexes
            modelBuilder.Entity<Company>().HasIndex(c => c.Name);
            modelBuilder.Entity<Round>().HasIndex(r => new { r.CompanyId, r.SequenceNumber });

            base.OnModelCreating(modelBuilder);
        }
    }
}
