using Examen.Context;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    [Route("ModelTarjetas")]
    [ApiController]
    public class TarjetaModelController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetTrajetas()
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            using (BancoContext context = new BancoContext())
            {
                var aux = context.Tarjeta;
                foreach(var item in aux)
                {
                    tarjetas.Add(new Tarjeta
                    {
                        Num_Tarjeta = item.Num_Tarjeta,
                        Titular = item.Titular,
                        Saldo = item.Saldo,
                        CVV = item.CVV,
                        Fecha_vencimiento = item.Fecha_vencimiento
                    });
                }
            }
            return new JsonResult(tarjetas);
        }
        [HttpPost]
        public JsonResult PostTarjeta([FromBody] Tarjeta card)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                context.Tarjeta.Add(card);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateTarjeta([FromBody] Tarjeta card)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Tarjeta.SingleOrDefault(t => t.Num_Tarjeta == card.Num_Tarjeta);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Tarjeta.Attach(card);
                    context.Entry(card).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteCard([FromBody] Tarjeta card)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Tarjeta.SingleOrDefault(t => t.Num_Tarjeta == card.Num_Tarjeta);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Tarjeta.Attach(card);
                    context.Entry(card).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
