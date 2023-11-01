using MVC_Gimnsaio.Models;

namespace MVC_Gimnsaio.Service;

public interface IAPIServiceVisita
{ 
    Task<Visita> CreateVisita(Visita newVisita);
    Task<string> DeleteVisita(int idVisita);
    Task<List<Visita>> GetVisitas();
    Task<List<Visita>> GetVisitasPorMiembro(int idMiembro);
    Task<Visita> GetVisitaByID(int idVisita);
    Task<Visita> UpdateVisita(Visita newVisita, int idVisita);
}