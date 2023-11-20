using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Lugare
    {
        public int Id { get; set; }
        public string Distrito { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string TipoA { get; set; } = null!;
    }
}
