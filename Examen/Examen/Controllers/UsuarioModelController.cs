using Examen.Context;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("Usuarios")]
    [ApiController]
    public class UsuarioModelController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (BancoContext context = new BancoContext())
            {
                var aux = context.Usuario;
                foreach(var item in aux)
                {
                    usuarios.Add(new Usuario
                    {
                        NombreUsuario = item.NombreUsuario,
                        Nombre = item.Nombre,
                        Contrasena = item.Contrasena,
                        Cuentas = item.Cuentas,
                        Tarjetas = item.Tarjetas
                    });
                }
            }
            return new JsonResult(usuarios);
        }
    }
}
