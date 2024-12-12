using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Ganimedes.Application.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<bool> ValidarToken(string token, string nUsp);
    }
}
