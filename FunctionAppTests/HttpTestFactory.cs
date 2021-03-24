using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FunctionAppTests
{
    public class HttpTestFactory
    {
        /// <summary>
        /// Mocking for Http Requests
        /// Build the Http Request body
        /// </summary>        
        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };
            return qs;
        }

        // Mock the HttpRequest        
        public static HttpRequest CreateHttpRequest(string queryStringKey, string queryStringValue)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Query = new QueryCollection(CreateDictionary(queryStringKey, queryStringValue));
            return request;
        }

        public static Stream GenerateBody(string jsonserializedString)
        {
            var content = jsonserializedString;
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            return stream;
        }
    }
}
