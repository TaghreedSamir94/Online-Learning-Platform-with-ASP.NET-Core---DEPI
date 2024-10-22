using Microsoft.AspNetCore.Identity;
using SkillUp.DataAccessLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace SkillUp.DataAccessLayer.Entities
{
  
    [Table("Users")]
    public class GeneralUser : IdentityUser
    {
        // Properties
        public GenderEnum Gender { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
