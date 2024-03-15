using Lab16Lib.Entities;

namespace Lab16.Dialogs
{
    internal interface IInputPersonDialog
    {
        public Person Value { get; }

        public DialogResult ShowDialog();
    }
}
