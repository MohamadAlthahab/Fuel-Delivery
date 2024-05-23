using Fuel_Delivery.Model;

namespace Fuel_Delivery.Services
{
    public interface IAuthManger
    {
        Task<bool> ValidateUser(LoginUserDTO loginUserDTO);
        Task<string> CreateToken();
    }
}
