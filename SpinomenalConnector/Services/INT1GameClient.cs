using SpinomenalConnector.MockService;
using SpinomenalConnector.Models;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace SpinomenalConnector.Services
{
    public class INT1GameClient : IGameClient
    {
        public ClientResponseModel SendRequest(UpdateBalanceRequestModel i_Model)
        {
            string encryptedBody = getEncryptedBody(i_Model);
            byte[] XSecure = ComputeSHA256Hash(encryptedBody);
            string tls = "Tls1.2";

            return MockClient.UpdateBalance(XSecure, tls);
        }

        private string getEncryptedBody(UpdateBalanceRequestModel i_Model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            PropertyInfo[] properties = i_Model.RequestParams.GetType().GetProperties();
            PropertyInfo[] sortedProperties = properties.OrderBy(p => p.Name).ToArray();

            foreach (PropertyInfo property in sortedProperties)
            {
                string? propertyValue = property.GetValue(i_Model.RequestParams)?.ToString();
                stringBuilder.Append(propertyValue);
            }

            stringBuilder.Append("SECCCRET");

            return stringBuilder.ToString();
        }

        private byte[] ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                return hashBytes;
            }
        }
    }
}
