using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dadabase
{
    public interface IGenericRepositroy<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T employee);
        Task<T> GetById(int id);
        Task<T> Update(int id, T employee);
        Task<bool> Delete(int id);

    }
}
