namespace ChuckSWWeb.Models
{
    public class ResponseModel
    {

        public bool Status { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
    }
}
