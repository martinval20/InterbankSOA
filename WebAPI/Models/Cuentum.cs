using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int Id { get; set; }
        public int? IdPersona { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoCuenta { get; set; }
        public string? NumeroCuenta { get; set; }
        public decimal? Saldo { get; set; }
        public string Clave { get; set; } = null!;

        public virtual Empresa? IdEmpresaNavigation { get; set; }
        public virtual Persona? IdPersonaNavigation { get; set; }
        public virtual TipoCuentum? IdTipoCuentaNavigation { get; set; }
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
