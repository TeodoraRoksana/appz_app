using MedApp.Domain.DTO;
using Newtonsoft.Json.Linq;

namespace Domain.Models
{
    public class AnalysisResultDTO
    {
        UserDataDTO Patient { get; set; }

        public DateTime? Time { get; set; }

        AnalysisTypeDTO AnalysisType { get; set; }

        public JObject AnalysisData { get; set; }
    }
}
