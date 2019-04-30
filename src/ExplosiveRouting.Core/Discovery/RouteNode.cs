using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExplosiveRouting.Discovery
{
    public class RouteNode
    {
        public List<RouteNode> Next { get; set; } = new List<RouteNode>();

        public string[] Routes { get; set; }
    }
}
