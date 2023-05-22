using SpinomenalConnector.Models;

namespace SpinomenalConnector.MockService
{
    public static class MockClient
    {
        public static ClientResponseModel UpdateBalance(byte[] i_XSecure, string i_Tls)
        {
            return new ClientResponseModel { status = "RS_OK", invoice_id = "583c985f-fee6-4c0e-bbf5-308aad6265af", balance = 100500 };
        }
    }
}
