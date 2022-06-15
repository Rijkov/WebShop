namespace WebShop.BLL.DTO
{
    public class CartDTO : Interfaces.IModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateOeder { get; set; }
        public int TotalPrice { get; set; }
        public int ItemPrice { get; set; }
    }
}
