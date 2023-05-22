namespace SpinomenalConnector.Models
{
    public class UpdateBalanceRequestModel
    {
        public string IntegrationType { get; set; }
        public string Url { get; set; }
        public RequestParamsModel RequestParams { get; set; }
    }
}
