using MVC_Gimnsaio.Models;

namespace MVC_Gimnsaio.Service;

public interface IAPIServiceMembresia
{
    public Task<List<Membresia>> GetMembresia();
    public Task<Membresia> CreateMembresia(Membresia newMembresia);
    public Task<Membresia> GetMembresiaByID(int idMembresia);
    public Task<Membresia> UpdateMembresia(Membresia newMembresia, int idMembresia);
    public Task<string> DeleteMembresia(int idMembresia);
    public Task<List<Miembro>> GetMiembrosDeUnaMembresia(int idMembresia);
    public Task<string> RenovarMembresia(int idMiembro);
    public Task<string> CancelarMembresia(int idMiembro);
}