using Examen.Context;
using Examen.DTO;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("DTOMovimientos")]
    [ApiController]
    public class DTOMovimientoController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetMovimientos()
        {
            List<DTO_Movimiento> movimientos = new List<DTO_Movimiento>();

            using(BancoContext context = new BancoContext())
            {
                var aux = context.Movimiento;
                foreach (var item in aux)
                {
                    movimientos.Add(new DTO_Movimiento
                    {
                        Num_Movimiento = item.Num_Movimiento,
                        Tipo_Movimiento = item.Tipo_Movimiento,
                        Fecha = item.Fecha,
                        Hora = item.Hora,
                        Usuario1 = item.Usuario1,
                        Usuario2 = item.Usuario2
                    });
                }
            }
            return new JsonResult(movimientos);
        }
    }
}
