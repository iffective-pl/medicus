namespace MedicusApp.Config
{
    public class KeycloakConfiguration
    {
        public string Audience { get; set; }
        public string Authority { get; set; }
        public string MetadataAddress { get; set; }
        public bool RequireHttpsMetadata { get; set; }
    }
}
