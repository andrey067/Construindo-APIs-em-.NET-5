using Manager.Domain.Entities;
using System.Threading.Task;
using System.Colletions.Generic;


namespace Manager.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<T> Remove(T long);
        Task<T> Get(T long);
        Task<List<T>> Get();


    }

}


