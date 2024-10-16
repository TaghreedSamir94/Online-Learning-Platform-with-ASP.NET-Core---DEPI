using AutoMapper;
using SkillUp.BussinessLayer.DTOs.EnrollmentDTOs;
using SkillUp.BussinessLayer.DTOs.Progress;
using SkillUp.BussinessLayer.DTOs.Shared;
using SkillUp.DataAccessLayer.Repositories.Progress;
using SkillUp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.Services.Progress
{
    public class ProgressService:IProgrssService
    {
        private readonly IProgressRepository _progressRepository;
        private readonly IMapper _mapper;

        public ProgressService(IProgressRepository progressRepository, IMapper mapper)
        {
            _progressRepository = progressRepository;
            _mapper = mapper;
        }

        public async Task<ResultView<IEnumerable<ProgressDTO>>> GetUserProgress(int userId)
        {
            var progressEntities = _progressRepository.GetProgressByUserId(userId);
            var progressDtos = _mapper.Map<IEnumerable<ProgressDTO>>(progressEntities);

            return new ResultView<IEnumerable<ProgressDTO>>()
            {
                Entity = progressDtos,
                IsSuccess = true,
                Msg = "Success"
            };
        }

        public async Task UpdateProgress(ProgressDTO progressDto)
        {
            var existingProgress = _mapper.Map<DataAccessLayer.Entities.Progress>(progressDto);

            _progressRepository.UpdateProgress(existingProgress);
        }
    }
}
