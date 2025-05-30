using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;

namespace PizzaAPI.Core.Interfaces
{
    public interface IAccountService
    {
        Task<string> Register(AccountEntity accountEntity);
        Task<string> Login(LoginDTO loginDTO);
        Task Update(AccountEntity accountEntity);
    }
}
