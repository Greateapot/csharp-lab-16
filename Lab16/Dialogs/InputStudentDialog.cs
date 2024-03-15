using Lab16Lib.Entities;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lab16.Dialogs
{
    public partial class InputStudentDialog : Form, IInputPersonDialog
    {
        public InputStudentDialog()
        {
            InitializeComponent();
        }

        public InputStudentDialog(Student student)
        {
            InitializeComponent();
            textBox1.Text = student.FirstName;
            textBox2.Text = student.LastName;
            numericUpDown1.Value = student.Age;
            textBox3.Text = student.Rating.ToString();
            numericUpDown2.Value = student.UniversityID;
        }

        public Person Value => new Student(
            textBox1.Text.Length == 0 ? "--" : textBox1.Text,
            textBox2.Text.Length == 0 ? "--" : textBox2.Text,
            (int)numericUpDown1.Value,
            float.Parse(textBox3.Text == "" ? "0" : textBox3.Text),
            (uint)numericUpDown2.Value
        );

        private void TextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (
                !float.TryParse(textBox3.Text, out float value)
                || value < Pupil.MinRating
                || value > Pupil.MaxRating
            ) textBox3.Text = "";

        }
    }
}
