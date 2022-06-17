namespace WebShop.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebShop.DAL.Interfaces;

    public interface IShopService
    {
        // C.R.U.D operations for All entities:
        void Create(IModel model);
        Task CreateAsync(IModel model);
        IEnumerable<IModel> Read(IModel model, IUnitOfWork db);
        Task<IEnumerable<IModel>> ReadAsync(IModel model, IUnitOfWork db);
        void Update(IModel model);
        Task UpdateAsync(IModel model);
        void Delete(IModel model);
        Task DeleteAsync(IModel model);
    }
}
