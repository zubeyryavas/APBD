using System;
namespace LegacyApp
{
	public class UserValidationService
	{
		public UserValidationService()
		{
		}

		public static bool nameAndSurnameValidation(String firstName, String lastName)
		{
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }
			return true;
        }

        public static bool emailValidation(String email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }
            return true;
        }
        public static bool ageValidation(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }
            return true;
        }
        public static bool userCreditValidation(User user)
        {
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            return true;
        }
    }
}

