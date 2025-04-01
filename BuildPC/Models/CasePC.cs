using System.ComponentModel.DataAnnotations;

namespace BuildPC.Models
{
    public class CasePC : Product
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string FormFactor { get; set; } // ATX, Micro-ATX, ITX, ... các case pc

    }

}
