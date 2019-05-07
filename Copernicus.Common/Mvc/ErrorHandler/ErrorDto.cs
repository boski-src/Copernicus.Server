using System.Net;
using Newtonsoft.Json;

namespace Copernicus.Common.Mvc.ErrorHandler
{
    public class ErrorDto
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("error")]
        public ErrorDetailsDto Error { get; set; }

        public ErrorDto(HttpStatusCode statusCode, string code, string message)
        {
            Status = (int) statusCode;
            Error = new ErrorDetailsDto(code, message);
        }
    }

    public class ErrorDetailsDto
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorDetailsDto(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}