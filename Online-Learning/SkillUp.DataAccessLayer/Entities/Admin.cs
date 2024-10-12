using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Entities
{
    [Table("Admins")]
    public class Admin : User
    {
        public string AdminCode { get; set; }
    }
}
