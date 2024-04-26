using AutoMapper;
using Business.Contracts;
using Business.Entitys;
using Crosscutting.Global;
using DataBase.Contracts;
using DataBase.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logics
{
    public class LEstudiante : IEstudiante
    {
        private readonly IEstudianteServices _estudianteServices;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public LEstudiante(IEstudianteServices estudianteServices, IMapper mapper, ILog logger)
        {
            _estudianteServices = estudianteServices;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BaseResponse<BEstudiante>> Create(BEstudiante response)
        {
            BaseResponse<BEstudiante> obj = null;
            try
            {
                Estudiante request = _mapper.Map<Estudiante>(response);
                int result = await _estudianteServices.CreateAsync(request);

                if (result > 0)
                {
                    obj = new BaseResponse<BEstudiante>()
                    {
                        CodigoDeError = 0,
                        Mensaje = "OK",
                        Response = null
                    };
                }
                else
                {
                    obj = new BaseResponse<BEstudiante>()
                    {
                        CodigoDeError = 99,
                        Mensaje = "No se pudo crear el registro",
                        Response = null
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message,ex);
            }
            return obj;
        }

        public async Task<BaseResponse<BEstudiante>> Delete(int id)
        {
            BaseResponse<BEstudiante> obj = null;

            var result = 0;
            try
            {
                result = await _estudianteServices.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            if (result > 0)
            {
                obj = new BaseResponse<BEstudiante>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = null
                };
            }
            else
            {
                obj = new BaseResponse<BEstudiante>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No se pudo crear el registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<List<BEstudiante>>> Get()
        {
            BaseResponse<List<BEstudiante>> obj = null;

            var result = await _estudianteServices.GetAsync();
            List<BEstudiante> response = _mapper.Map<List<Estudiante>,List<BEstudiante>>(result);
            if (response != null && response.Count >0)
            {
                obj = new BaseResponse<List<BEstudiante>>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = response
                };
            }
            else
            {
                obj = new BaseResponse<List<BEstudiante>>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No Existe ese registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<BEstudiante>> GetById(int id)
        {
            BaseResponse<BEstudiante> obj = null;
            
            var result = await _estudianteServices.GetByIdAsync(id);
            BEstudiante response = _mapper.Map<BEstudiante>(result);
            if (response !=  null)
            {
                obj = new BaseResponse<BEstudiante>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = response
                };
            }
            else
            {
                obj = new BaseResponse<BEstudiante>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No Existe ese registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<BEstudiante>> Update(int id, BEstudiante response)
        {
            BaseResponse<BEstudiante> obj = null;
            Estudiante request = _mapper.Map<Estudiante>(response);
            int result = await _estudianteServices.UpdateAsync(request, id);

            if (result > 0)
            {
                obj = new BaseResponse<BEstudiante>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = null
                };
            }
            else
            {
                obj = new BaseResponse<BEstudiante>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No se pudo actualizar el registro",
                    Response = null
                };
            }
            return obj;
        }
    }
}
