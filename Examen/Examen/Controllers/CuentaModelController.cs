using Examen.Context;
using Examen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    [Route("ModelCuentas")]
    [ApiController]
    public class CuentaModelController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCuentas()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            using (BancoContext context = new BancoContext())
            {
                var aux = context.Cuenta;
                foreach(var item in aux)
                {
                    cuentas.Add(new Cuenta
                    {
                        Num_Cuenta = item.Num_Cuenta,
                        Saldo = item.Saldo,
                        Movimientos = item.Movimientos,
                        Tipo_cuenta = item.Tipo_cuenta,
                        Titular = item.Titular
                    });
                }
            }
            return new JsonResult(cuentas);
        }
        [HttpPost]
        public JsonResult PostCuenta([FromBody] Cuenta account)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                context.Cuenta.Add(account);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateCuenta([FromBody] Cuenta account)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Cuenta.SingleOrDefault(c => c.Num_Cuenta == account.Num_Cuenta);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Cuenta.Attach(account);
                    context.Entry(account).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteAccount([FromBody] Cuenta account)
        {
            bool comprobacion = false;
            using (BancoContext context = new BancoContext())
            {
                var existe = context.Cuenta.SingleOrDefault(c => c.Num_Cuenta == account.Num_Cuenta);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Cuenta.Attach(account);
                    context.Entry(account).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
