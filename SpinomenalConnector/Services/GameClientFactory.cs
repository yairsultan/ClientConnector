namespace SpinomenalConnector.Services
{
    public class GameClientFactory
    {
        public IGameClient CreateClient(string productType)
        {
            switch (productType)
            {
                case "INT1":
                    return new INT1GameClient();
                case "INT2":
                    return new INT2GameClient();
                default:
                    throw new ArgumentException("Invalid product type.");
            }
        }
    }
}
