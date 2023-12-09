namespace WebAPI.Transfers
{
    public class CuentumDt2
    {
        public int Id { get; set; }
        public int? IdPersona { get; set; }
        public int? IdTipoCuenta { get; set; }
        public string? NumeroCuenta { get; set; }
        public decimal? Saldo { get; set; }
        public string Clave { get; set; } = null!;
    }
}
