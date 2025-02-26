using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebShop.Models.ProductData
{
    public class Footwear : Product
    {
            public required virtual FootwearSize[]? FootwearSizes { get; set; }
    }
}
