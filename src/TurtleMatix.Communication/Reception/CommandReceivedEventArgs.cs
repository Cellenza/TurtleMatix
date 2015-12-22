using System;
using TurtleMatix.Communication.Core;
using TurtleMatix.Core;

namespace TurtleMatix.Communication.Reception
{
    public class CommandReceivedEventArgs : EventArgs
    {
        public CommandReceivedEventArgs(TurtleCommand command)
        {
            Command = command;
        }

        public TurtleCommand Command { get;}
    }
}
