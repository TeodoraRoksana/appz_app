using Domain.Models;
using MedApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Interfaces
{
    public interface IAnalysisService
    {
        Task<IEnumerable<AnalysisTypeDTO>> GetAllAnalysisTypesAsync();

        Task<AnalysisTypeDTO> GetAnalysisTypesByIdAsync(int id);

        Task<int> CreateAnalysisTypeAsync(AnalysisTypeDTO analysisTypeDTO);

        Task UpdateAnalysisTypeByIdAsync(int id, AnalysisTypeDTO analysisTypeDTO);

        Task DeleteAnalysisTypeByIdAsync(int id);
    }
}
