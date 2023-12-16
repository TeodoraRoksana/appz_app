using Domain.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class AnalysisType : IBaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        private string _fieldsData;

        [JsonProperty("fields")]
        [NotMapped]
        public JArray FieldsData
        {
            get
            {
                return JsonConvert.DeserializeObject<JArray>(string.IsNullOrEmpty(_fieldsData) ? "[]" : _fieldsData);
            }

            set
            {
                _fieldsData = value.ToString();
            }
        }
    }
}
