using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Entities.UserEntities
{
    public class Instructor : GeneralUser
    {
        public string? Education { get; set; }
        public string? Description { get; set; }
    }
}
