namespace BuildPC.Models
{
    public class HddPC : Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; } // Dung lượng (GB, TB)
        public int RPM { get; set; } // Tốc độ vòng quay (5400, 7200)
        public string Interface { get; set; } // SATA, NVMe,...

    }
}
