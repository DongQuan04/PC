namespace BuildPC.Models
{
    
        public class Heatsink : Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int TDP_Rating { get; set; } // Công suất tản nhiệt hỗ trợ (Watt)
            public string Socket { get; set; } // Socket hỗ trợ (LGA1700, AM5,...)
        }

}
