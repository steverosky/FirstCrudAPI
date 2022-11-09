using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp1.EFCore
{
    [Table("order")]
    public class Order
    {
        [Key, Required]
        public int OrderId { get; set; }
        public virtual Product product { get; set; }
        //public string product { get; set; }
        public string name { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        //public int product_id { get; set; }
    }
}
