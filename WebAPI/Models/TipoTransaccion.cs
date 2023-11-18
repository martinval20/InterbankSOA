using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class TipoTransaccion
    {
        public TipoTransaccion()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int Id { get; set; }
        public string? NombreTipoTransaccion { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
