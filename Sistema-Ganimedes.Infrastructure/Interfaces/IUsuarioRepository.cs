using Sistema_Ganimedes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Ganimedes.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? GetUsuario(string nUsp);
    }
}
