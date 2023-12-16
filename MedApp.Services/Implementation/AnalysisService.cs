using AutoMapper;
using DataAccessLayer.Interface;
using Domain.Models;
using MedApp.Domain.DTO;
using MedApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Implementation
{
    public class AnalysisService : IAnalysisService
    {
        protected IGenericRepository<AnalysisType> _analysisTypeRepository;
        protected IGenericRepository<AnalysisResult> _analysisResultRepository;
        protected IUserService _usersService;
        protected IMapper _mapper;

        public AnalysisService(IGenericRepository<AnalysisType> analysisTypeRepository,
                               IGenericRepository<AnalysisResult> analysisResultRepository,
                               IUserService usersService,
                               IMapper mapper)
        {
            _analysisTypeRepository = analysisTypeRepository;
            _analysisResultRepository = analysisResultRepository;
            _usersService = usersService;
            _mapper = mapper;
        }

        #region Analysis Type

        public async Task<int> CreateAnalysisTypeAsync(AnalysisTypeDTO analysisTypeDTO)
        {
            var entity = _mapper.Map<AnalysisType>(analysisTypeDTO);
            try
            {
                await _analysisTypeRepository.CreateAsync(entity);
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"cant add {typeof(AnalysisType).Name}!", ex);
            }
        }

        public async Task DeleteAnalysisTypeByIdAsync(int id)
        {
            var entity = await GetAnalysisType(id);

            await _analysisTypeRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<AnalysisTypeDTO>> GetAllAnalysisTypesAsync()
        {
            var allEntities = (await _analysisTypeRepository.GetAllAsync()).ToList();
            var entityDTOs = _mapper.Map<List<AnalysisTypeDTO>>(allEntities);

            return entityDTOs;
        }

        public async Task<AnalysisTypeDTO> GetAnalysisTypesByIdAsync(int id)
        {
            var entity = await GetAnalysisType(id);
            var entityDTO = _mapper.Map<AnalysisTypeDTO>(entity);
            return entityDTO;
        }

        public async Task UpdateAnalysisTypeByIdAsync(int id, AnalysisTypeDTO analysisTypeDTO)
        {
            try
            {
                var entity = await GetAnalysisType(id);
                entity = _mapper.Map(analysisTypeDTO, entity);
                await _analysisTypeRepository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"cant update {typeof(AnalysisType).Name} with id = {id}", ex);
            }
        }

        private async Task<AnalysisType> GetAnalysisType(int id)
        {
            var entity = (await _analysisTypeRepository.GetByConditionAsync(e => e.Id.Equals(id))).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception($"no {typeof(AnalysisType).Name} with id = {id}");
            }

            return entity;
        }

        #endregion

        #region Analysis Result

        public async Task<AnalysisResultDTO> GetAnalysisResultByIdAsync(int id)
        {
            var entity = await GetAnalysisResult(id);
            var entityDTO = _mapper.Map<AnalysisResultDTO>(entity);
            return entityDTO;
        }

        public async Task<int> CreateAnalysisResultAsync(AnalysisResultDTO analysisResultDTO)
        {
            // TODO: Add validation
            var entity = _mapper.Map<AnalysisResult>(analysisResultDTO);
            try
            {
                await _analysisResultRepository.CreateAsync(entity);
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"cant add {typeof(AnalysisResult).Name}!", ex);
            }
        }

        public async Task UpdateAnalysisResultByIdAsync(int id, AnalysisResultDTO analysisResultDTO)
        {
            // TODO: Add validation
            try
            {
                var entity = await GetAnalysisResult(id);
                entity = _mapper.Map(analysisResultDTO, entity);
                await _analysisResultRepository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"cant update {typeof(AnalysisResult).Name} with id = {id}", ex);
            }
        }

        public async Task DeleteAnalysisResultByIdAsync(int id)
        {
            var entity = await GetAnalysisResult(id);

            await _analysisResultRepository.DeleteAsync(entity);
        }

        private async Task<AnalysisResult> GetAnalysisResult(int id)
        {
            var entity = (await _analysisResultRepository.GetByConditionAsync(e => e.Id.Equals(id))).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception($"no {typeof(AnalysisResult).Name} with id = {id}");
            }

            return entity;
        }

        #endregion

        #region User

        public async Task<IEnumerable<AnalysisShortDataDTO>> GetAllAnalysisForUser(int userId)
        {
            // This cause exception if user does not exist
            var user = await _usersService.GetUserByIdAsync(userId);

            // TODO: add patients if user is doctor
            var allAnalyses = (await _analysisResultRepository.GetByConditionAsync(e => e.UserDataId.Equals(userId)));

            return allAnalyses
                .Select(analysis => new AnalysisShortDataDTO 
                { 
                    AnalysisId = analysis.Id, 
                    AnalysisName = analysis.AnalysisType.Name,
                    PatientName = analysis.UserData.Name,
                    PatientSurname = analysis.UserData.Surname,
                    Time = analysis.Time
                });
        }

        #endregion
    }
}
