using FirstApp1.EFCore;

namespace FirstApp1.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int productId { get; set; }
        public string name { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
    }
}
