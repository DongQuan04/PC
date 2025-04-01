namespace BuildPC.Models
{
    public class CpuAMD : Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Socket { get; set; }
        public string RamType { get; set; }
        public int TDP { get; set; }
    }
}
