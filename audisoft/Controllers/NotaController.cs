using Business.Contracts;
using Business.Entitys;
using Business.Logics;
using Crosscutting.Global;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace audisoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly INota _iNota;

        public NotaController(INota iNota)
        {
            _iNota = iNota;
        }

        // GET: api/<NotaController>
        [HttpGet]
        public async Task<BaseResponse<List<BReporteNota>>> Get()
        {
            return await _iNota.GetReport();
        }

        // GET api/<NotaController>/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<BNota>> Get(int id)
        {
            return await _iNota.GetById(id);
        }

        

        // POST api/<NotaController>
        [HttpPost]
        public async Task<BaseResponse<BNota>> Post(BNota request)
        {
            return await _iNota.Create(request);
        }

        // PUT api/<NotaController>/5
        [HttpPut("{id}")]
        public async Task<BaseResponse<BNota>> Put(int id, BNota request)
        {
            return await _iNota.Update(id, request);
        }

        // DELETE api/<NotaController>/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<BNota>> Delete(int id)
        {
            return await _iNota.Delete(id);
        }
    }
}
