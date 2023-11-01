using MVC_Gimnsaio.Models;

namespace MVC_Gimnsaio.Service;

public interface IAPIServiceMiembro
{
    Task<Miembro> CreateMiembro(Miembro newMiembro);
    Task<string> DeleteMiembro(int idMiembro);
    Task<List<Miembro>> GetMiembros();
    Task<Miembro> GetMiembroByID(int idMiembro);
    Task<Miembro> UpdateMiembro(Miembro newMiembro, int idMiembro);
}