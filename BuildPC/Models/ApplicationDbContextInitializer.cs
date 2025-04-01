using Microsoft.EntityFrameworkCore;
using BuildPC.SeedData;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BuildPC.Data;

namespace BuildPC.Models
{
    public class ApplicationDbContextInitializer
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Ensure the database is created
            await _context.Database.EnsureCreatedAsync();

            await SeedProducts<CasePC>("SeedData/Case-PC.csv");
            await SeedProducts<CpuAMD>("SeedData/Cpu-AMD.csv");
            await SeedProducts<CpuIntel>("SeedData/Cpu-Intel.csv");
            await SeedProducts<HddPC>("SeedData/HDD-PC.csv");
            await SeedProducts<Heatsink>("SeedData/Heatsink-PC.csv");
            await SeedProducts<Mainboard>("SeedData/Mainboard_gearvn.csv");
            await SeedProducts<PsuPC>("SeedData/PSU-PC.csv");
            await SeedProducts<RamPC>("SeedData/Ram-PC.csv");
            await SeedProducts<SsdPC>("SeedData/SSD-PC.csv");
            await SeedProducts<VGA>("SeedData/VGA-Geforce-Radeon_gearvn.csv");
            await SeedProducts<VGA_RTX50>("SeedData/VGA-RTX50-series_gearvn.csv");

            await _context.SaveChangesAsync();
        }

        private async Task SeedProducts<T>(string filePath) where T : Product, new()
        {
            if (await _context.Set<T>().AnyAsync()) return; // Skip if data already exists

            var productNames = csv_reader.ReadCsvFile(filePath);
            var products = productNames.Select((name, index) => new T { Name = name }).ToList();

            if (products.Any())
            {
                await _context.Set<T>().AddRangeAsync(products);
            }
        }
    }
}
