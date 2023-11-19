using Examen.Context;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    [Route("ModelUsuarios")]
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
        [HttpPost]
        public JsonResult PostUsuario([FromBody] Usuario user)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                context.Usuario.Add(user);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateUsuario([FromBody] Usuario user)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Usuario.SingleOrDefault(u => u.NombreUsuario == user.NombreUsuario);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Usuario.Attach(user);
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteUser([FromBody] Usuario user)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Usuario.SingleOrDefault(u => u.NombreUsuario == user.NombreUsuario);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Usuario.Attach(user);
                    context.Entry(user).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
