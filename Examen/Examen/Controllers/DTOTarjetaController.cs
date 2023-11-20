using Examen.Context;
using Examen.DTO;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("DTOTarjetas")]
    [ApiController]
    public class DTOTarjetaController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetTarjetas()
        {
            List<DTO_Tarjeta> tarjetas = new List<DTO_Tarjeta>();

            using(BancoContext context = new BancoContext())
            {
                var aux = context.Tarjeta;
                foreach (var item in aux)
                {
                    tarjetas.Add(new DTO_Tarjeta
                    {
                        Saldo = item.Saldo,
                        Titular = item.Titular
                    });
                }
            }
            return new JsonResult(tarjetas);
        }
    }
}
