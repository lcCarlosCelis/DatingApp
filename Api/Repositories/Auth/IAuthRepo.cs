using Api.DTOs.Auth;

namespace Api.Repositories.Auth
{
    public interface IAuthRepo
    {
        bool register(Register register);
        Token login(Login login);
    }
}