using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildPC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
    }
}
