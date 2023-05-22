using SpinomenalConnector.Models;

namespace SpinomenalConnector.Services
{
    public interface IConnectorService
    {
        public UpdateBalanceResponseModel UpdateBalance(UpdateBalanceRequestModel i_Model);
    }
}
