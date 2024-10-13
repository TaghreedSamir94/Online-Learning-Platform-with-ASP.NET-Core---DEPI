using AutoMapper;
using SkillUp.BussinessLayer.DTOs.EnrollmentDTOs;
using SkillUp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkillUp.BussinessLayer.Services.Enrollment
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<GetEnrollmentDTO, EnrollmentC>().ReverseMap();
            CreateMap<ProgressDTO, Progress>().ReverseMap();
        }
    }
}
