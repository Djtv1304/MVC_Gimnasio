using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Gimnsaio.Models;
using MVC_Gimnsaio.Service;

namespace MVC_Gimnsaio.Controllers;

public class MiembroController : Controller
{
    private readonly IAPIServiceMiembro _apiService;
    private readonly IAPIServiceMembresia _apiServiceMembresia;
    private readonly IAPIServicePago _apiServicePago;
    private readonly IAPIServiceVisita _apiServiceVisita;

    public MiembroController( IAPIServiceMiembro IAPIService, IAPIServiceMembresia APIServiceMembresia, IAPIServicePago APIServicePago, IAPIServiceVisita APIServiceVisita)
    {
        // Inyecto la dependencia de mi interfaz para poder hacer uso de mis métodos GET, POST, PUT, DELETE
        _apiService = IAPIService;
        _apiServiceMembresia = APIServiceMembresia;
        _apiServicePago = APIServicePago;
        _apiServiceVisita = APIServiceVisita;
    }
    
    
    // // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            try 
            {
                List<Miembro> miembros = await _apiService.GetMiembros();
                return View(miembros);
            }
            catch (Exception error)
            {
                return View();
            }
        }
        

        // GET: Miembro/Controller/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Etiqueta propia de ASP .NET
        public async Task<IActionResult> Create(Miembro miembro) //Aquí recibo el objeto de tipo miembro
        {

            try
            {

                if (miembro != null)
                {

                    // Invoco a la API y le envío el nuevo producto
                    await _apiService.CreateMiembro(miembro); 
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
        public async Task<IActionResult> Editar(int idMiembro)
        {

            try
            {

                // Invoco a la API y traigo mi producto en base al ID
                Miembro miembroEncontrado = await _apiService.GetMiembroByID(idMiembro);

                List<Membresia> membresias = await _apiServiceMembresia.GetMembresia();

                if (miembroEncontrado != null)
                {

                    // Pásala a la vista
                    ViewBag.Membresia = new SelectList(membresias, "idMembresia", "nombreMembresia");

                    // Retorno el producto a la vista
                    return View(miembroEncontrado);

                }
            }
            catch (Exception error)
            {

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Editar(Miembro nuevoMiembro)
        {

            try
            {

                if (nuevoMiembro != null)
                {

                    // Envío a la API el nuevo producto y el ID del mismo
                    await _apiService.UpdateMiembro(nuevoMiembro, nuevoMiembro.idMiembro);
                    return RedirectToAction("Index");

                }

                // Retorno el miembro a la vista
                return View(nuevoMiembro);

            }
            catch (Exception error) 
            {

                return View();

            }

        }


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idMiembro)
        {

            try
            {

                if (idMiembro != 0)
                {

                    await _apiService.DeleteMiembro(idMiembro);
                    return RedirectToAction("Index");

                }

            }
            catch (Exception error)
            {

                return RedirectToAction();

            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> VerDetalleMiembro(int idMiembro)
        {

            try
            {

                // Invoco a la API y traigo mi producto en base al ID
                Miembro miembroEncontrado = await _apiService.GetMiembroByID(idMiembro);

                if (miembroEncontrado != null)
                {

                    // Retorno el producto a la vista
                    return View(miembroEncontrado);

                }

            }
            catch (Exception error)
            {

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");

        }
        
        public async Task<IActionResult> AdministrarMembresia(int idMiembro)
        {

            try
            {

                // Invoco a la API y traigo mi producto en base al ID
                Miembro miembroEncontrado = await _apiService.GetMiembroByID(idMiembro);

                Membresia membresiaEncontrada = await _apiServiceMembresia.GetMembresiaByID(miembroEncontrado.idMembresia);

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

        public async Task<IActionResult> VerPagosPorMiembro(int idMiembro)
        {

            try
            {

                Miembro miembroEncontrado = await _apiService.GetMiembroByID(idMiembro);

                List<Pago> pagos = await _apiServicePago.GetPagosPorMiembro(miembroEncontrado.idMiembro);

                if (pagos.Count > 0)
                {

                    // Obtén el miembro
                    Miembro miembro = await _apiService.GetMiembroByID(idMiembro);

                    // Pásalo a la vista
                    ViewBag.Miembro = miembro;

                    // Retorno el producto a la vista
                    return View(pagos);

                }
            }
            catch (Exception error)
            {

                return RedirectToAction("Index");

            }

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

        public async Task<IActionResult> VisitasMiembro(int idMiembro)
        {

            try
            {

                List<Visita> visitasPorMiembro = await _apiServiceVisita.GetVisitasPorMiembro(idMiembro);

                if (visitasPorMiembro != null)
                {

                    // Obtén el miembro
                    Miembro miembro = await _apiService.GetMiembroByID(idMiembro);

                    // Pásalo a la vista
                    ViewBag.Miembro = miembro;

                    // Retorno el producto a la vista
                    return View(visitasPorMiembro);

                }
            }
            catch (Exception error)
            {

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }
}