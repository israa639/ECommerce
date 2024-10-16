using Domain.Models;

namespace Domain.DTOS
{
    public class UserSignupDTO
    {

        public required string UserName { get; set; }

        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public required string Email { get; set; }
        public required Address Address { get; set; }
    }
}
