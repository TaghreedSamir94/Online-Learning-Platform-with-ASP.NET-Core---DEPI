using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Entities
{
    [Table("Students")]
    public class Student:GeneralUser
    {
        public string? University { get; set; }
        public override string ToString()
        {
            return $"admin{UserName} => University ={University}";
        }
    }
}
