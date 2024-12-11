using Sistema_Ganimedes.Domain.Entities;
using System.Net;

namespace Sistema_Ganimedes.Application.Interfaces
{
    public interface ILoginService
    {
        public Task<LoginResponse> ValidarLogin(String email, String senha);
    }
}
