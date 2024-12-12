using Sistema_Ganimedes.Domain.Entities;

namespace Sistema_Ganimedes.Application.Interfaces
{
    public interface IParecerService
    {
        public bool InsertParecer(Parecer parecer);
        public Parecer? GetParecer(int idFormulario, string origem);
        public bool UpdateParecer(Parecer parecer);
    }
}
