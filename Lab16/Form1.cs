using Lab16Lib.Entities;
using System.Text;

namespace Lab16
{
    public partial class Form1 : Form
    {
        private List<Person>? people = null;

        public Form1()
        {
            InitializeComponent();
            UpdateText();
        }

        private void UpdateText()
        {
            if (people == null)
            {
                richTextBox1.Text = "Â îæèäàíèè êîëëåêöèè...";
                return;
            }

            var stringBuilder = new StringBuilder();
            foreach (var item in people)
                stringBuilder.AppendLine(item.ToString());
            richTextBox1.Text = stringBuilder.ToString();
        }

        private void Ïå÷àòüToolStripMenuItem_Click(object sender, EventArgs e) => UpdateText();
    }
}
