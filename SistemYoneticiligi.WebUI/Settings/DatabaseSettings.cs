namespace SistemYoneticiligi.WebUI.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CustomLogCollectionName {get;set; }
        public string ConnectionString {get;set; }
        public string DatabaseName {get;set; }
    }
}