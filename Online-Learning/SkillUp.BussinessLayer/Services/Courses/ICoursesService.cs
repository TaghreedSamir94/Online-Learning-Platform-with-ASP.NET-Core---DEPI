using Microsoft.AspNetCore.Http;
using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using SkillUp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.Services
{
    public interface ICoursesService
    {
        Task<List<CoursesListDTO>> GetAll();
        Task<List<HomeCoursesDTO>> GetLastCourses(int count); //to display limit num of courses in home page
		Task<CoursesDetailsDTO?> GetById(int id);
        Task AddCourses(AddCoursesDTO addcoursesDTO, IFormFile? imgUrl, string fileLocation);
        Task UpdateCourses(int id, EditCoursesDTO updatedCourses, IFormFile? imgUrl, string fileLocation);
        Task DeleteCourses(DeleteCoursesDTO deleteCoursesDTO, string fileLocation);
       
    }
}
