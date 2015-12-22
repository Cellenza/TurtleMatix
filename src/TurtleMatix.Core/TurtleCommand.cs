using System;

namespace TurtleMatix.Core
{
    public class TurtleCommand
    {

        public TurtleCommand(TurtleOperator op, int val)
        {
            Operator = op;
            Operand = val;
        }

        public TurtleOperator Operator { get; set; }

        public int Operand { get; set; }

        public static TurtleCommand FromString(string input)
        {
            var parts = input.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            return new TurtleCommand(
                (TurtleOperator)Enum.Parse(typeof(TurtleOperator), parts[0], true),
                int.Parse(parts[1]));
        }

        public override string ToString()
        {
            return Operator + "|" + Operand;
        }
        public override bool Equals(object obj)
        {
            var castedInput = obj as TurtleCommand;

            if (castedInput == null)
                throw new ArgumentException("Not valid type, please use an instance of Type 'TurtleCommand'");

            return Operand == castedInput.Operand && Operator == castedInput.Operator;
        }

    }
}
