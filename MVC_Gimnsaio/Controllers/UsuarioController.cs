using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Gimnsaio.Models;
using MVC_Gimnsaio.Service;
using Newtonsoft.Json;

namespace MVC_Gimnsaio.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IAPIServiceUsuario _apiServiceUsuario;

        public UsuarioController(IAPIServiceUsuario apiServiceUsuario)
        {

            _apiServiceUsuario = apiServiceUsuario;

        }

        // GET: UsuariosController
        public IActionResult Index()
        {

            return RedirectToAction("SignIn");

        }

        // GET: UsuariosController
        public IActionResult SignIn()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SignIn(Usuario UserToLogin)
        {
            try
            {
                bool isAuthenticated = await _apiServiceUsuario.ValidarUsuario(UserToLogin);

                if (isAuthenticated)
                {
                    // Guardar información del usuario en la sesión
                    HttpContext.Session.SetString("Username", UserToLogin.username);

                    // Redirigir a la página de inicio
                    return RedirectToAction("Index", "Home");
                }

                // Aquí asignamos el mensaje de error
                ViewBag.ErrorMessage = "Usuario o contraseña incorrectos.";

                return View();
            }
            catch
            {
                // Aquí también podrías asignar un mensaje de error si lo deseas
                ViewBag.ErrorMessage = "Ocurrió un error al intentar iniciar sesión.";
                return View();
            }
        }



        // GET: UsuariosController/Create
        public IActionResult SignUp()
        {

            return View();

        }

        // POST: UsuariosController/Create
        [HttpPost]
        public async Task<IActionResult> SignUp(Usuario NewUser)
        {

            try
            {

                Usuario NewUserConfirmation = await _apiServiceUsuario.CreateUsuario(NewUser);

                if(NewUserConfirmation == null)
                {

                    return View();

                }

                return RedirectToAction("SignIn");
            }

            catch
            {

                return View();

            }

        }

        [HttpGet]
        public IActionResult GetUsername()
        {
            // Recuperar el nombre de usuario de la sesión
            var username = HttpContext.Session.GetString("Username");

            // Devolver el nombre de usuario en formato JSON
            return Json(new { username });
        }

    }
}
