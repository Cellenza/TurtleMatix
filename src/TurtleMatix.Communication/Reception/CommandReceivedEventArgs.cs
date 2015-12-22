using System;
using TurtleMatix.Core;

namespace TurtleMatix.Communication.Reception
{
    public class CommandReceivedEventArgs : EventArgs
    {
        public CommandReceivedEventArgs(TurtleAlgorithm algorithm)
        {
            Algorithm = algorithm;
        }

        public TurtleAlgorithm Algorithm { get;}
    }
}
