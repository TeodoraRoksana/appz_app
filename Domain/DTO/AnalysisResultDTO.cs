using MedApp.Domain.DTO;
using Newtonsoft.Json.Linq;

namespace Domain.Models
{
    public class AnalysisResultDTO
    {
        public int UserDataId { get; set; } = 0;

        public DateTime? Time { get; set; }

        public int AnalysisTypeId { get; set; }

        public JArray AnalysisData { get; set; }
    }
}
