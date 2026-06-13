using CryptoAPI.Data;
using CryptoAPI.DTOs;
using CryptoAPI.Models;
using CryptoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CriptoYaService _criptoYaService;

        public MovimientosController(AppDbContext context, CriptoYaService criptoYaService)
        {
            _context = context;
            _criptoYaService = criptoYaService;
        }

        [HttpGet]
        public IActionResult ObtenerMovimientos()
        {
            var movimientos = _context.Movimientos
                .OrderByDescending(m => m.FechaHora)
                .ToList();

            return Ok(movimientos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearMovimiento(MovimientoDTO movimientoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var precio = await _criptoYaService.ObtenerPrecioAsync(
                movimientoDTO.Criptomoneda,
                movimientoDTO.TipoMovimiento);

            var movimiento = new Movimiento
            {
                Criptomoneda = movimientoDTO.Criptomoneda,
                Cantidad = movimientoDTO.Cantidad,
                TipoMovimiento = movimientoDTO.TipoMovimiento,
                FechaHora = movimientoDTO.FechaHora,
                Monto = movimientoDTO.Cantidad * precio
            };

            _context.Movimientos.Add(movimiento);
            _context.SaveChanges();

            return Ok(movimiento);
        }
    }
}