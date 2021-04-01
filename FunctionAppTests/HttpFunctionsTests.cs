using FunctionAppRefactored;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FunctionAppTests
{
    [TestClass]
    public class HttpFunctionsTests
    {
        private readonly ILogger logger = Substitute.For<ILogger>();
        /// <summary>
        /// Get Test - with query parameters
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task HttpFunctionGetName()
        {            
            var request = HttpTestFactory.CreateHttpRequest("name", "Jorge");
            OkObjectResult result = (OkObjectResult)await HttpFunction.Run(request, logger);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual("Hello, Jorge. This HTTP triggered function executed successfully.", result.Value);
        }

        /// <summary>
        /// Post Test - property "name" exists + has value
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task HttpFunctionPostName()
        {
            var httpreq = Substitute.For<HttpRequest>();            
            httpreq.Body = HttpTestFactory.GenerateBody("{\"name\":\"Igor\"}");             
            OkObjectResult rs = (OkObjectResult)await HttpFunction.Run(httpreq, logger);
            Assert.AreEqual((int)HttpStatusCode.OK, rs.StatusCode);
            Assert.AreEqual("Hello, Igor. This HTTP triggered function executed successfully.", rs.Value);
        }

        /// <summary>
        /// Post Test - With Body - Without query parameters
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task HttpFunctionPostNoQuery()
        {
            var httpReq = Substitute.For<HttpRequest>();
            httpReq.Body = HttpTestFactory.GenerateBody(string.Empty);            
            OkObjectResult rs = (OkObjectResult)await HttpFunction.Run(httpReq, logger);
            Assert.AreEqual((int)HttpStatusCode.OK, rs.StatusCode);
            Assert.AreEqual("This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.", rs.Value);
        }

        /// <summary>
        /// Post Test - property "name" exists + has no value
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task HttpFunctionPostNoName()
        {
            //var httpreq = HttpTestFactory.CreateHttpRequest("name", "");
            var httpReq = Substitute.For<HttpRequest>();            
            string name = httpReq.Query["name"];
            var body = HttpTestFactory.GenerateBody("{\"name\":}").ToString();
            dynamic data = JsonConvert.DeserializeObject(body);            

            OkObjectResult rs = (OkObjectResult)await HttpFunction.Run(httpReq, logger);

            Assert.AreEqual(name, data);
            





        }


    }    
}
