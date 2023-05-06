namespace Hackaton.Api.Models
{
    public class ErrorResponse
    {
        public ErrorResponse() => Messages = new List<string> { };

        public ErrorResponse(string message) => Messages = new List<string> { message };

        public ErrorResponse(List<string> messages) => Messages = messages;

        public List<string> Messages { get; private set; }
    }
}
