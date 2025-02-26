using AspNetWebShop.Models.ProductData;

namespace AspNetWebShop.Models.CartData
{
    public record Cart
    {
        public List<CartItem> Items { get; set; } = [];
        public decimal CartTotal => Items.Count == 0 ? 0 : Items.Sum(x => x.TotalItemPrice);

    }
    public record CartItem
    {
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalItemPrice => Product.Price * Quantity;
    }
}
