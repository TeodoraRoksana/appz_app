using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MedApp.Domain.DTO
{
    public class AnalysisTypeDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("fields")]
        public JArray FieldsData { get; set; }
    }
}
