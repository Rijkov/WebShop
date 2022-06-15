namespace WebShop.DAL.EF
{
    using System.Data.Entity;
    using WebShop.DAL.Entites;

    public class DataContext : DbContext
    {
        public DataContext(string con):base(con)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ShopCart> ShopCarts { get; set; }

    }
}
