using AutoMapper;
using SkillUp.BussinessLayer.DTOs.EnrollmentDTOs;
using SkillUp.BussinessLayer.DTOs.Shared;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.Services.Enrollment
{
    public class EnrollmentService : IEnrollmentService
    {
       
            private readonly IEnrollmentRepository _enrollmentRepository; // Assume an interface for repository
            private readonly IMapper _mapper;

            public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper)
            {
                _enrollmentRepository = enrollmentRepository;
                _mapper = mapper;
            }

            // CREATE
            public async Task<ResultView<GetEnrollmentDTO>> CreateAsync(GetEnrollmentDTO entity)
            {
                var result = new ResultView<GetEnrollmentDTO>();

                try
                {
                   
                    if (entity == null)
                    {
                        result.IsSuccess = false;
                        result.Msg = "Invalid input: Enrollment data is null.";
                        return result;
                    }
              
                var existingEnrollment = await _enrollmentRepository.GetByIdAsync(entity.Id);

                if (existingEnrollment != null)
                    {
                        result.IsSuccess = false;
                        result.Msg = "Enrollment title already exists.";
                        return result;
                    }

                    var enrollment = _mapper.Map<EnrollmentC>(entity);
                    var createdEntity = await _enrollmentRepository.AddAsync(enrollment);

                    var returnedDTO = _mapper.Map<GetEnrollmentDTO>(createdEntity);

                    result.Entity = returnedDTO;
                    result.IsSuccess = true;
                    result.Msg = "Enrollment created successfully.";
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Msg = $"Error: {ex.Message}";
                }

                return result;
            }

            // GET ALL
            public async Task<ResultView<List<GetEnrollmentDTO>>> GetAllAsync()
            {
                var result = new ResultView<List<GetEnrollmentDTO>>();

                try
                {
                    var entities = await _enrollmentRepository.GetAllAsync();
                    var dtoList = _mapper.Map<List<GetEnrollmentDTO>>(entities);

                    result.Entity = dtoList;
                    result.IsSuccess = true;
                    result.Msg = "Enrollments retrieved successfully.";
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Msg = $"Error: {ex.Message}";
                }

                return result;
            }

            // GET BY ID
            public async Task<ResultView<GetEnrollmentDTO>> GetByIDAsync(int id)
            {
                var result = new ResultView<GetEnrollmentDTO>();

                try
                {
                    var entity = await _enrollmentRepository.GetByIdAsync(id);

                    if (entity == null)
                    {
                        result.IsSuccess = false;
                        result.Msg = "Enrollment not found.";
                        return result;
                    }

                    var dto = _mapper.Map<GetEnrollmentDTO>(entity);
                    result.Entity = dto;
                    result.IsSuccess = true;
                    result.Msg = "Enrollment retrieved successfully.";
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Msg = $"Error: {ex.Message}";
                }

                return result;
            }

            // DELETE
            public async Task<ResultView<bool>> DeleteAsync(int id)
            {
                var result = new ResultView<bool>();

                try
                {
                    var entity = await _enrollmentRepository.GetByIdAsync(id);

                    if (entity == null)
                    {
                        result.IsSuccess = false;
                        result.Msg = "Enrollment not found.";
                        return result;
                    }

                    await _enrollmentRepository.DeleteAsync(entity.Id);
                    await _enrollmentRepository.SaveAsync();

                    result.Entity = true;
                    result.IsSuccess = true;
                    result.Msg = "Enrollment deleted successfully.";
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Msg = $"Error: {ex.Message}";
                }

                return result;
            }

            // UPDATE
            public async Task<ResultView<GetEnrollmentDTO>> UpdateAsync(GetEnrollmentDTO entity)
            {
                var result = new ResultView<GetEnrollmentDTO>();

                try
                {
                    if (entity == null)
                    {
                        result.IsSuccess = false;
                        result.Msg = "Invalid input: Enrollment data is null.";
                        return result;
                    }

                    var existingEntity = await _enrollmentRepository.GetByIdAsync(entity.Id);

                    if (existingEntity == null)
                    {
                        result.IsSuccess = false;
                        result.Msg = "Enrollment not found.";
                        return result;
                    }

                    // Update the entity fields
                    existingEntity.DateAdded = entity.DateAdded;
                    existingEntity.CompletionStatus = entity.CompletionStatus;
                    existingEntity.CourseId = entity.CourseId;
                  

                    await _enrollmentRepository.UpdateAsync(existingEntity);
                    await _enrollmentRepository.SaveAsync();

                    var updatedDTO = _mapper.Map<GetEnrollmentDTO>(existingEntity);
                    result.Entity = updatedDTO;
                    result.IsSuccess = true;
                    result.Msg = "Enrollment updated successfully.";
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Msg = $"Error: {ex.Message}";
                }

                return result;
            }

   
            public Task SaveChangesAsync()
            {
            return _enrollmentRepository.SaveAsync();
        }
    }

    }

