using Examen.Context;
using Examen.DTO;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("DTOUsuarios")]
    [ApiController]
    public class DTOUsuarioController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUsuarios()
        {
            List<DTO_Usuario> usuarios = new List<DTO_Usuario>();

            using(BancoContext context = new BancoContext())
            {
                var aux = context.Usuario;
                foreach (var item in aux)
                {
                    usuarios.Add(new DTO_Usuario
                    {
                        Nombre = item.Nombre,
                        NombreUsuario = item.NombreUsuario
                    });
                }
            }
            return new JsonResult(usuarios);
        }
        [HttpPost]
        public bool LoginMethod([FromBody] string user, string contra)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Usuario.SingleOrDefault(u=>u.NombreUsuario == user && u.Contrasena == contra);
                if(existe != null)
                {
                    comprobacion = true;
                }
                return comprobacion;
            }
        }
    }
}
