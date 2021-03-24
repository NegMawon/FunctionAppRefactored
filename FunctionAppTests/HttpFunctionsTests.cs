using FunctionAppRefactored;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod]
        public async Task HttpFunctionShouldReturnSetString()
        {
            //var logger = Substitute.For<ILogger>();
            var request = HttpTestFactory.CreateHttpRequest("name", "Jorge");
            OkObjectResult result = (OkObjectResult)await HttpFunction.Run(request, logger);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual("Hello, Jorge. This HTTP triggered function executed successfully.", result.Value);
        }

        [TestMethod]
        public async Task ReturnStringFromBody()
        {
            var httpreq = Substitute.For<HttpRequest>();                        
            httpreq.Body = HttpTestFactory.GenerateBody("{\"name\":\"Igor\"}");             
            OkObjectResult rs = (OkObjectResult)await HttpFunction.Run(httpreq, logger);
            Assert.AreEqual((int)HttpStatusCode.OK, rs.StatusCode);
            Assert.AreEqual("Hello, Igor. This HTTP triggered function executed successfully.", rs.Value);
        }

        [TestMethod]
        public async Task NameNotFoundDefaultMessage()
        {
            var request = HttpTestFactory.CreateHttpRequest("", "");
            OkObjectResult rs = (OkObjectResult)await HttpFunction.Run(request, logger);
            Assert.AreEqual((int)HttpStatusCode.OK, rs.StatusCode);
            Assert.AreEqual("This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.", rs.Value);
        }

       
    }    
}
