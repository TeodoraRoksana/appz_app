using Domain.Models;
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.DataAccessLayer.Models
{
    public class UsersWards : IBaseModel
    { 
        public int Id { get; set; }
        public int UserId { get; set;}
        public int WardUserId { get; set; }
        public virtual UserData User {  get; set; } 
        public virtual UserData WardUser { get; set; }
    }
}
