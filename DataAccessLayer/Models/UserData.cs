﻿using Domain.Models.Base;
using MedApp.DataAccessLayer.Models;

namespace Domain.Models
{
    public class UserData : IBaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        virtual public UserRole UserRole { get; set; }

        // TODO: add wards. maybe we need ManyToManyRepository for it?
    }
}