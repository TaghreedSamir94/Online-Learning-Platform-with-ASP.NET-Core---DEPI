using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Entities
{
    [Table("Instructors")]
    public class Instructor : GeneralUser
    {
        public string? Education { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return $"admin{UserName} => Education ={Education} => Description ={Description}";
        }
    }
}
