using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoAPI.Models
{
    public class Movimiento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La criptomoneda es obligatoria")]
        public string Criptomoneda { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,8)")]
        [Range(0.00000001, double.MaxValue,
            ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Debe indicar si es compra o venta")]
        public string TipoMovimiento { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime FechaHora { get; set; }
    }
}