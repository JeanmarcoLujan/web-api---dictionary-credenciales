namespace WebAPIArchivosConfguracion.Entities
{
    public class ClienteConfiguracion
    {
        public string ClientId { get; set; }
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public SL SL { get; set; }

    }

    public class SL
    {
        public string Direccion { get; set; }
        public string Valor { get; set; }
    }
}
