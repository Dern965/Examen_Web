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
                        Nombre = item.Nombre
                    });
                }
            }
            return new JsonResult(usuarios);
        }
    }
}
