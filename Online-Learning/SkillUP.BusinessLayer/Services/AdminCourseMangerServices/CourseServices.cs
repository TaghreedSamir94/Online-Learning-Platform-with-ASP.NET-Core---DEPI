

using Microsoft.AspNetCore.Http;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;
using SkillUP.DataAccessLayer.Entities;
using SkillUP.DataAccessLayer.Repositories.CourseRepositories;
using SkillUP.DataAccessLayer.Repositories.EnrollmentRepositories;

namespace SkillUP.BusinessLayer.Services.AdminCourseMangerServices
{
    public class CourseServices : ICourseServices
	{
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public CourseServices(ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository)
        {
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;

        }
        public async Task AddCourses(AddCourseDTO addcoursesDTO, IFormFile? imageFile, string fileLocation)
        {


            if (imageFile != null && imageFile.Length > 0)
            {

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                string coursesPath = Path.Combine(fileLocation, "Images", "Courses");

                if (!Directory.Exists(coursesPath)) // for ensuring dirc i want to save on it exsits & if not exsit create one 
                {
                    Directory.CreateDirectory(coursesPath);

                }
                string filePath = Path.Combine(coursesPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                addcoursesDTO.ImgUrl = fileName;  // storeing file name in database

            }
            else
            {
                addcoursesDTO.ImgUrl = "default-course.png";

			}
            var course = (Course)addcoursesDTO;

            await _courseRepository.AddAsync(course);

            await _courseRepository.SaveAsync(); //ensure changes are saned in db

        }

        public async Task DeleteCourses(DeleteCourseDTO deleteCoursesDTO, string fileLocation)
        {
            var course = await _courseRepository.GetByIdAsync(deleteCoursesDTO.Id);

            if (course == null)
            {
                throw new InvalidOperationException($"Course with ID {deleteCoursesDTO.Id} does not exist.");
            }
            if (!string.IsNullOrEmpty(course.ImgUrl))
            {
                var filePath = Path.Combine(fileLocation, "Images", "Courses", course.ImgUrl);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            await _courseRepository.DeleteAsync(course.Id);
            await _courseRepository.SaveAsync(); 
        }

        public async Task<List<CoursesListDTO>> GetAll()
        {
			var courses = await _courseRepository.GetAllCoursesWithInstructorAsync();
			return courses.Select(CoursesListDTO.MapFromEntity).ToList();
		}

        public async Task<CourseDetailsDTO?> GetById(int id)
        {
            var course = await _courseRepository.GetDetails(id);
            if (course == null)
            {
                return null;
            }
            var courseDetailsDto = CourseDetailsDTO.MapFromEntity(course);

            return courseDetailsDto; 
        }

        public async Task<CourseDetailsDTO?> GetCourseByIdWithStudent(int courseId, string studentId)
        {
            var course = await _courseRepository.GetDetails(courseId);
            if (course == null)
            {
                return null;
            }
            bool isEnrolled = await _enrollmentRepository.IsStudentEnrolledAsync(studentId, courseId);
            var courseDetailsDto = CourseDetailsDTO.MapFromEntity(course);
            courseDetailsDto.IsEnrolled = isEnrolled;
            return courseDetailsDto;
        }

        public async Task<List<NewCoursesDTO>> GetLastCourses(int count)
        {
            var courses = await _courseRepository.GetLastCoursesAsync(count);
            var newCoursesDtoList = courses.Select(NewCoursesDTO.FromEntity).ToList();

            return newCoursesDtoList;
        }

        public async Task UpdateCourses(int id, EditCourseDTO updatedCourses, IFormFile? imgUrl, string fileLocation)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                throw new InvalidOperationException($"Course with ID {id} does not exist.");
            }
            course.Title = updatedCourses.Title;
            course.Description = updatedCourses.Description;
            course.Price = updatedCourses.Price;
            course.TotalHours = updatedCourses.TotalHours;
            course.promotionVideoUrl = updatedCourses.promotionVideoUrl;
            course.InstructorId = updatedCourses.InstructorId;

            if (imgUrl != null && imgUrl.Length > 0)
            {
                if (!string.IsNullOrEmpty(course.ImgUrl)) //deloldimg
                {
                    var oldImagePath = Path.Combine(fileLocation, "Images", "Courses", course.ImgUrl);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(imgUrl.FileName); //savenewimg
                string newImagePath = Path.Combine(fileLocation, "Images", "Courses", newFileName);

                using (var fileStream = new FileStream(newImagePath, FileMode.Create))
                {
                    await imgUrl.CopyToAsync(fileStream);
                }
                course.ImgUrl = newFileName;
            }
                await _courseRepository.UpdateAsync(course);
                await _courseRepository.SaveAsync();
            
        }


        public async Task<List<CoursesListDTO>> SearchCoursesAsync(string searchTerm, float? minPrice, float? maxPrice, int? totalHours)
        {
            // Retrieve the courses based on the search criteria
            var courses = await _courseRepository.SearchCoursesAsync(searchTerm, minPrice, maxPrice, totalHours);

            // Map the courses to CoursesListDTO
            return courses.Select(CoursesListDTO.MapFromEntity).ToList();
        }
    }
}
