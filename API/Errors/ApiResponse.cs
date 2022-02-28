using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Requset you have made",
                401 => "You Are Not Authorized",
                404 => "Resouce Not Found",
                500 => "Error from the Server",
                _ => null

            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        
        
        
        
    }
}