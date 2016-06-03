namespace Franky
{
    using System.Collections.Generic;

    public class GlobalInstructionCode : ForEachInstructionCode
    {
        public GlobalInstructionCode(double width)
            : base(width, 0)
        {
            this.Children.Clear();
        }
    }
}