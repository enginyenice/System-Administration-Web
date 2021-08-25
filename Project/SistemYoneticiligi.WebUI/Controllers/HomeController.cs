using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemYoneticiligi.WebUI.Operations.CustomLogOperations.Commands.CreateCustomLog;
using SistemYoneticiligi.WebUI.Operations.CustomLogOperations.Queries.GetCustomLogs;
using SistemYoneticiligi.WebUI.Settings;

namespace SistemYoneticiligi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabaseSettings _databaseSettings;
        public HomeController(IDatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        public async Task<IActionResult> Index()
        {
            GetCustomLogsQuery getCustomLogsQuery = new GetCustomLogsQuery(_databaseSettings);
            
            List<GetCustomLogViewModel> result =await getCustomLogsQuery.Handle();
            
            return View(result);
        }

        [HttpPost("createlog")]
        public async  Task<IActionResult> CreateLog([FromBody]CreateCustomLogModel log){
            CreateCustomLogCommand createCustomLogCommand = new CreateCustomLogCommand(_databaseSettings);
            
            createCustomLogCommand.Model = log;
            
            await createCustomLogCommand.Handle();
            
            return Ok();
        }


    }
}
