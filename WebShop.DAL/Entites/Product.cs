namespace WebShop.DAL.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public string Photo { get; set; }
        public int CategoryId { get; set; }
        public bool IsStock { get; set; }
    }
}
