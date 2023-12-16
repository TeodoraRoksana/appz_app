using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Domain.DTO
{
    public class LoginData
    {
        public string Login { get; set; } = string.Empty;

        public string EncryptedPassword { get; set; } = string.Empty;
    }
}
