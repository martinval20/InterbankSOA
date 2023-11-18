using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class TipoCuentum
    {
        public TipoCuentum()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int Id { get; set; }
        public string NombreTipoCuenta { get; set; } = null!;

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
