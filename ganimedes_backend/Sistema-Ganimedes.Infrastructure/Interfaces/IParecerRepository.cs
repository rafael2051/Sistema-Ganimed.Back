using Sistema_Ganimedes.Domain.Entities;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public interface IParecerRepository
    {
        public int InsertParecer(Parecer parecer);
        public Parecer? GetParecer(int idFormulario, string origem);
        public int UpdateParecer(Parecer parecer);
    }
}
