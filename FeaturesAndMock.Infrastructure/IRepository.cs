using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace FeaturesAndMock.Infrastructure
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void AddClient(TEntity obj);
        TEntity GetClientById(Guid id);
        IEnumerable<TEntity> GetallClients();
        void UpdateClient(TEntity obj);
        void RemoveClient(Guid id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);//Buscar????
        int Commit();
    }
}
