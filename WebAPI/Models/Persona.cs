using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string? Correo { get; set; }
        public string? Celular { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
