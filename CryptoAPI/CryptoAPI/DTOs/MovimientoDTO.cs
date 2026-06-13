using System.ComponentModel.DataAnnotations;

namespace CryptoAPI.DTOs
{
    public class MovimientoDTO
    {
        [Required(ErrorMessage = "La criptomoneda es obligatoria")]
        public string Criptomoneda { get; set; } = string.Empty;

        [Range(0.00000001, double.MaxValue,
            ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "Debe indicar si es compra o venta")]
        public string TipoMovimiento { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime FechaHora { get; set; }
    }
}