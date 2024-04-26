using AutoMapper;
using Business.Entitys;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Mapper
{
    public class UtilityProfile : Profile
    {
        public UtilityProfile() {
            CreateMap<BEstudiante, Estudiante>().ReverseMap();
            CreateMap<BNota, Nota>().ReverseMap();
            CreateMap<BProfesor, Profesor>().ReverseMap();

        }
    }
}
