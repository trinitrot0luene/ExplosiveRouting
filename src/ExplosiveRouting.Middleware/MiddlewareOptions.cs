﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Middleware
{
    public sealed class MiddlewareOptions : IMiddlewareOptions
    {
        public IServiceProvider ServiceProvider { get; set ; }

        public ExecutionMode ExecutionMode { get; set; }

        internal MiddlewareOptions()
        {
        }
    }
}