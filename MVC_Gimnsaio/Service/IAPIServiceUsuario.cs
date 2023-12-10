using MVC_Gimnsaio.Models;

namespace MVC_Gimnsaio.Service
{
    public interface IAPIServiceUsuario
    {

        Task<List<Usuario>> GetUsuarios();

        Task<bool> ValidarUsuario(Usuario UserToValidate);

        Task<Usuario> CreateUsuario(Usuario newUsuario);

    }
}
