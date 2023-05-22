using Microsoft.AspNetCore.Mvc;
using SpinomenalConnector.Models;
using SpinomenalConnector.Services;

namespace SpinomenalConnector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectorController : ControllerBase
    {
        private readonly IConnectorService _connectorService;
        public ConnectorController(IConnectorService connectorService)
        {
            _connectorService = connectorService;
        }

        [HttpPost( Name = "UpdateBalance")]
        public UpdateBalanceResponseModel UpdateBalance([FromBody] UpdateBalanceRequestModel model)
        {
            UpdateBalanceResponseModel response = _connectorService.UpdateBalance(model);

            return response;
        }
    }
}
