using PizzaAPI.Core.Interfaces;
using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;
using PizzaAPI.Data.Interfaces;
using PizzaAPI.Data.Repos;
using PizzaAPI.Middleware;

namespace PizzaAPI.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly JwtExtension _jwtExtension;
        public AccountService(IAccountRepo accountRepo, JwtExtension jwtExtension)
        {
            _accountRepo = accountRepo;
            _jwtExtension = jwtExtension;
        }

        public async Task<string> Register(AccountEntity accountEntity)
        {
            string hashedPassword = CreatePassword(accountEntity.Password);
            accountEntity.Password = hashedPassword;
            AccountEntity userCreds = await _accountRepo.Register(accountEntity);

            string token = _jwtExtension.CreateJwtToken(userCreds);
            return token;
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            AccountEntity userCreds = await _accountRepo.Login(loginDTO);

            string token = _jwtExtension.CreateJwtToken(userCreds);
            return token;
        }

        public async Task Update(AccountEntity accountEntity)
        {
            string hashedPassword = CreatePassword(accountEntity.Password);
            accountEntity.Password = hashedPassword;
            await _accountRepo.Update(accountEntity);
        }

        public string CreatePassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }
    }
}
