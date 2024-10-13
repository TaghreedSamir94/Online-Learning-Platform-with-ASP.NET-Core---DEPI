using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.DTOs.EnrollmentDTOs
{
    public class ProgressDTO
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int CompletedModules { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
