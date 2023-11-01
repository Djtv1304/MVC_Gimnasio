using Microsoft.AspNetCore.Mvc;
using MVC_Gimnsaio.Models;
using MVC_Gimnsaio.Service;

namespace MVC_Gimnsaio.Controllers;

public class MembresíaController : Controller
{
    private readonly IAPIServiceMembresia _apiService;

    public MembresíaController( IAPIServiceMembresia IAPIService)
    {
        // Inyecto la dependencia de mi interfaz para poder hacer uso de mis métodos GET, POST, PUT, DELETE
        _apiService = IAPIService;
    }
    
    // // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            try 
            {
                List<Membresia> membresias = await _apiService.GetMembresia();
                return View(membresias);
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
        public async Task<IActionResult> Create(Membresia membresia) //Aquí recibo el objeto de tipo producto
        {
            try
            {
                if (membresia != null)
                {
                    // Invoco a la API y le envío el nuevo producto
                    await _apiService.CreateMembresia(membresia); 
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
        
        public async Task<IActionResult> Edit(int idMembresia)
        {
            try
            {
                // Invoco a la API y traigo mi producto en base al ID
                Membresia membresiaEncontrada = await _apiService.GetMembresiaByID(idMembresia);
                if (membresiaEncontrada != null)
                {
                    // Retorno el producto a la vista
                    return View(membresiaEncontrada);
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Membresia newMembresia)
        {
            try
            {
                if (newMembresia != null)
                {
                    // Envío a la API el nuevo producto y el ID del mismo
                    await _apiService.UpdateMembresia(newMembresia, newMembresia.idMembresia);

                    return RedirectToAction("Index");
                }
                // Retorno el producto a la vista
                return RedirectToAction("Index");
            }
            catch (Exception error) 
            {
                return RedirectToAction("Index");
            }
        }
        
        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idMembresia)
        {
            try
            {
                if (idMembresia != 0)
                {
                    await _apiService.DeleteMembresia(idMembresia);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception error)
            {
                return RedirectToAction();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> VerDetalleMembresia(int idMembresia)
        {
            try
            {
                // Invoco a la API y traigo mi producto en base al ID
                Membresia membresiaEncontrada = await _apiService.GetMembresiaByID(idMembresia);

                if (membresiaEncontrada != null)
                {
                    // Retorno el producto a la vista
                    return View(membresiaEncontrada);
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AdministrarMembresía(int IdMembresía)
        //
        {
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Renovar(int idMembresia)
        {
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Cancelar(int idMembresia)
        {
            return RedirectToAction("Index");
        }
}