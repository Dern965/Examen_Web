using Examen.Context;
using Examen.DTO;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("DTOCuentas")]
    [ApiController]
    public class DTOCuentaController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCuentas()
        {
            List<DTO_Cuenta> cuentas = new List<DTO_Cuenta>();

            using(BancoContext context = new BancoContext())
            {
                var aux = context.Cuenta;
                foreach (var item in aux)
                {
                    cuentas.Add(new DTO_Cuenta
                    {
                        Saldo = item.Saldo,
                        Tipo_cuenta = item.Tipo_cuenta,
                        Titular = item.Titular
                    });
                }
            }
            return new JsonResult(cuentas);
        }
    }
}
