using Newtonsoft.Json;

namespace MedApp.Domain.DTO
{
    public class AnalysisShortDataDTO
    {
        [JsonProperty("id")]
        public int AnalysisId { get; set; } = 0;

        [JsonProperty("type")]
        public string AnalysisName { get; set; } = string.Empty;

        [JsonProperty("patient_name")]
        public string PatientName { get; set; } = string.Empty;

        [JsonProperty("patient_surname")]
        public string PatientSurname { get; set; } = string.Empty;

        [JsonProperty("date")]
        public string? Date { get; set; }
    }
}
