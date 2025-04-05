using System.ComponentModel.DataAnnotations;

namespace BuildPC.Models
{
    public class CpuIntel: Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; } = string.Empty; // 🔧 Đảm bảo không NULL

        [Required]
        [MinLength(1)]
        public string Socket { get; set; } = string.Empty; // 🔧 Đảm bảo không NULL

        [Required]
        [MinLength(1)]
        public string RamType { get; set; } = "Unknown"; // 🔧 Đặt giá trị mặc định

        public int TDP { get; set; }
    }
}
