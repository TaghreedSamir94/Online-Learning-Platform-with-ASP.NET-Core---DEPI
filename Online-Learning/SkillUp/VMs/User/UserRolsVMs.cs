namespace SkillUp.VMs.User
{
    public class UserRolsVMs
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }
    }
}
