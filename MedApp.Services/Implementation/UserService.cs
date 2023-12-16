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
    public class UserService : IUserService
    {
        protected IGenericRepository<UserData> _userRepository;
        protected IMapper _mapper;

        public UserService(IGenericRepository<UserData> userRepository,
                               IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDataDTO> GetUserByIdAsync(int id)
        {
            var user = await GetUser(id);
            var entityDTO = _mapper.Map<UserDataDTO>(user);
            return entityDTO;
        }

        private async Task<UserData> GetUser(int id)
        {
            var user = (await _userRepository.GetByConditionAsync(user => user.Id.Equals(id))).FirstOrDefault();
            if (user == null)
            {
                throw new Exception($"no {typeof(UserData).Name} with id = {id}");
            }

            return user;
        }
    }
}
