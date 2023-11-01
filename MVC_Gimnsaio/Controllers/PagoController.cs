using Microsoft.AspNetCore.Mvc;
using MVC_Gimnsaio.Models;
using MVC_Gimnsaio.Service;

namespace MVC_Gimnsaio.Controllers;

public class PagoController : Controller
{
    private readonly IAPIServicePago _apiService;

    public PagoController( IAPIServicePago IAPIService)
    {
        // Inyecto la dependencia de mi interfaz para poder hacer uso de mis métodos GET, POST, PUT, DELETE
        _apiService = IAPIService;

    }
    // GET
    
    // // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            try 
            {
                List<Pago> pagos = await _apiService.GetPagos();
                return View(pagos);
            }
            catch (Exception error)
            {
                return View();
            }
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Etiqueta propia de ASP .NET
        public async Task<IActionResult> Create(Pago pago) //Aquí recibo el objeto de tipo producto
        {
            try
            {
                if (pago != null)
                {
                    // Invoco a la API y le envío el nuevo producto
                    await _apiService.CreatePago(pago); 
                    // Redirijo a la vista principal
                    return RedirectToAction("Index"); 
                }
            } catch (Exception error)
            {
                return View();
            }
            return View();
        }
        
        // GET: ProductoController/Edit/5
        
    
        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idPago)
        {
            try
            {
                if (idPago != 0)
                {
                    await _apiService.DeletePago(idPago);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> ReversarTransacción(int idPago)
        {
            return RedirectToAction("Index");
        }
}