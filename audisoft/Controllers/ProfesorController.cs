using Business.Contracts;
using Business.Entitys;
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
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesor _iProfesor;

        public ProfesorController(IProfesor iProfesor)
        {
            _iProfesor = iProfesor;
        }

        // GET: api/<ProfesorController>
        [HttpGet]
        public async Task<BaseResponse<List<BProfesor>>> Get()
        {
            return await _iProfesor.Get();
        }

        // GET api/<ProfesorController>/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<BProfesor>> Get(int id)
        {
            return await _iProfesor.GetById(id);
        }

        // POST api/<ProfesorController>
        [HttpPost]
        public async Task<BaseResponse<BProfesor>> Post(BProfesor request)
        {
            return await _iProfesor.Create(request);
        }

        // PUT api/<ProfesorController>/5
        [HttpPut("{id}")]
        public async Task<BaseResponse<BProfesor>> Put(int id, BProfesor request)
        {
            return await _iProfesor.Update(id, request);
        }

        // DELETE api/<ProfesorController>/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<BProfesor>> Delete(int id)
        {
            return await _iProfesor.Delete(id);
        }
    }
}
