using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.DTOs.EnrollmentDTOs
{
    public class GetEnrollmentDTO
    {
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        public CompletionStatus CompletionStatus { get; set; } = CompletionStatus.NotStarted;
        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
        [ForeignKey(nameof(User))]
        public  int UserId { get; set; }
    }
}
