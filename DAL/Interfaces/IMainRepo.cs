using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMainRepo<T>
    {
        Task Create(T entity);
        IEnumerable<T> Select();
        Task Delete(T entity);
        Task<User> GetByLogin(string login);
    }
}
