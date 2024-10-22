using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AccountDTOs
{
    public class RegisterDTO
    {
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public string ConfirmPassword { get; set; }
		public Gender Gender { get; set; }

		public string Role { get; set; }




		// Explicit operator to convert RegisterDTO to GeneralUser
		public static explicit operator GeneralUser(RegisterDTO dto)
		{
			return new GeneralUser
			{
                UserName = dto.Email,  // Ensure UserName is set
                Email = dto.Email,
                FullName = dto.FullName,
				Gender = dto.Gender,
				UserType = dto.Role
			};
		}
	}
}
