using Business.Entitys;
using Crosscutting.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface INota : IBaseCrud<BNota>
    {
        Task<BaseResponse<List<BReporteNota>>> GetReport();
    }
}
