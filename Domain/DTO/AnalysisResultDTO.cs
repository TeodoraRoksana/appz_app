using MedApp.Domain.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class AnalysisResultDTO
    {
        [JsonProperty("patient_id")]
        public int UserDataId { get; set; } = 0;

        [JsonProperty("date")]
        public DateTime? Time { get; set; }

        [JsonProperty("type_id")]
        public int AnalysisTypeId { get; set; }

        [JsonProperty("results")]
        public JArray AnalysisData { get; set; }
    }
}
