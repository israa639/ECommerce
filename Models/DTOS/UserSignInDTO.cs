

namespace Domain.DTOS
{
    public class UserSignInDTO
    {
        public required string UserName { get; set; } = string.Empty;

        public required string Password { get; set; } = string.Empty;
    }
}
