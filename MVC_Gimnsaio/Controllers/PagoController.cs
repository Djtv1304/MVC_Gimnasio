using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Gimnsaio.Models;
using MVC_Gimnsaio.Service;

namespace MVC_Gimnsaio.Controllers;

public class PagoController : Controller
{
    private readonly IAPIServicePago _apiService;
    private readonly IAPIServiceMiembro _apiServiceMiembro;

    public PagoController( IAPIServicePago IAPIService, IAPIServiceMiembro IAPIServiceMiembro)
    {

        // Inyecto la dependencia de mi interfaz para poder hacer uso de mis métodos GET, POST, PUT, DELETE
        _apiService = IAPIService;
        _apiServiceMiembro = IAPIServiceMiembro;

    }

    // GET
    
    // // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            try 
            {

                List<Pago> pagos = await _apiService.GetPagos();

                ViewBag.Miembros =  await _apiServiceMiembro.GetMiembros();

                return View(pagos);
            }
            catch (Exception error)
            {
                return View();
            }
        }

        // GET: ProductoController/Create
        public async Task<IActionResult> Create()
        {

            List<Miembro> listaMiembros =  await _apiServiceMiembro.GetMiembros();

            ViewBag.Miembros = new SelectList(listaMiembros, "idMiembro", "NombreCompleto");

            return View();

        }

        [HttpPost] // Etiqueta propia de ASP .NET
        public async Task<IActionResult> Create(Pago pago) //Aquí recibo el objeto de tipo producto
        {
            try
            {

                Miembro miembroDelPago = await _apiService.GetMiembroByID(pago.miembroId);

                if (pago != null || miembroDelPago != null)
                {

                    pago.fechaPago = DateTime.Now;
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
        public async Task<IActionResult> VerDetallePago(int idPago)
        {
            try
            {
                // Invoco a la API y traigo mi producto en base al ID
                Pago pagoEncontrado = await _apiService.GetPagoByID(idPago);

                ViewBag.MiembroDelPago = await _apiServiceMiembro.GetMiembroByID(pagoEncontrado.miembroId);

                if (pagoEncontrado != null)
                {
                    // Retorno el producto a la vista
                    return View(pagoEncontrado);
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

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