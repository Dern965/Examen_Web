using Examen.Context;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    [Route("ModelMovimientos")]
    [ApiController]
    public class MovimientoModelController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetMovimientos()
        {
            List<Movimiento> movimientos = new List<Movimiento>();
            using (BancoContext context = new BancoContext())
            {
                var aux = context.Movimiento;
                foreach(var item in aux)
                {
                    movimientos.Add(new Movimiento
                    {
                        Num_Movimiento = item.Num_Movimiento,
                        Num_Tarjeta = item.Num_Tarjeta,
                        Num_Cuenta = item.Num_Cuenta,
                        Num_Tarjeta2 = item.Num_Tarjeta2,
                        Num_Cuenta2 = item.Num_Cuenta2,
                        Usuario1 = item.Usuario1,
                        Usuario2 = item.Usuario2,
                        Cantidad = item.Cantidad,
                        Fecha = item.Fecha,
                        Hora = item.Hora,
                        Descripcion = item.Descripcion,
                        Tipo_Movimiento = item.Tipo_Movimiento
                    });
                }
            }
            return new JsonResult(movimientos);
        }
        [HttpPost]
        public JsonResult PostMovimiento([FromBody] Movimiento mov)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                context.Movimiento.Add(mov);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateMovimiento([FromBody] Movimiento mov)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Movimiento.SingleOrDefault(m => m.Num_Movimiento == mov.Num_Movimiento);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Movimiento.Attach(mov);
                    context.Entry(mov).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteMovement([FromBody] Movimiento mov)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Movimiento.SingleOrDefault(m => m.Num_Movimiento == mov.Num_Movimiento);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Movimiento.Attach(mov);
                    context.Entry(mov).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
