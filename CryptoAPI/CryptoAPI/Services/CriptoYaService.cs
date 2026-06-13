using System.Text.Json;

namespace CryptoAPI.Services
{
    public class CriptoYaService
    {
        private readonly HttpClient _httpClient;

        public CriptoYaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> ObtenerPrecioAsync(string criptomoneda, string tipoMovimiento)
        {
            string codigo = ObtenerCodigoCripto(criptomoneda);

            string url = $"https://criptoya.com/api/satoshitango/{codigo}/ars";

            var respuesta = await _httpClient.GetStringAsync(url);

            var datos = JsonSerializer.Deserialize<JsonElement>(respuesta);

            if (tipoMovimiento.ToLower() == "compra")
            {
                return datos.GetProperty("ask").GetDecimal();
            }

            return datos.GetProperty("bid").GetDecimal();
        }

        private string ObtenerCodigoCripto(string criptomoneda)
        {
            switch (criptomoneda.ToLower())
            {
                case "bitcoin":
                    return "btc";

                case "ethereum":
                    return "eth";

                case "usdc":
                    return "usdc";

                default:
                    return criptomoneda.ToLower();
            }
        }
    }
}
