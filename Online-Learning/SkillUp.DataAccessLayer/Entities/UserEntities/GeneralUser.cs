using Microsoft.AspNetCore.Identity;
using SkillUp.DataAccessLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace SkillUp.DataAccessLayer.Entities.UserEntities
{
    public class GeneralUser : IdentityUser
    {
        public GenderEnum Gender { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
