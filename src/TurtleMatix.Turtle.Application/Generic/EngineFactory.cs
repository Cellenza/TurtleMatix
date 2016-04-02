using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TurtleMatix.Turtle.Application.Generic
{
    public class EngineFactory : IEngineFactory
    {

        private readonly Assembly _turtleHostAssembly = Assembly.Load(new AssemblyName("TurtleMatix.Turtle.Host"));

        private readonly IEnumerable<IEngine> _engines;

        public EngineFactory()
        {
            if (_turtleHostAssembly != null)
            {
                var types = _turtleHostAssembly
                    .DefinedTypes.Where(x =>
                        x.IsClass && !x.IsAbstract &&
                        x.ImplementedInterfaces.Any(y => y == typeof (IEngine)));

                _engines = types.Select(x => (IEngine) Activator.CreateInstance(x.AsType())).ToList();
            }
        }

        public IEngine GetLeftEngine()
        {
            return _engines.First(x => x.GetType().Name == "LeftEngine");
        }

        public IEngine GetRightEngine()
        {
            return _engines.First(x => x.GetType().Name == "RightEngine");
        }

        public IEngine GetPenEngine()
        {
            return _engines.First(x => x.GetType().Name == "PenEngine");
        }
    }
}