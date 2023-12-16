using Domain.Models;
using MedApp.Domain.DTO;

namespace MedApp.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginUser(LoginData loginData);
    }
}
