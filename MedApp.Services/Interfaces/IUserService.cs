﻿using Domain.Models;
using MedApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDataDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDataDTO>> GetAllWardsForUser(int userId);
    }
}
