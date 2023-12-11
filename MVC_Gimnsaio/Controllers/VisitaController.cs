using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Gimnsaio.Models;
using MVC_Gimnsaio.Service;

namespace MVC_Gimnsaio.Controllers;

public class VisitaController : Controller
{
    private readonly IAPIServiceVisita _apiService;
    private readonly IAPIServiceMiembro _apiServiceMiembro;

    public VisitaController( IAPIServiceVisita IAPIService, IAPIServiceMiembro IAPIServiceMiembro)
    {

        // Inyecto la dependencia de mi interfaz para poder hacer uso de mis métodos GET, POST, PUT, DELETE
        _apiService = IAPIService;
        _apiServiceMiembro = IAPIServiceMiembro;

    }
  
        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            try 
            { 
                List<Visita> visitas = await _apiService.GetVisitas();

                ViewBag.Miembros =  await _apiServiceMiembro.GetMiembros();

                return View(visitas);
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
        public async Task<IActionResult> Create(Visita visita) //Aquí recibo el objeto de tipo producto
        {

            try
            {

                if (visita != null)
                {

                    // Invoco a la API y le envío el nuevo producto
                    await _apiService.CreateVisita(visita); 
                    // Redirijo a la vista principal
                    return RedirectToAction("Index"); 

                }

            } catch (Exception error)
            {

                return View();

            }

            return RedirectToAction("Index");

        }
        
        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Editar(int idVisita)
        {

            try
            {

                // Invoco a la API y traigo mi producto en base al ID
                Visita visitaEncontrada = await _apiService.GetVisitaByID(idVisita);

                List<Miembro> listaMiembros = await _apiServiceMiembro.GetMiembros();

                if (visitaEncontrada != null)
                {

                    ViewBag.Miembros = new SelectList(listaMiembros, "idMiembro", "NombreCompleto");

                    // Retorno el producto a la vista
                    return View(visitaEncontrada);

                }

            }
            catch (Exception error)
            {

                return RedirectToAction("Index");

            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Editar(Visita newVisita)
        {
            try
            {
                if (newVisita != null)
                {
                    // Envío a la API el nuevo producto y el ID del mismo
                    await _apiService.UpdateVisita(newVisita, newVisita.idVisita);
                    return RedirectToAction("Index");
                }
                // Retorno el producto a la vista
                return RedirectToAction("Index");
            }

            catch (Exception error) 
            {
                return View();
            }
        }
        
        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idVisita)
        { 

            try
            {

                if (idVisita != 0)
                {

                    await _apiService.DeleteVisita(idVisita);
                    return RedirectToAction("Index");

                }

            }
            catch (Exception error)
            {

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> VerDetalleVisita(int idVisita)
        {

            try
            {

                // Invoco a la API y traigo mi producto en base al ID
                Visita visitaEncontrada = await _apiService.GetVisitaByID(idVisita);

                ViewBag.MiembroDeLaVisita = await _apiServiceMiembro.GetMiembroByID(visitaEncontrada.miembroId);

                if (visitaEncontrada != null)
                {

                    // Retorno el producto a la vista
                    return View(visitaEncontrada);

                }
            }
            catch (Exception error)
            {

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");

        }
}