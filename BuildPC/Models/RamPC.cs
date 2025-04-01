namespace BuildPC.Models
{
    public class RamPC : Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RamType { get; set; }
        public int RamSpeed { get; set; }
        public int RamSize { get; set; }
        public int RamModule { get; set; }
        public int Speed { get; set; } // 🔧 Thêm thuộc tính này
    }
}
