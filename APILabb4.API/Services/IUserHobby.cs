using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabb4.API.Services
{
    public interface IUserHobby<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetSingle(int id);
        Task<T> GetOne(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
    }
}
