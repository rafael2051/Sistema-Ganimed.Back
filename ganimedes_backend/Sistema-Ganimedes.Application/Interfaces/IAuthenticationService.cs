using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Ganimedes.Application.Interfaces
{
    public interface IAuthenticationService
    {
        public String GenerateJWTToken(String username);
    }
}
