using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            
            if(!UserValidationService.nameAndSurnameValidation(firstName, lastName) ||
                !UserValidationService.emailValidation(email) ||
                !UserValidationService.ageValidation(dateOfBirth))
                return false;

            var user = addUserToClientRepoAndSetAccount(firstName, lastName, email, dateOfBirth, clientId);

            if (!UserValidationService.userCreditValidation(user))
                return false;

            UserDataAccess.AddUser(user);
            return true;
        }

        private User addUserToClientRepoAndSetAccount(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            return setUserCreditAccount(user, client);
        }

        private User setUserCreditAccount(User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }

            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }
            return user;
        }
    }
}
