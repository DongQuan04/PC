using BuildPC.Models;
using System.Collections.Generic;

namespace BuildPC.Services
{
    public class PcCompatibilityService
    {
        public List<string> CheckCompatibility(CpuIntel cpu, Mainboard mainboard, RamPC ram, VGA vga, PsuPC psu)
        {
            List<string> issues = new List<string>();

            // 1. Kiểm tra CPU và Mainboard
            if (cpu.Socket != mainboard.Socket)
                issues.Add($"CPU socket ({cpu.Socket}) không khớp với Mainboard socket ({mainboard.Socket}).");

            if (cpu.RamType != mainboard.RamType)
                issues.Add($"CPU yêu cầu RAM loại {cpu.RamType} nhưng Mainboard chỉ hỗ trợ {mainboard.RamType}.");

            // 2. Kiểm tra RAM và Mainboard
            if (ram.RamType != mainboard.RamType)
                issues.Add($"RAM ({ram.RamType}) không tương thích với Mainboard ({mainboard.RamType}).");

            if (ram.Speed > mainboard.RamMaxSpeed)
                issues.Add($"RAM tốc độ {ram.Speed}MHz vượt quá tốc độ tối đa {mainboard.RamMaxSpeed}MHz của Mainboard.");

            // 3. Kiểm tra VGA và Mainboard
            if (!mainboard.SupportsPCIeX16)
                issues.Add("Mainboard không hỗ trợ PCIe x16 cho VGA.");

            // 4. Kiểm tra PSU có đủ công suất không
            int totalPower = cpu.TDP + vga.PowerRequirement + 100; // +100W cho linh kiện khác
            if (psu.Wattage < totalPower)
                issues.Add($"PSU {psu.Wattage}W không đủ cấp nguồn cho hệ thống (cần ít nhất {totalPower}W).");

            return issues;
        }
    }
}
