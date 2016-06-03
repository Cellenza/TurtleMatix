namespace Franky
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using TurtleMatix.Core;

    using Xamarin.Forms;

    public class ForEachInstructionCode : InstructionCode
    {
        private InstructionCode createInstructionCode;

        private int currentIndex = -1;

        private readonly double headerHeight;

        private readonly AbsoluteLayout whiteLayout;

        private readonly List<ForEachInstructionCode> forEachInstructionCodes;

        private readonly List<InstructionCode> instructionCodes;

        protected ForEachInstructionCode(double width, double headerHeight)
            : base(width)
        {
            this.headerHeight = headerHeight;
            this.HeightRequest = 120;

            this.whiteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.White,
                WidthRequest = width - 4,
                HeightRequest = this.HeightRequest - 52,
                TranslationY = 50,
                TranslationX = 2
            };
            this.Children.Add(this.whiteLayout);
            this.forEachInstructionCodes = new List<ForEachInstructionCode>();
            this.instructionCodes = new List<InstructionCode>();
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            this.whiteLayout.HeightRequest = heightConstraint - 52;
            return base.OnSizeRequest(widthConstraint, heightConstraint);
        }

        public bool Apply(InstructionButton instructionButton)
        {
            var instruction = this.createInstructionCode;
            this.currentIndex = -1;
            this.createInstructionCode = null;

            if (this.NotInSection(instructionButton.TranslationY))
            {
                this.RemovePreview();

                return false;
            }

            var instructionCodes = this.forEachInstructionCodes.ToList();
            foreach (var forEachInstructionCode in instructionCodes)
            {
                if (forEachInstructionCode == this.createInstructionCode)
                {
                    continue;
                }

                if (forEachInstructionCode.Apply(instructionButton))
                {
                    this.RemovePreview();

                    this.UpdatePosition();

                    return true;
                }
            }

            var eachInstructionCode = instruction as ForEachInstructionCode;
            if (eachInstructionCode != null)
            {
                this.forEachInstructionCodes.Add(eachInstructionCode);
            }

            this.HeightRequest += instruction.HeightRequest;

            this.UpdatePosition();

            return true;
        }

        public bool Preview(InstructionButton instructionButton)
        {
            if (this.NotInSection(instructionButton.TranslationY))
            {
                this.RemovePreview();

                return false;
            }

            if (this.createInstructionCode == null)
            {
                this.createInstructionCode = this.CreateInstructionCode(instructionButton);
                this.Children.Add(this.createInstructionCode);
            }

            foreach (var forEachInstructionCode in this.forEachInstructionCodes)
            {
                if (forEachInstructionCode == this.createInstructionCode)
                {
                    continue;
                }

                if (forEachInstructionCode.Preview(instructionButton))
                {
                    this.RemovePreview();

                    this.UpdatePosition();

                    return true;
                }
            }

            var newIndex = this.GetIndex(instructionButton);

            if (this.currentIndex != newIndex)
            {
                this.RemovePreview();

                Debug.WriteLine("Index : " + newIndex);
                this.createInstructionCode.IsVisible = true;
                Debug.WriteLine("AddPreview");
                this.instructionCodes.Insert(newIndex, this.createInstructionCode);
                this.currentIndex = newIndex;

                this.UpdatePosition();
            }

            return true;
        }

        private bool NotInSection(double position)
        {
            return position < this.TranslationY + this.headerHeight || position > this.TranslationY + this.HeightRequest;
        }

        private int GetIndex(InstructionButton instructionButton)
        {
            var position = instructionButton.TranslationY;

            var newIndex = -1;

            if (position > 0)
            {
                for (var index = 0; index < this.instructionCodes.Count; index++)
                {
                    var instruction = this.instructionCodes[index];

                    if (instruction.IsOnInstruction(position))
                    {
                        newIndex = index;
                        break;
                    }
                }
            }
            else
            {
                newIndex = 0;
            }


            if (newIndex == -1)
            {
                if (this.currentIndex != -1)
                {
                    newIndex = this.instructionCodes.Count - 1;
                }
                else
                {
                    newIndex = this.instructionCodes.Count;
                }
            }

            return newIndex;
        }

        private void RemovePreview()
        {
            if (this.createInstructionCode != null)
            {
                Debug.WriteLine("RemovePreview");

                this.createInstructionCode.IsVisible = false;
                this.instructionCodes.Remove(this.createInstructionCode);
                this.currentIndex = -1;
            }
        }

        protected void UpdatePosition()
        {
            var y = this.headerHeight;
            var instructionCodes = this.instructionCodes;
            for (int index = 0; index < instructionCodes.Count; index++)
            {
                var instruction = instructionCodes[index];
                instruction.TranslationY = y;
                y += instruction.HeightRequest;

                instruction.TranslationX = this.Width / 2 - instruction.WidthRequest / 2;
            }
        }

        private InstructionCode CreateInstructionCode(InstructionButton instructionButton)
        {
            if (instructionButton.Instruction == TurtleOperator.ForEach)
            {
                var instructionCode = new ForEachInstructionCode(this.WidthRequest - 20, 50);
                instructionCode.SetFromInstructionButton(instructionButton);
                return instructionCode;
            }

            var instruction = new InstructionCode(this.WidthRequest - 20);
            instruction.SetFromInstructionButton(instructionButton);
            return instruction;
        }

        public List<TurtleCommand> GetInstructions()
        {
            var q = from i in this.instructionCodes select this.CreateCommand(i);

            return q.ToList();
        }

        private TurtleCommand CreateCommand(InstructionCode instructionCode)
        {
            var ins = new TurtleCommand(instructionCode.Instruction, instructionCode.Value);

            switch (instructionCode.Instruction)
            {
                case TurtleOperator.ForEach:
                    ins.Childrens = (instructionCode as ForEachInstructionCode).GetInstructions();
                    break; ;
            }

            return ins;
        }

        public void Clean()
        {
            foreach (var instructionCode in this.forEachInstructionCodes)
            {
                instructionCode.Clean();
            }

            this.forEachInstructionCodes.Clear();
            this.instructionCodes.Clear();
            this.Children.Clear();

            this.UpdatePosition();
        }

    }
}