using SkillUP.DataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AccountDTOs
{
	public class RegisterInstructorDTO : RegisterDTO
	{
		public string Education { get; set; }
		public string Description { get; set; }


		public static explicit operator Instructor(RegisterInstructorDTO dto)
		{
			return new Instructor
			{
                UserName = dto.Email,  
                Email = dto.Email,
                FullName = dto.FullName,
				Gender = dto.Gender,
				Education = dto.Education,
				Description = dto.Description,
				UserType = dto.Role

			};
		}
	}
}
