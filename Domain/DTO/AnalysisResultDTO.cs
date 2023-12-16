using MedApp.Domain.DTO;
using Newtonsoft.Json.Linq;

namespace Domain.Models
{
    public class AnalysisResultDTO
    {
        UserDataDTO Patient { get; set; }

        public DateTime? Time { get; set; }

        AnalysisTypeDTO AnalysisType { get; set; }

        public JArray AnalysisData { get; set; }
    }
}
