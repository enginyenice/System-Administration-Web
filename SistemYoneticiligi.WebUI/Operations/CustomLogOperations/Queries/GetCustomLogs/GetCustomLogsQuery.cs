using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SistemYoneticiligi.WebUI.Entities;
using SistemYoneticiligi.WebUI.Settings;

namespace SistemYoneticiligi.WebUI.Operations.CustomLogOperations.Queries.GetCustomLogs
{
    public class GetCustomLogsQuery
    {

        private readonly IMongoCollection<CustomLog> _customLogCollection;

        public GetCustomLogsQuery(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _customLogCollection = database.GetCollection<CustomLog>(databaseSettings.CustomLogCollectionName);
        }

        public async Task<List<GetCustomLogViewModel>> Handle()
        {

            List<CustomLog> customLogs =await _customLogCollection.Find(ipaddress => true).ToListAsync();
            customLogs = customLogs.OrderByDescending(p => p.Id).ToList();
            List<GetCustomLogViewModel> models = new List<GetCustomLogViewModel>();

            foreach (var item in customLogs)
            {
                GetCustomLogViewModel model = new GetCustomLogViewModel();
                model.IpAddress = item.IpAddress;
                model.Date = item.CreatedDate.ToString("dd/MM/yyyy HH:mm");
                models.Add(model);
            }
            return models;
        }
    }

    public class GetCustomLogViewModel
    {

        [Display(Name ="IP adresi")]
        public string IpAddress { get; set; }

        [Display(Name ="Tarih")]
        public string Date { get; set; }
    }
}