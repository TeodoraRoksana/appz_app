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
        protected IGenericRepository<AnalysisType> _repository;
        protected IMapper _mapper;

        public AnalysisService(IGenericRepository<AnalysisType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAnalysisTypeAsync(AnalysisTypeDTO analysisTypeDTO)
        {
            var entity = _mapper.Map<AnalysisType>(analysisTypeDTO);
            try
            {
                await _repository.CreateAsync(entity);
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

            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<AnalysisTypeDTO>> GetAllAnalysisTypesAsync()
        {
            var allEntities = (await _repository.GetAllAsync()).ToList();
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
                await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"cant update {typeof(AnalysisType).Name} with id = {id}", ex);
            }
        }

        private async Task<AnalysisType> GetAnalysisType(int id)
        {
            var entity = (await _repository.GetByConditionAsync(e => e.Id.Equals(id))).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception($"no {typeof(AnalysisType).Name} with id = {id}");
            }

            return entity;
        }
    }
}
