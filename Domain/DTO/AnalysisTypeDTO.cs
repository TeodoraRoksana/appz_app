using Newtonsoft.Json.Linq;

namespace MedApp.Domain.DTO
{
    public class AnalysisTypeDTO
    {
        public string Name { get; set; } = string.Empty;

        public JArray FieldsData { get; set; }
    }
}
