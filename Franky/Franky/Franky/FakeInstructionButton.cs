namespace Franky
{
    using System;

    using Xamarin.Forms;

    public class FakeInstructionButton : InstructionButton
    {
        public void ChangeButton(InstructionButton selectedButtonInstruction)
        {
            this.TranslationX = selectedButtonInstruction.TranslationX;
            this.TranslationY = selectedButtonInstruction.TranslationY;
            this.BackgroundColor = selectedButtonInstruction.BackgroundColor;
            this.InitialX = selectedButtonInstruction.InitialX;
            this.InitialY = selectedButtonInstruction.InitialY;
            this.Text = selectedButtonInstruction.Text;
            this.Instruction = selectedButtonInstruction.Instruction;
            this.Value = selectedButtonInstruction.Value;
        }

        public void UpdateTranslation(PanUpdatedEventArgs e)
        {
            this.TranslationX = Math.Max(0, this.InitialX + e.TotalX);
            this.TranslationY = Math.Max(0, this.InitialY + e.TotalY);
        }

        public void Completed()
        {
            this.TranslationX = this.InitialX;
            this.TranslationY = this.InitialY;
        }
    }
}