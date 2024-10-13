using SkillUp.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Entities
{
    public class EnrollmentC
    {
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }
        public int CompletedLessons { get; set; } = 0;

        public CompletionStatus CompletionStatus { get; set; } = CompletionStatus.InProgress;
        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }

        public Courses Course { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
