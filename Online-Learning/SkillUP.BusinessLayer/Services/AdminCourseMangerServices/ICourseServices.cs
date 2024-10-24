using Microsoft.AspNetCore.Http;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;
using SkillUP.DataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.Services.AdminCourseMangerServices
{
    public interface ICourseServices
    {
        Task AddCourses(AddCourseDTO addcoursesDTO, IFormFile? imageFile, string fileLocation);
        Task<List<CoursesListDTO>> GetAll();
        Task UpdateCourses(int id, EditCourseDTO updatedCourses, IFormFile? imgUrl, string fileLocation);
        Task DeleteCourses(DeleteCourseDTO deleteCoursesDTO, string fileLocation);
        Task<CourseDetailsDTO?> GetById(int id);
        Task<CourseDetailsDTO?> GetCourseByIdWithStudent(int id,string studentId);
        Task<List<NewCoursesDTO>> GetLastCourses(int count); //to display limit num of courses in home page

        Task<List<CoursesListDTO>> SearchCoursesAsync(string searchTerm, float? minPrice, float? maxPrice, int? totalHours);
    }
}
