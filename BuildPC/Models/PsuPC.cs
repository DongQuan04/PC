namespace BuildPC.Models
{
    public class PsuPC : Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wattage { get; set; }
        public string FormFactor { get; set; }
        public string EfficiencyRating { get; set; }
        public string Modular { get; set; }
        public string Pfc { get; set; }
        public string Sata { get; set; }
        public string PciE { get; set; }
        public string Molex { get; set; }
        public string Cpu4pin { get; set; }
        public string Cpu8pin { get; set; }
        public string Warranty { get; set; }
    }
}
