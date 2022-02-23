using System.Collections.Generic;

namespace API.Wrappers
{
    public class Response<T>
    {
        public bool Succeded { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public Response()
        {
        }
        public Response(T data)
        {
            Succeded = true;
            Data = data;
        }
        public Response(string message)
        {
            Succeded = false;
            Message = message;
        }

        public Response(List<string> errors)
        {
            Succeded = false;
            Errors = errors;
        }
    }
}
