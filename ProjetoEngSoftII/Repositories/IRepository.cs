using ProjetoEngSoftII.Models.Base;
using System.Collections.Generic;

namespace ProjetoEngSoftII.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
