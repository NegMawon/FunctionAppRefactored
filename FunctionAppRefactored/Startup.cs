﻿using System;
using System.Collections.Generic;
using System.Text;
using FunctionAppRefactored;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly : FunctionsStartup(typeof(FunctionAppRefactored.Startup))]
namespace FunctionAppRefactored
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
        }
    }
}