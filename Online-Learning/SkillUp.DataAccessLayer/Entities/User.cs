using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace SkillUp.DataAccessLayer.Entities
{
  
    [Table("Users")]
    public class User : IdentityUser
    {
        // Properties
        public string TypeOfUser { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public ICollection<EnrollmentC> Enrollments { get; set; }
    }
}
