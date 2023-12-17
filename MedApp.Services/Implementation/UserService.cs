using AutoMapper;
using DataAccessLayer.Interface;
using Domain.Models;
using MedApp.DataAccessLayer.Models;
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
        protected IGenericRepository<UsersWards> _usersWardsRepository;
        protected IMapper _mapper;

        public UserService(IGenericRepository<UserData> userRepository,
                           IGenericRepository<UsersWards> usersWardsRepository,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _usersWardsRepository = usersWardsRepository;
            _mapper = mapper;
        }

        public async Task<UserDataDTO> GetUserByIdAsync(int id)
        {
            var user = await GetUser(id);
            var entityDTO = _mapper.Map<UserDataDTO>(user);
            return entityDTO;
        }

        public async Task<UserData> GetUser(int id)
        {
            var user = (await _userRepository.GetByConditionAsync(user => user.Id.Equals(id))).FirstOrDefault();
            if (user == null)
            {
                throw new Exception($"no {typeof(UserData).Name} with id = {id}");
            }

            return user;
        }



        public async Task<List<UsersWardsDTO>> GetWardsIdByIdAsync(int id)
        {
            var wards = await GetWards(id);
            var entityDTO = _mapper.Map<List<UsersWardsDTO>>(wards);
            return entityDTO;
        }

        private async Task<List<UsersWards>> GetWards(int id)
        {
            var wards = (await _usersWardsRepository.GetByConditionAsync(users => users.UserId.Equals(id))).ToList();

            if (wards == null)
            {
                throw new Exception($"no {typeof(UsersWards).Name} with id = {id}");
            }

            return wards;
        }

        public async Task<IEnumerable<UserData>> GetAllWardsForUser(int userId)
        {
            // This cause exception if user does not exist
            var user = await GetUserByIdAsync(userId);

            // TODO: add patients if user is doctor
            var allWards = (await _usersWardsRepository.GetByConditionAsync(e => e.UserId.Equals(userId)));

            var usersData = allWards
                .Select(ward => new UserData
                {
                    Id = ward.WardUser.Id,
                    Login = ward.WardUser.Login,
                    Name = ward.WardUser.Name,
                    Surname = ward.WardUser.Surname,
                    EncryptedPassword = ward.WardUser.EncryptedPassword,
                    UserRole = ward.WardUser.UserRole,
                    UserRoleId = ward.WardUser.UserRoleId,
                    IconURL = ward.WardUser.IconURL
                });

            return usersData;
        }
    }
}
