using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Ruc { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Direccion { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
