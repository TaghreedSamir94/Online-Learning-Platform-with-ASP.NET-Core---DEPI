using SkillUp.BussinessLayer.DTOs.Progress;
using SkillUp.BussinessLayer.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.Services.Progress
{
    public interface IProgrssService
    {
        Task<ResultView<IEnumerable<ProgressDTO>>> GetUserProgress(int userId);
        Task UpdateProgress(ProgressDTO progressDto);
    }
}
