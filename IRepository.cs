using System;
namespace EcommerceWebAPI.Repository
{
    public interface IRepository
    {
        void CreateProduct<TEntity>(TEntity entity, string name = null)
          where TEntity : class;


        void Delete<TEntity>(object id)
          where TEntity : class;

        void Update<TEntity>(TEntity entity, string updateitem = null)
          where TEntity : class;

        void Save();

        Task SaveAsync();
    }
}

