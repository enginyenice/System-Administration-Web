using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using SistemYoneticiligi.WebUI.Entities;
using SistemYoneticiligi.WebUI.Settings;

namespace SistemYoneticiligi.WebUI.Operations.CustomLogOperations.Commands.CreateCustomLog
{

    public class CreateCustomLogCommand
    {
        public CreateCustomLogModel Model { get; set; }
        private readonly IMongoCollection<CustomLog> _customLogCollection;


        public CreateCustomLogCommand(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _customLogCollection = database.GetCollection<CustomLog>(databaseSettings.CustomLogCollectionName);
        }
        public async Task Handle()
        {
            // System.Console.WriteLine(DateTime.Now);
            CustomLog customLog = new CustomLog();
            customLog.IpAddress = Model.IpAddress;
            customLog.CreatedDate = DateTime.Now;
            await _customLogCollection.InsertOneAsync(customLog);
        }
    }

    public class CreateCustomLogModel
    {
        public string IpAddress { get; set; }
    }
}