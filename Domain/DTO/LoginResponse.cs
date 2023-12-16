namespace MedApp.Domain.DTO
{
    public class LoginResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int UserRoleId { get; set; } = 0;
    }
}
