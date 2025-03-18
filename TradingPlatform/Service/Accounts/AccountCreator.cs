using System;
using TradingPlatform.Repository;

namespace TradingPlatform.Service.Accounts
{
    public class AccountCreator
    {
        private readonly ICreateAccountRepository createAccountRepository;
        private readonly IGetAccountRepository getAccountRepository;
        private readonly LoginValidator loginValidator;
        private readonly PasswordValidator passwordValidator;

        public AccountCreator(
            ICreateAccountRepository createAccountRepository,
            IGetAccountRepository getAccountRepository,
            LoginValidator loginValidator,
            PasswordValidator passwordValidator)
        {
            this.createAccountRepository = createAccountRepository;
            this.getAccountRepository = getAccountRepository;
            this.loginValidator = loginValidator;
            this.passwordValidator = passwordValidator;
        }

        public CreateAccountResult CreateAccount(string login, string password)
        {
            try
            {
                if (loginValidator.IsLoginValid(login) == false)
                {
                    return CreateAccountResult.InvalidLogin;
                }
                else if (passwordValidator.IsPasswordValid(password) == false)
                {
                    return CreateAccountResult.InvalidPassword;
                }
                else if (getAccountRepository.GetAccount(login) != null)
                {
                    return CreateAccountResult.AlreadyExists;
                }
                else
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                    createAccountRepository.CreateAccount(login, hashedPassword);
                    return CreateAccountResult.Success;
                }
            }
            catch
            {
                return CreateAccountResult.Failure;
            }
        }
    }

    public enum CreateAccountResult
    {
        Success,
        Failure,
        InvalidLogin,
        InvalidPassword,
        AlreadyExists
    }
}
