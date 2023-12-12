using DataAccessLayer.Interface;
using Domain.Models;
using MedApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Implementation
{
    internal class AnalysisService : IAnalysisService
    {
        protected IGenericRepository<AnalysisType> _repository;

        public AnalysisService(IGenericRepository<AnalysisType> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AnalysisType>> GetAllAnalysisTypes()
        {
            var allEntities = (await _repository.GetAllAsync()).ToList();
            return allEntities;
        }
    }
}
