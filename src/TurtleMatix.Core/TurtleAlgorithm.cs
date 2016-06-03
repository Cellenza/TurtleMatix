using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TurtleMatix.Core
{
    public class TurtleAlgorithm
    {
        public List<TurtleCommand> Commands { get; }

        public TurtleAlgorithm()
        {
            Commands = new List<TurtleCommand>();
        }

        public void AddCommand(TurtleCommand command)
        {
            Commands.Add(command);
        }

        public static TurtleAlgorithm FromString(string input)
        {
            return JsonConvert.DeserializeObject<TurtleAlgorithm>(input);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}