using SkillUP.BusinessLayer.DTOs.EnrollmentDTOs;
using SkillUP.VMs.EnrollmentVMs;

namespace SkillUP.ActionRequests.EnrollmentActionRequest
{
    public class EnrollmentActionReq
    {
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public double Progress { get; set; }


        public static explicit operator EnrollmentDTO(EnrollmentActionReq request)
        {
            return new EnrollmentDTO
            {
                CourseId = request.CourseId,
                StudentId = request.StudentId,
                Progress = request.Progress
            };
        }

    }
}
