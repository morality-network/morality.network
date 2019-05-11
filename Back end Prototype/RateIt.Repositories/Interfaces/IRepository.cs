using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T item);
        T Update(T item);
        T Remove(T item);
        IList<T> RemoveList(IList<T> items);
        IEnumerable<T> GetAll();
        int Save();
    }
}
