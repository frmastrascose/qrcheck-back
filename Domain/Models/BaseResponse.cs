using Domain.Exceptions;

namespace Domain.Models
{
    public class BaseResponse
    {
        public bool success { get; private set; }
        public List<string> message { get; private set; }
        public dynamic data { get; set; }

        public BaseResponse(dynamic data)
        {
            if (IsNotContainsData(data))
                throw new DomainException();

            this.success = true;
            this.message = null;
            this.data = data;
        }

        public BaseResponse(List<string> messageError)
        {
            this.success = false;
            this.message = messageError;
            this.data = null;
        }

        public BaseResponse(string messageError)
        {
            success = false;
            message = new List<string> { messageError };
            data = null;
        }

        public BaseResponse(string messageError, bool success)
        {
            this.success = success;
            message = new List<string> { messageError };
            data = null;
        }

        bool IsNotContainsData(dynamic data)
        {

            if (data == null)
            {
                return true;
            }

            Type type = data.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                if (Enumerable.Count(data) == 0)
                    return true;
            }

            return false;
        }
    }
}
