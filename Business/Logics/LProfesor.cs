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
    public class LProfesor : IProfesor
    {
        private readonly IProfesorServices _profesorServices;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public LProfesor(IProfesorServices profesorServices, IMapper mapper, ILog logger)
        {
            _profesorServices = profesorServices;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BaseResponse<BProfesor>> Create(BProfesor response)
        {
            BaseResponse<BProfesor> obj = null;
            try 
            { 
                Profesor request = _mapper.Map<Profesor>(response);
                int result = await _profesorServices.CreateAsync(request);

                if (result > 0)
                {
                    obj = new BaseResponse<BProfesor>()
                    {
                        CodigoDeError = 0,
                        Mensaje = "OK",
                        Response = null
                    };
                }
                else
                {
                    obj = new BaseResponse<BProfesor>()
                    {
                        CodigoDeError = 99,
                        Mensaje = "No se pudo crear el registro",
                        Response = null
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }
            return obj;
        }

        public async Task<BaseResponse<BProfesor>> Delete(int id)
        {
            BaseResponse<BProfesor> obj = null;
            int result = 0;
            try
            {
                result = await _profesorServices.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message,ex);
            }
            

            if (result > 0)
            {
                obj = new BaseResponse<BProfesor>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = null
                };
            }
            else
            {
                obj = new BaseResponse<BProfesor>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No se pudo crear el registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<List<BProfesor>>> Get()
        {
            BaseResponse<List<BProfesor>> obj = null;

            var result = await _profesorServices.GetAsync();
            List<BProfesor> response = _mapper.Map<List<Profesor>,List<BProfesor>>(result);
            if (response != null && response.Count >0)
            {
                obj = new BaseResponse<List<BProfesor>>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = response
                };
            }
            else
            {
                obj = new BaseResponse<List<BProfesor>>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No Existe ese registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<BProfesor>> GetById(int id)
        {
            BaseResponse<BProfesor> obj = null;
            
            var result = await _profesorServices.GetByIdAsync(id);
            BProfesor response = _mapper.Map<BProfesor>(result);
            if (response !=  null)
            {
                obj = new BaseResponse<BProfesor>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = response
                };
            }
            else
            {
                obj = new BaseResponse<BProfesor>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No Existe ese registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<BProfesor>> Update(int id, BProfesor response)
        {
            BaseResponse<BProfesor> obj = null;
            Profesor request = _mapper.Map<Profesor>(response);
            int result = await _profesorServices.UpdateAsync(request, id);

            if (result > 0)
            {
                obj = new BaseResponse<BProfesor>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = null
                };
            }
            else
            {
                obj = new BaseResponse<BProfesor>()
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
