using System;
using WebShop.DAL.Entites;
using WebShop.DAL.Interfaces;
using WebShop.DAL.Repositories;

namespace WebShop.DAL.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly EF.DataContext db;
        ProductRepository productRepo;
        CategoryRepository categoryRepo;
        ShopCartRepository shopCartRepo;

        public UnitOfWork(string s)
        {
            db = new EF.DataContext(s);
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepo == null)
                    productRepo = new ProductRepository(db);
                return productRepo;
            }
        }

        public IRepository<ShopCart> ShopCarts
        {
            get
            {
                if(shopCartRepo == null)
                    shopCartRepo = new ShopCartRepository(db);
                return shopCartRepo;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if(categoryRepo == null)
                    categoryRepo = new CategoryRepository(db);
                return categoryRepo;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    db.Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
