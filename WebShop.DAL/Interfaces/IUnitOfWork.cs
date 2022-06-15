namespace WebShop.DAL.Interfaces
{
    using Entites;

    public interface IUnitOfWork : System.IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<ShopCart> ShopCarts { get; }
        IRepository<Category> Categories { get; }
    }
}
