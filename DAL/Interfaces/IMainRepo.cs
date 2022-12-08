using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IMainRepo<T>
    {
        bool Create(T entity);
        T Get(int id);
        IEnumerable<T> Select();
        bool Delete(T entity);
    }
}
