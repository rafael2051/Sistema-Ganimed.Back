using Sistema_Ganimedes.Domain.Enums;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class Usuario
    {
        public string nusp { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string link_lattes { get; set; }
        public string dt_atualizacao_lattes { get; set; }
        public TipoUsuario tipo_usuario { get; set; }
    }
}