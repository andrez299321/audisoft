using Crosscutting.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IBaseCrud <T>
    {

        Task<BaseResponse<T>> Create(T response);
        Task<BaseResponse<T>> Delete(int id);
        Task<BaseResponse<T>> Update(int id,  T response);
        Task<BaseResponse<List<T>>> Get();
        Task<BaseResponse<T>> GetById(int id);
    }
}
