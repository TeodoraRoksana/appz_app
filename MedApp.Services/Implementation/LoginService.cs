using AutoMapper;
using DataAccessLayer.Interface;
using Domain.Models;
using MedApp.Domain.DTO;
using MedApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Implementation
{
    public class LoginService : ILoginService
    {
        protected IGenericRepository<UserData> _userRepository;
        protected IMapper _mapper;

        public LoginService(IGenericRepository<UserData> userRepository,
                            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<LoginResponse> LoginUser(LoginData loginData)
        {
            var user = (await _userRepository.GetByConditionAsync(user => user.Login.Equals(loginData.Login))).FirstOrDefault();

            if (user == null)
            {
                throw new Exception($"no user with login {loginData.Login}");
            }

            if (!BCrypt.Net.BCrypt.EnhancedVerify(loginData.Password, user.EncryptedPassword))
            {
                throw new Exception($"invalid password for {loginData.Login}");
            }

            return _mapper.Map<LoginResponse>(user);
        }
    }
}
