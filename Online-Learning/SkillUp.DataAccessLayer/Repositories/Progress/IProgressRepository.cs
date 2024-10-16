using SkillUp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkillUp.DataAccessLayer.Repositories.Progress
{
    public interface IProgressRepository
    {
        IEnumerable<Entities.Progress> GetProgressByUserId(int userId);
        void AddProgress(Entities.Progress progress);
        void UpdateProgress(Entities.Progress progress);
    }
}
