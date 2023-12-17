using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Domain.DTO
{
    public class UserDataDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string EncryptedPassword { get; set; } = string.Empty;

        public string IconURL { get; set; } = string.Empty;

        public UserRoleDTO UserRole { get; set; }
    }
}
