namespace Lab16.Dialogs
{
    public partial class InputPersonTypeDialog : Form
    {
        public InputPersonTypeDialog()
        {
            InitializeComponent();
        }

        public int SelectedIndex => comboBox1.SelectedIndex;
    }
}
