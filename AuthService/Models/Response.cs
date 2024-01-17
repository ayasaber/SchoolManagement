﻿using System.Net;

namespace AuthService.Models
{
    public class Response
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public IList<ValidationRule> BrokenRules { get; set; } = new List<ValidationRule>();
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;

        public Response() { }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public Response(bool succeeded)
        {
            Succeeded = succeeded;
            Message = Succeeded ? "Operation has been completed successfully." : "Operation has been failed!";
        }

        public static implicit operator Response(bool successded)
        {
            return new Response(successded);
        }

        public static implicit operator Response(string message)
        {
            return new Response(message);
        }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }

        public Response() { }

        public Response(T data, bool succeeded = true, string message = null)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }

        public Response(string message) : base(message) { }

        public Response(bool succeeded) : base(succeeded) { }


        public static implicit operator Response<T>(T data)
        {
            return new Response<T>(data);
        }

        public static implicit operator Response<T>(bool successded)
        {
            return new Response<T>(successded);
        }
    }

    public class ValidationRule
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
