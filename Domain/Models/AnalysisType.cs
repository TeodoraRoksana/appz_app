﻿using Domain.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class AnalysisType : IBaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        private string _fieldsData;

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