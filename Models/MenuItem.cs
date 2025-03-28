namespace App_Cafe.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } // Ví dụ: Espresso, Latte, v.v.
        public string ImageUrl { get; set; } // Đường dẫn ảnh nếu có
    }
}