namespace BuildPC.Models
{
    public class SsdPC : Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; } // Dung lượng (GB, TB)
        public string Interface { get; set; } // SATA, NVMe
    }
}
