using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Entities.UserEntities
{
    public class Admin : GeneralUser
    {
        public string Department { get; set; } = "Administration";
    }
}
