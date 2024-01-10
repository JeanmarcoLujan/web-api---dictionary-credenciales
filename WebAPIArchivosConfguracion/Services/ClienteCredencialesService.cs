using Microsoft.Extensions.Options;
using WebAPIArchivosConfguracion.Entities;

namespace WebAPIArchivosConfguracion.Services
{
    public class ClienteCredencialesService
    {
        private readonly Dictionary<string, ClienteConfiguracion> _clientesConfig;

        public ClienteCredencialesService(IConfiguration config)
        {
            _clientesConfig = config.GetSection("Clientes")
            .Get<Dictionary<string, ClienteConfiguracion>>();
        }

        public ClienteConfiguracion ObtenerCredenciales(string clientId)
        {
            if (_clientesConfig.TryGetValue(clientId, out var configuracion))
            {
                return configuracion;
            }

            // Manejo de error si el cliente no se encuentra
            throw new InvalidOperationException($"Cliente '{clientId}' no encontrado.");
        }
    }
}
