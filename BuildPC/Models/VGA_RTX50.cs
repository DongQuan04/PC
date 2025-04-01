namespace BuildPC.Models
{
    public class VGA_RTX50 : Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Chipset { get; set; }
        public int MemorySize { get; set; }
        public int MemoryType { get; set; }
        public int MemorySpeed { get; set; }
        public int CoreClock { get; set; }
        public int BoostClock { get; set; }
        public int Wattage { get; set; }
    }
}
