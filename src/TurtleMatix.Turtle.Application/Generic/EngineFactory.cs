using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TurtleMatix.Turtle.Application.Generic
{
    public class EngineFactory : _IEngineFactory
    {

        private readonly Assembly _turtleHostAssembly = Assembly.Load(new AssemblyName("TurtleMatix.Turtle.Host"));

        private readonly IEnumerable<_IEngine> _engines;

        public EngineFactory()
        {
            var types = _turtleHostAssembly
                .DefinedTypes.Where(x =>
                    x.IsClass && !x.IsAbstract &&
                    x.ImplementedInterfaces.Any(y => y == typeof(_IEngine)));

            _engines = types.Select(x => (_IEngine) Activator.CreateInstance(x.AsType())).ToList();
        }

        public _IEngine GetFrontEngine()
        {
            return _engines.First(x=>x.GetType().Name == "FrontEngine");
        }

        public _IEngine GetBackEngine()
        {
            return _engines.First(x => x.GetType().Name == "BackEngine");
        }
    }
}