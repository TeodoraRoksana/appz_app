using AutoMapper;
using Domain.Models;
using MedApp.Domain.DTO;

namespace MedApp.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AnalysisResult, AnalysisResultDTO>();
            CreateMap<AnalysisResultDTO, AnalysisResult>();
            CreateMap<AnalysisType, AnalysisTypeDTO>();
            CreateMap<AnalysisTypeDTO, AnalysisType>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
        }
    }
}
