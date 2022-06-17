using System.Collections.Generic;
using System.Data.Entity;
using System.Linq; 
using System.Threading.Tasks;
using WebShop.DAL.EF;
using WebShop.DAL.Entites;
using WebShop.DAL.Interfaces;

namespace WebShop.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        readonly DataContext db;

        public CategoryRepository(DataContext db) => this.db = db;

        public void Create(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public async Task CreateAsync(Category entity)
        {
            db.Categories.Add(entity);
            await db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var found = Get(id);
            db.Categories.Remove(found);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var found = await db.Categories.FindAsync(id);
            db.Categories.Remove(found);
            await db.SaveChangesAsync();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public async Task<Category> GetAsync(int id)
        {
            return await db.Categories.FindAsync(id);
        }

        public IQueryable<Category> Read()
        {
            return db.Categories;
        }

        public async Task<List<Category>> ReadAsync()
        {
            var list = from p in db.Categories select p;
            return await list.ToListAsync();
        }

        public void Update(Category entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.Categories.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}

