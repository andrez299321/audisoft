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
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudiante _iEstudiante;

        public EstudianteController(IEstudiante iEstudiante)
        {
            _iEstudiante = iEstudiante;
        }

        // GET: api/<EstudianteController>
        [HttpGet]
        public async Task<BaseResponse<List<BEstudiante>>> Get()
        {
            return await _iEstudiante.Get();
        }

        // GET api/<EstudianteController>/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<BEstudiante>> Get(int id)
        {
            return await _iEstudiante.GetById(id);
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public async Task<BaseResponse<BEstudiante>> Post(BEstudiante request)
        {
            return await _iEstudiante.Create(request);
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public async Task<BaseResponse<BEstudiante>> Put(int id, BEstudiante request)
        {
            return await _iEstudiante.Update(id,request);
        }

        // DELETE api/<EstudianteController>/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<BEstudiante>> Delete(int id)
        {
            return await _iEstudiante.Delete(id);
        }
    }
}
