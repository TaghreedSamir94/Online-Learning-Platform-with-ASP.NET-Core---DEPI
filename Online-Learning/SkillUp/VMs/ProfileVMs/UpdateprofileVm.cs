namespace SkillUP.VMs.ProfileVMs
{
    public class UpdateprofileVm
    {        
        public string CurrentEmail { get; set; }

        public string CurrentUserName { get; set; }
        public string NewUserName { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
