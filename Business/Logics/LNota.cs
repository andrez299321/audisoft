using AutoMapper;
using Business.Contracts;
using Business.Entitys;
using Crosscutting.Global;
using DataBase.Contracts;
using DataBase.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logics
{
    public class LNota : INota
    {
        private readonly INotaServices _notaServices;
        private readonly IProfesorServices _profesorServices;
        private readonly IEstudianteServices _estudianteServices;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

       

        public LNota(INotaServices notaServices,
            IProfesorServices profesorServices,
            IEstudianteServices estudianteServices,
            IMapper mapper,
            ILog logger)
        {
            _notaServices = notaServices;
            _profesorServices = profesorServices;
            _estudianteServices = estudianteServices;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BaseResponse<BNota>> Create(BNota response)
        {
            BaseResponse<BNota> obj = null;
            try 
            { 
                Nota request = _mapper.Map<Nota>(response);
                int result = await _notaServices.CreateAsync(request);

                if (result > 0)
                {
                    obj = new BaseResponse<BNota>()
                    {
                        CodigoDeError = 0,
                        Mensaje = "OK",
                        Response = null
                    };
                }
                else
                {
                    obj = new BaseResponse<BNota>()
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

        public async Task<BaseResponse<BNota>> Delete(int id)
        {
            BaseResponse<BNota> obj = null;

            int result = await _notaServices.DeleteAsync(id);

            if (result > 0)
            {
                obj = new BaseResponse<BNota>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = null
                };
            }
            else
            {
                obj = new BaseResponse<BNota>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No se pudo crear el registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<List<BNota>>> Get()
        {
            BaseResponse<List<BNota>> obj = null;

            var result = await _notaServices.GetAsync();
            List<BNota> response = _mapper.Map<List<Nota>,List<BNota>>(result);
            if (response != null && response.Count >0)
            {
                obj = new BaseResponse<List<BNota>>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = response
                };
            }
            else
            {
                obj = new BaseResponse<List<BNota>>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No Existe ese registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<List<BReporteNota>>> GetReport()
        {
            BaseResponse<List<BReporteNota>> obj = null;

            var notas = await _notaServices.GetAsync();
            var estudiantes = await _estudianteServices.GetAsync();
            var profesores = await _profesorServices.GetAsync();
            List<BReporteNota> report = (from n in notas
                          join estu in estudiantes on n.IdEstudiante equals estu.Id
                          join prof in profesores on n.IdProfesor equals prof.Id
                          select new BReporteNota() { 
                            Id = n.Id,
                            Nombre = n.Nombre,
                            Valor = n.Valor,
                            Estudiante = estu.Nombre,
                            Profesor = prof.Nombre
                          }
                          ).ToList();

            if (report != null && report.Count > 0)
            {
                obj = new BaseResponse<List<BReporteNota>>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = report
                };
            }
            else
            {
                obj = new BaseResponse<List<BReporteNota>>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No Existe ese registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<BNota>> GetById(int id)
        {
            BaseResponse<BNota> obj = null;
            
            var result = await _notaServices.GetByIdAsync(id);
            BNota response = _mapper.Map<BNota>(result);
            if (response !=  null)
            {
                obj = new BaseResponse<BNota>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = response
                };
            }
            else
            {
                obj = new BaseResponse<BNota>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No Existe ese registro",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<BNota>> Update(int id, BNota response)
        {
            BaseResponse<BNota> obj = null;
            Nota request = _mapper.Map<Nota>(response);
            int result = await _notaServices.UpdateAsync(request, id);

            if (result > 0)
            {
                obj = new BaseResponse<BNota>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = null
                };
            }
            else
            {
                obj = new BaseResponse<BNota>()
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
