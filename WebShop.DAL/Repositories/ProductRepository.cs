namespace WebShop.DAL.Repositories
{
    using EF;
    using Entites;
    using Interfaces;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductRepository : IRepository<Product>
    {
        readonly DataContext db;

        public ProductRepository(DataContext db) => this.db = db;

        public void Create(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
        }

        public async Task CreateAsync(Product entity)
        {
            db.Products.Add(entity);
            await db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var found = Get(id);
            db.Products.Remove(found);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var found = await db.Products.FindAsync(id);
            db.Products.Remove(found);
            await db.SaveChangesAsync();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public async Task<Product> GetAsync(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public IQueryable<Product> Read()
        {
            return db.Products;
        }

        public async Task<List<Product>> ReadAsync()
        {
            var list = from p in db.Products select p;
            return await list.ToListAsync();
        }

        public void Update(Product entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.Products.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
