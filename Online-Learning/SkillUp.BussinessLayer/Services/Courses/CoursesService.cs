using Microsoft.AspNetCore.Http;
using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using SkillUp.BussinessLayer.Services;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories;




namespace SkillUp.BussinessLayer
{
    public class CoursesService : ICoursesService
    {
       
        private readonly ICoursesRepository _courseRepository;
        

        public CoursesService(ICoursesRepository coursesRepository)
        {
            _courseRepository = coursesRepository;
            
        }

		#region AddCourses
		public async Task AddCourses(AddCoursesDTO addcoursesDTO, IFormFile? imageFile, string fileLocation)
        {
            // Ensure title is unique (validation)
            var existingCourse = await _courseRepository.GetAllAsync();
            if (existingCourse.Any(c => c.Title == addcoursesDTO.Title))
            {
                throw new ArgumentException("A course with this title already exists.");
            }


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
				// Handle case where no image is provided (set to a default or handle as necessary)
				throw new InvalidOperationException("Image file must be provided.");
			}

			var course = addcoursesDTO.ToCourses(); // Use extension method to map Dto to entity

            await _courseRepository.AddAsync(course);

            await _courseRepository.SaveAsync(); //ensure changes are saned in db

        }
		#endregion

		#region DeleteCourses
		public async Task DeleteCourses(DeleteCoursesDTO deleteCoursesDTO, string fileLocation)
        {
            var course = await _courseRepository.GetByIdAsync(deleteCoursesDTO.ID);
            if (course == null)
			{
				throw new KeyNotFoundException("Course not found.");
			}

			if (!string.IsNullOrEmpty(course.ImgUrl))
			{
				string coursesPath = Path.Combine(fileLocation, "Images", "Courses");
				string imageFilePath = Path.Combine(coursesPath, course.ImgUrl);

				
				if (File.Exists(imageFilePath)) // delete  image if exists
				{
					File.Delete(imageFilePath);
				}
			}

			await _courseRepository.DeleteAsync(course.ID);
            await _courseRepository.SaveAsync();
        }
		#endregion

		#region GetAll
		public async Task<List<CoursesListDTO>> GetAll()
        {
            var courses = await _courseRepository.GetAllAsync();
            //map entites to Dto
            return courses.Select(c => new CoursesListDTO
            {
                ID = c.ID,
                Title = c.Title,
                Description = c.Description,
                InstructorName = c.InstructorName,
                Price = c.Price,
                TotalHours = c.TotalHours,
                ImgUrl = c.ImgUrl,
            }).ToList();
        }
		#endregion

		#region GetnewCourses
		public async Task<List<HomeCoursesDTO>> GetLastCourses(int count)
		{
			var courses = await _courseRepository.GetLastCoursesAsync(count); 


            return courses.Select(c => new HomeCoursesDTO 
			{
				ID = c.ID,
				Title = c.Title,
				Description = c.Description,
				InstructorName = c.InstructorName,
				Price = c.Price,
				TotalHours = c.TotalHours,
				ImgUrl = c.ImgUrl,
			}).ToList();

		}
		#endregion

		#region GetById
		public async Task<CoursesDetailsDTO?> GetById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) 
            {
				throw new KeyNotFoundException("Course not found.");
			} 
            //map entites to Dto
            return new CoursesDetailsDTO
			{
                ID = course.ID,
                Title = course.Title,
                Description = course.Description,
                InstructorName = course.InstructorName,
                Price = course.Price,
                TotalHours = course.TotalHours,
                ImgUrl = course.ImgUrl,
            };
        }
		#endregion

		#region UpdateCourses
		public async Task UpdateCourses(int id, EditCoursesDTO updatedCourses, IFormFile? imageFile, string fileLocation)
        {
			var course = await _courseRepository.GetByIdAsync(id);
			if (id == 0)
			{
				throw new KeyNotFoundException("Course not found.");

			}
			if (course == null)
			{
				throw new KeyNotFoundException("Course not found.");
			}


			if (imageFile != null && imageFile.Length > 0)
			{

				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

				string coursesPath = Path.Combine(fileLocation, "Images", "Courses");

				if (!Directory.Exists(coursesPath)) // for ensuring dirc i want to save on it exsits & if not exsit create one 
				{
					Directory.CreateDirectory(coursesPath);

				}

				string filePath = Path.Combine(coursesPath, fileName); //define full file path for  new image

				//delete old image while updating with new img
				if (!string.IsNullOrEmpty(course.ImgUrl))
				{
					string oldFilePath = Path.Combine(coursesPath, course.ImgUrl);
					if (File.Exists(oldFilePath))
					{
						File.Delete(oldFilePath); // Delete old image
					}
				}

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await imageFile.CopyToAsync(fileStream);
				}

				updatedCourses.ImgUrl = fileName;  // storeing  new file name in database

			}
			else
			{
				updatedCourses.ImgUrl = course.ImgUrl; // return old image if no new img provided
			}


            course.Title = updatedCourses.Title;
            course.Description = updatedCourses.Description;
            course.InstructorName = updatedCourses.InstructorName;
            course.Price = updatedCourses.Price;
            course.TotalHours = updatedCourses.TotalHours;
            course.ImgUrl = updatedCourses.ImgUrl;

            await _courseRepository.UpdateAsync(course);
            await _courseRepository.SaveAsync();

			

        }
		#endregion
	}
}

 