using SkillUP.ActionRequests.EnrollmentActionRequest;
using SkillUP.DataAccessLayer.Entities;

namespace SkillUP.VMs.EnrollmentVMs
{
    public class EnrollmentVM
    {
        public int CourseId { get; set; }
        public string StudentId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseImageUrl { get; set; }
        public double Progress { get; set; }


        public static explicit operator EnrollmentVM(EnrollmentActionReq request)
        {
            return new EnrollmentVM
            {
                CourseId = request.CourseId,
                StudentId = request.StudentId,
                Progress = request.Progress
            };
        }
    }
}
