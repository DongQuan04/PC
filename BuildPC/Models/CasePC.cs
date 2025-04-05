using System.ComponentModel.DataAnnotations;

namespace BuildPC.Models
{
    public class CasePC : Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; } = string.Empty; // Tránh NULL bằng cách gán mặc định

        [Required]
        public string FormFactor { get; set; } = string.Empty;
    }

}

