namespace Franky
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Xamarin.Forms;

    public class ZoneInstructions : AbsoluteLayout
    {
        private FakeInstructionButton fakeInstructionButton;

        private DropInstructions dropInstruction;

        public ZoneInstructions()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += this.OnPanUpdated;
            this.GestureRecognizers.Add(panGesture);
            this.DescendantAdded += this.ZoneInstructionsChildAdded;
        }

        private InstructionButton SelectedButtonInstruction { get; set; }

        private void ZoneInstructionsChildAdded(object sender, ElementEventArgs e)
        {
            var fakeInstructionButton = e.Element as FakeInstructionButton;
            if (fakeInstructionButton != null)
            {
                this.fakeInstructionButton = fakeInstructionButton;
                this.fakeInstructionButton.IsVisible = false;
                this.fakeInstructionButton.ZoneInstructions = this;
                return;
            }

            var instructionButton = e.Element as InstructionButton;
            if (instructionButton != null)
            {
                instructionButton.Selected += this.InstructionButtonSelected;
                instructionButton.ZoneInstructions = this;
            }

            var dropInstruction = e.Element as DropInstructions;
            if (dropInstruction != null)
            {
                this.dropInstruction = dropInstruction;
            }
        }

        private void InstructionButtonSelected(object sender, EventArgs e)
        {
            this.SelectedButtonInstruction = (InstructionButton)sender;
            this.fakeInstructionButton.ChangeButton(this.SelectedButtonInstruction);
            this.fakeInstructionButton.IsVisible = true;
        }

        public void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    break;
                case GestureStatus.Running:
                    this.fakeInstructionButton.UpdateTranslation(e);
                    var displayPreview = this.dropInstruction.Preview(this.fakeInstructionButton);
                    this.fakeInstructionButton.IsVisible = !displayPreview;
                    break;
                case GestureStatus.Completed:
                    this.dropInstruction.Apply(this.fakeInstructionButton);
                    this.fakeInstructionButton.Completed();
                    this.fakeInstructionButton.IsVisible = false;
                    this.SelectedButtonInstruction = null;
                    break;
                case GestureStatus.Canceled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}