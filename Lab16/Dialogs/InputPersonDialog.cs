using Lab16Lib.Entities;
using System.Windows.Forms;

namespace Lab16.Dialogs
{
    public partial class InputPersonDialog : Form, IInputPersonDialog
    {
        public InputPersonDialog()
        {
            InitializeComponent();
        }

        public InputPersonDialog(Person person)
        {
            InitializeComponent();
            textBox1.Text = person.FirstName;
            textBox2.Text = person.LastName;
            numericUpDown1.Value = person.Age;
        }

        public Person Value => new(
            textBox1.Text.Length == 0 ? "--" : textBox1.Text,
            textBox2.Text.Length == 0 ? "--" : textBox2.Text,
            (int)numericUpDown1.Value
        );
    }
}
