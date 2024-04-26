using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Contracts
{
    public interface IBaseCrudServices<T>
    {

        Task<int> CreateAsync(T response);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T response, int id);
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
    }
}
