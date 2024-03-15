using Lab16Lib.Entities;
using System.ComponentModel;

namespace Lab16.Dialogs
{
    public partial class InputPupilDialog : Form, IInputPersonDialog
    {
        public InputPupilDialog()
        {
            InitializeComponent();
        }

        public InputPupilDialog(Pupil pupil)
        {
            InitializeComponent();
            textBox1.Text = pupil.FirstName;
            textBox2.Text = pupil.LastName;
            numericUpDown1.Value = pupil.Age;
            textBox3.Text = pupil.Rating.ToString();
            numericUpDown2.Value = pupil.SchoolID;
        }

        public Person Value => new Pupil(
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
