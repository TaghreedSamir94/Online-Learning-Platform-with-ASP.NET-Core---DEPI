using SkillUp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkillUp.DataAccessLayer.Repositories.Enrollment
{
    public interface IProgressRepository
    {
        Progress GetUserProgress(int userId, int courseId);
        void UpdateProgress(int userId, int courseId, int completedModules);
        void CreateProgress(int userId, int courseId);
    }
}
