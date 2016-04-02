using System;
using System.Collections.Generic;
using System.Linq;

namespace TurtleMatix.Core
{
    public class TurtleAlgorithm
    {
        public List<TurtleCommand> Commands { get; set; }

        public TurtleAlgorithm()
        {
            Commands = new List<TurtleCommand>();
        }

        public static TurtleAlgorithm FromString(string input)
        {
            var parts = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            var result = new TurtleAlgorithm {Commands = parts.Select(TurtleCommand.FromString).ToList()};
            return result;
        }

        public override string ToString()
        {
            return string.Join(";", Commands);
        }
    }
}