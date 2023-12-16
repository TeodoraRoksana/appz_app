using AutoMapper;
using Domain.Models;
using MedApp.DataAccessLayer.Models;
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

            CreateMap<UserData, UserDataDTO>();
            CreateMap<UserDataDTO, UserData>();

            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<UserRoleDTO, UserRole>();
        }
    }
}
