using SpinomenalConnector.Models;

namespace SpinomenalConnector.Services
{
    public class ConnectorService : IConnectorService
    {
        private readonly GameClientFactory _gameClientFactory;
        public ConnectorService(GameClientFactory gameClientFactory)
        {
            _gameClientFactory = gameClientFactory;
        }

        public UpdateBalanceResponseModel UpdateBalance(UpdateBalanceRequestModel i_Model)
        {
            UpdateBalanceResponseModel response = new UpdateBalanceResponseModel();
            IGameClient client = _gameClientFactory.CreateClient(i_Model.IntegrationType);
            ClientResponseModel clientResponse = TrySendRequestToClient(client, i_Model);

            if (clientResponse != null)
            {
                response.IsSuccess = clientResponse.status == "RS_OK";
                response.Balance = clientResponse.balance / 100;
                response.ExternalTransactionId = Guid.NewGuid().ToString();
            }

            return response;
        }

        private ClientResponseModel TrySendRequestToClient(IGameClient i_Client, UpdateBalanceRequestModel i_Model)
        {
            ClientResponseModel clientResponse = i_Client.SendRequest(i_Model);
            int failedAttempts = 0;
            while (failedAttempts < 2 && clientResponse == null)
            {
                System.Threading.Thread.Sleep(++failedAttempts * 2000);
                clientResponse = i_Client.SendRequest(i_Model);
            }

            if (failedAttempts == 2)
            {
                throw new Exception($"Could Not Reach The Client after {failedAttempts} Attempts.");
            }

            return clientResponse;
        }
    }
}
