using Microsoft.AspNet.Identity.EntityFramework;
using SkillUp.DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace SkillUp.DataAccessLayer
{
    [Table("Admins")]
    public class Admins : GeneralUser
    {
        public string Department { get; set; }
        public override string ToString()
        {
            return $"admin{UserName} => Department ={Department}";
        }
    }
}
