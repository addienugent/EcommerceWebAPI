using System;
namespace EcommerceWebAPI.Repository
{

    public class Repository : IRepository
    {
       
        public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Delete<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void CreateProduct<TEntity>(TEntity entity, string name = null) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}

