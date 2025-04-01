namespace BuildPC.Models
{
    public class Mainboard : Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Socket { get; set; }
        public string RamType { get; set; }
        public int RamMaxSpeed { get; set; }
        public bool SupportsPCIeX16 { get; set; }

    }
}
