using Lab16Lib.Entities;
using System.ComponentModel;

namespace Lab16.Dialogs
{
    public partial class InputPartTimeStudentDialog : Form, IInputPersonDialog
    {
        public InputPartTimeStudentDialog()
        {
            InitializeComponent();
        }

        public InputPartTimeStudentDialog(PartTimeStudent student)
        {
            InitializeComponent();
            textBox1.Text = student.FirstName;
            textBox2.Text = student.LastName;
            numericUpDown1.Value = student.Age;
            textBox3.Text = student.Rating.ToString();
            numericUpDown2.Value = student.UniversityID;
            numericUpDown3.Value = student.RandomID;
        }

        public Person Value => new PartTimeStudent(
            textBox1.Text.Length == 0 ? "--" : textBox1.Text,
            textBox2.Text.Length == 0 ? "--" : textBox2.Text,
            (int)numericUpDown1.Value,
            float.Parse(textBox3.Text == "" ? "0" : textBox3.Text),
            (uint)numericUpDown2.Value,
            (int)numericUpDown3.Value
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
