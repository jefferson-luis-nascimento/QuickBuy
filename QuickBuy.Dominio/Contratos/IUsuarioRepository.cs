using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Dominio.Contratos
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Obter(string email, string senha);
        Usuario Obter(string email);
    }
}
