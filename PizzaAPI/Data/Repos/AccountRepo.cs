using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;
using PizzaAPI.Data.Interfaces;

namespace PizzaAPI.Data.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private readonly PizzaContext _context;
        public AccountRepo(PizzaContext context)
        {
            _context = context;
        }

        public async Task<AccountEntity> Register(AccountEntity accountEntity)
        {
            var existingUser = await _context.Accounts
                .FirstOrDefaultAsync(u => u.Username == accountEntity.Username || u.Email == accountEntity.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var newUser = new AccountEntity
            {
                Username = accountEntity.Username,
                Email = accountEntity.Email,
                Password = accountEntity.Password,
                Phone = accountEntity.Phone
            };

            await _context.Accounts.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<AccountEntity> Login(LoginDTO loginDTO)
        {
            // 1) only filter on username
            var user = await _context.Accounts
                .SingleOrDefaultAsync(u => u.Username == loginDTO.Username);

            if (user == null)
                throw new Exception("Username does not exist");

            bool passwordMatches = BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password);
            if (!passwordMatches)
                throw new Exception("Invalid password");

            return user;
        }

        public async Task Update(AccountEntity accountEntity)
        {
            var user = await _context.Accounts
                .SingleOrDefaultAsync(u => u.AccountID == accountEntity.AccountID);

            if (user == null)
                throw new Exception("User does not exist " + accountEntity.AccountID);

            user.Username = accountEntity.Username;
            user.Email = accountEntity.Email;
            user.Password = accountEntity.Password;
            user.Phone = accountEntity.Phone;
            _context.Accounts.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
