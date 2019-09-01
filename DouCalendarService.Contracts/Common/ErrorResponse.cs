namespace DouCalendarService.Contracts.Common
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public ErrorResponse(string code, string message, object data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public string Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
