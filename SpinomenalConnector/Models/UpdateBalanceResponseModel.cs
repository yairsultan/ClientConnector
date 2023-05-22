namespace SpinomenalConnector.Models
{
    public class UpdateBalanceResponseModel
    {
        public string ExternalTransactionId { get; set; }
        public bool IsSuccess { get; set; }
        public double? Balance { get; set; }

        public UpdateBalanceResponseModel()
        {
            ExternalTransactionId = string.Empty;
            IsSuccess = false;
        }
    }
}
