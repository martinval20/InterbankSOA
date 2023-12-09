namespace WebAPI.Transfers
{
    public class PersonaDt1
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string? Correo { get; set; }
        public string? Celular { get; set; }
    }
}
