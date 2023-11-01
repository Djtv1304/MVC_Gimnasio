using MVC_Gimnsaio.Models;

namespace MVC_Gimnsaio.Service;

public interface IAPIServicePago
{
    public Task<Pago> CreatePago(Pago newPago);
    public Task<string> DeletePago(int idPago);
    public Task<List<Pago>> GetPagos();
    public Task<List<Pago>> GetPagosPorMiembro(int idMiembro);
    public Task<Pago> GetPagoByID(int idPago);
    public Task<Pago> UpdatePago(Pago newPago, int idPago);
}