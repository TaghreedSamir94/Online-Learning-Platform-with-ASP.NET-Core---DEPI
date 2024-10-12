using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Entities
{
    [Table("Students")]
    public class Student:User
    {
        public string Major { get; set; }
    }
}
