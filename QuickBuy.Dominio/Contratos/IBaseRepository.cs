using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Contratos
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        TEntity ObterPorId(int id);
        TEntity Obter(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
    }
}
