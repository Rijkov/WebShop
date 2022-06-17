namespace WebShop.DAL.Entites
{
    public class ShopCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateOrder { get; set; }
        public int TotalPrice { get; set; }
        public int ItemPrice { get; set; }

    }
}
