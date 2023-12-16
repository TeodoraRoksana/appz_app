using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class AnalysisResult : IBaseModel
    {
        public int Id { get; set; }


        public int UserDataId { get; set; } = 0;

        [JsonIgnore]
        public UserData UserData { get; set; }


        public DateTime? Time { get; set; }


        public int AnalysisTypeId { get; set; } = 0;

        [JsonIgnore]
        public AnalysisType AnalysisType { get; set; }


        private string? _analysisData;

        [NotMapped]
        public JObject AnalysisData
        {
            get
            {
                return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(_analysisData) ? "{}" : _analysisData);
            }

            set
            {
                _analysisData = value.ToString();
            }
        }
    }
}
