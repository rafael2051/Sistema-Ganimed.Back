using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.Application.Services
{
    public interface IFormularioService
    {
        public bool ValidaNUsp(string nUsp);

        public Formulario? GetFormulario(string nUsp);

    }
}
