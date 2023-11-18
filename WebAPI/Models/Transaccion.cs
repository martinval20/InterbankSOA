using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Transaccion
    {
        public int Id { get; set; }
        public int? IdTipoTransaccion { get; set; }
        public int? IdCuenta { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdOrigen { get; set; }

        public virtual Cuentum? IdCuentaNavigation { get; set; }
        public virtual TipoTransaccion? IdTipoTransaccionNavigation { get; set; }
    }
}
