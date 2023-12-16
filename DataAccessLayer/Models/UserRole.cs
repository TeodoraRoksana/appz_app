using Domain.Models.Base;

namespace MedApp.DataAccessLayer.Models
{
    public class UserRole : IBaseModel
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;
    }
}
