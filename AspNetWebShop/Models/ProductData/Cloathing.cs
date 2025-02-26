using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebShop.Models.ProductData
{
    public class Cloathing : Product
    {
        public virtual CloathingSize[]? CloathingSizes { get; set; }
    }
}
