using Sistema_Ganimedes.Application.Interfaces;
using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Infrastructure.Repository;

namespace Sistema_Ganimedes.Application.Services
{
    public class ParecerService : IParecerService
    {

        private readonly IParecerRepository _parecerRepository;

        public ParecerService(IParecerRepository parecerRepository)
        {
            _parecerRepository = parecerRepository;
        }

        public bool InsertParecer(Parecer parecer)
        {
            var rowsAffected = _parecerRepository.InsertParecer(parecer);
            return rowsAffected > 0;
        }

        public Parecer? GetParecer(int idFormulario, string origem)
        {
            return _parecerRepository.GetParecer(idFormulario, origem);
        }

        public bool UpdateParecer(Parecer parecer)
        {
            var rowsAffected = _parecerRepository.UpdateParecer(parecer);
            return rowsAffected > 0;
        }
    }
}
