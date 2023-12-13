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

        // GET: UsuariosController
        public IActionResult SignOutSession()
        {

            HttpContext.Session.Clear();

            return RedirectToAction("SignIn"); ;

        }

        [HttpPost]
        public async Task<IActionResult> SignIn(Usuario UserToLogin)
        {
            try
            {
                UserToLogin.isAuthenticated = await _apiServiceUsuario.ValidarUsuario(UserToLogin);

                if (UserToLogin.isAuthenticated)
                {
                    // Guardar información del usuario en la sesión
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(UserToLogin));

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
        public IActionResult GetUser()
        {

            // Recuperar el objeto Usuario de la sesión
            var userJson = HttpContext.Session.GetString("User");

            if (userJson != null)
            {

                // Deserializar el objeto Usuario
                Usuario SessionUser = JsonConvert.DeserializeObject<Usuario>(userJson);

                // Devolver el objeto Usuario completo en formato JSON
                return Json(SessionUser);

            }

            // Aquí manejas el caso en que no hay un usuario en la sesión
            // Creas un nuevo objeto Usuario con atributos vacíos y isAuthenticated en false
            Usuario EmptyUser = new Usuario
            {

                idUsuario = 0,
                username = string.Empty,
                password = string.Empty,
                isAuthenticated = false

            };

            return Json(EmptyUser);

        }



    }
}
