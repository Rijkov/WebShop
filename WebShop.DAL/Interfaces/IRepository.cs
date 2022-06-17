namespace WebShop.DAL.Interfaces
{
    using System.Threading.Tasks;
    using System.Linq;

    public interface IRepository<IEntity> where IEntity : class
    {
        void Create(IEntity entity);
        Task CreateAsync(IEntity entity);
        IQueryable<IEntity> Read();
        Task<System.Collections.Generic.List<IEntity>> ReadAsync();
        void Update(IEntity entity);
        Task UpdateAsync(int id);
        void Delete(int id);
        Task DeleteAsync(int id);
        IEntity Get(int id);
        Task<IEntity> GetAsync(int id);
    }
}
