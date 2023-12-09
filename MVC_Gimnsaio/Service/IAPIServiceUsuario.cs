using MVC_Gimnsaio.Models;

namespace MVC_Gimnsaio.Service
{
    public interface IAPIServiceUsuario
    {

        Task<Usuario> GetUsuario(Usuario usuario);

        Task<Usuario> CreateUsuario(Usuario newUsuario);

    }
}
