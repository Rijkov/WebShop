using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.BLL.Helpers;
using WebShop.BLL.Interfaces;
using WebShop.DAL.Interfaces;
using WebShop.DAL.UOF;

namespace WebShop.BLL.Services
{
    public class ShopService : IShopService
    {
        readonly IUnitOfWork db;

        public ShopService(string conn)
        {
            db = new UnitOfWork(conn);
        }

        public void Create(IModel model)
        {
            try
            {
                CRUDHelpers.Create(model, db);
            }
            catch
            {
                throw new Exception($"Error on method - {nameof(Create)}({model.GetType().Name})...");
            }
        }

        public async Task CreateAsync(IModel model)
        {
            try
            {
                await CRUDHelpers.CreateAsync(model, db);
            }
            catch
            {
                throw new Exception($"Error on method - {nameof(CreateAsync)}({model.GetType().Name})...");
            }
        }

        public void Delete(IModel model)
        {
            try
            {
                CRUDHelpers.Delete(model, db);
            }
            catch
            {
                throw new Exception($"Error on method - {nameof(Delete)}({model.GetType().Name})...");

            }
        }

        public async Task DeleteAsync(IModel model)
        {
            try
            {
                await CRUDHelpers.DeleteAsync(model, db);
            }
            catch
            {
                throw new Exception($"Error on method - {nameof(DeleteAsync)}({model.GetType().Name})...");

            }
        }

        public IEnumerable<IModel> Read(IModel model, IUnitOfWork db)
        {
            try
            {
                return CRUDHelpers.Read(model, db);
            }
            catch
            {
                throw new Exception($"Error on method - {nameof(Read)}({model.GetType().Name})...");
            }

        }

        public async Task<IEnumerable<IModel>> ReadAsync(IModel model, IUnitOfWork db)
        {
            try
            {
                return await CRUDHelpers.ReadAsync(model, db);
            }
            catch
            {
                throw new Exception($"Error on method - {nameof(Read)}({model.GetType().Name})...");
            }
        }

        public void Update(IModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
