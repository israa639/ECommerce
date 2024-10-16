using System.Text.RegularExpressions;

namespace Service
{
    internal class UserSignUpValidator
    {
        public List<string> Validate(UserSignupDTO userSignUpDTO)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(userSignUpDTO.Email))
                errors.Add("Email can't be Empty");
            else
            {
                if (!IsValidEmail(userSignUpDTO.Email))
                { errors.Add("invalid Email"); }

            }

            if (string.IsNullOrEmpty(userSignUpDTO.UserName))
            {
                errors.Add("User name cannot be empty.");
            }


            if (string.IsNullOrEmpty(userSignUpDTO.Password) || !IsValidPassword(userSignUpDTO.Password, userSignUpDTO.ConfirmPassword))
                errors.Add("Password length should be at least 8-digits");

            return errors;

        }


        private bool IsValidEmail(String email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Regex IsEmailAddress = new Regex(@"^[A-za-z]{2,}\d{0,}@[a-z]{2,}.com$");
                return IsEmailAddress.IsMatch(email);


            }
            return false;
        }

        private bool IsValidPassword(String password, String confirmPassword)
        {
            Regex HasCharacters = new Regex(@"[A-Za-z]");
            Regex HasSpecialCharacter = new Regex(@"[!@#$%^&*(),.?""""':;{}|<>]");
            Regex Hasdigit = new Regex(@"[0-9]");

            return !string.IsNullOrEmpty(password) &&
                !string.IsNullOrEmpty(confirmPassword) &&
                password == confirmPassword &&
                password.Length > 8 &&
                HasCharacters.IsMatch(password) &&
                Hasdigit.IsMatch(password) &&
                HasSpecialCharacter.IsMatch(password);
        }


    }
}
