using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebShop.DAL.EF;
using WebShop.DAL.Entites;
using WebShop.DAL.Interfaces;


namespace WebShop.DAL.Repositories
{
    internal class ShopCartRepository : IRepository<ShopCart>
    {
        readonly DataContext db;

        public ShopCartRepository(DataContext db) => this.db = db;

        public void Create(ShopCart entity)
        {
            db.ShopCarts.Add(entity);
            db.SaveChanges();
        }

        public async Task CreateAsync(ShopCart entity)
        {
            db.ShopCarts.Add(entity);
            await db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var found = Get(id);
            db.ShopCarts.Remove(found);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var found = await db.ShopCarts.FindAsync(id);
            db.ShopCarts.Remove(found);
            await db.SaveChangesAsync();
        }

        public ShopCart Get(int id)
        {
            return db.ShopCarts.Find(id);
        }

        public async Task<ShopCart> GetAsync(int id)
        {
            return await db.ShopCarts.FindAsync(id);
        }

        public IQueryable<ShopCart> Read()
        {
            return db.ShopCarts;
        }

        public async Task<List<ShopCart>> ReadAsync()
        {
            var list = from p in db.ShopCarts select p;
            return await list.ToListAsync();
        }

        public void Update(ShopCart entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task Update(int id)
        {
            db.Entry(await db.ShopCarts.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
