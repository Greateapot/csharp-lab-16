namespace Lab16.Dialogs
{
    public partial class InputLengthDialog : Form
    {
        public InputLengthDialog(string title)
        {
            InitializeComponent();
            Text = title;
        }

        public int Value => (int)numericUpDown1.Value;
    }
}
