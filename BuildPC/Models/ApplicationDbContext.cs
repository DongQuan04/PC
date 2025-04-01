using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BuildPC.Models;

namespace BuildPC.Data // Nên đặt trong namespace Data thay vì Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Đặt tên DbSet ở dạng số nhiều (quy ước tốt nhất)
        public DbSet<CasePC> CasePCs { get; set; }
        public DbSet<CpuAMD> CpuAMDs { get; set; }
        public DbSet<CpuIntel> CpuIntels { get; set; }
        public DbSet<HddPC> HddPCs { get; set; }
        public DbSet<Heatsink> Heatsinks { get; set; }
        public DbSet<Mainboard> Mainboards { get; set; }
        public DbSet<PsuPC> PsuPCs { get; set; }
        public DbSet<RamPC> RamPCs { get; set; }
        public DbSet<SsdPC> SsdPCs { get; set; }
        public DbSet<VGA> VGAs { get; set; }
        public DbSet<VGA_RTX50> VGA_RTX50s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Quan trọng cho IdentityDbContext

            // Thêm cấu hình quan hệ giữa các entity tại đây (nếu cần)
            // Ví dụ:
            // modelBuilder.Entity<VGA_RTX50>().HasBaseType<VGA>();
        }
    }
}