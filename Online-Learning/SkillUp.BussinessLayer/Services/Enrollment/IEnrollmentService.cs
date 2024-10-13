using SkillUp.BussinessLayer.DTOs.EnrollmentDTOs;
using SkillUp.BussinessLayer.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.Services.Enrollment
{
    public interface IEnrollmentService
    {
        public Task<ResultView<GetEnrollmentDTO>> CreateAsync(GetEnrollmentDTO entity);

        public Task<ResultView<GetEnrollmentDTO>> UpdateAsync(GetEnrollmentDTO entity);

        public Task<ResultView<bool>> DeleteAsync(int id);

        public Task<ResultView<GetEnrollmentDTO>> GetByIDAsync(int id);

        public Task<ResultView<List<GetEnrollmentDTO>>> GetAllAsync();

        public Task SaveChangesAsync();


    }
}
