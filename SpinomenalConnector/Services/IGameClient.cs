using SpinomenalConnector.Models;

namespace SpinomenalConnector.Services
{
    public interface IGameClient
    {
        ClientResponseModel SendRequest(UpdateBalanceRequestModel i_Model);
    }
}
