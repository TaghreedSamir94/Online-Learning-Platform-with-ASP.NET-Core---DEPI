using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Entities
{
    public class Progress
    {
        public int ProgressId { get; set; }
        public int CompletedModules { get; set; }
        public DateTime LastUpdated { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; }
        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }

        public Courses Course { get; set; }
       
    }
}
