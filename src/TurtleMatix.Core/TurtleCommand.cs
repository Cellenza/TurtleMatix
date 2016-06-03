using System;

namespace TurtleMatix.Core
{
    using System.Collections.Generic;

    public class TurtleCommand
    {

        public TurtleCommand(TurtleOperator op, int val)
        {
            Operator = op;
            Operand = val;
        }

        public TurtleOperator Operator { get; set; }

        public int Operand { get; set; }

        public List<TurtleCommand> Childrens { get; set; }
    }
}
