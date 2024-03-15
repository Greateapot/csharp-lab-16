using Lab16.Dialogs;
using Lab16Lib.Utils;
using System.Text;

namespace Lab16
{
    public partial class Form1
    {
        private void ФильтрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            var inputLengthDialog = new InputLengthDialog("Введите минимальный возраст:");
            if (inputLengthDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }

            var persons = people.GetPersonsWithAgeGreaterThan(inputLengthDialog.Value);
            var stringBuilder = new StringBuilder();
            foreach (var item in persons)
                stringBuilder.AppendLine(item.ToString());
            richTextBox1.Text = stringBuilder.ToString();
            toolStripStatusLabel1.Text = $"Список персон с возрастом больше или равным {inputLengthDialog.Value}";
        }

        private void ПоВозрастуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            people.SortByAge();
            toolStripStatusLabel1.Text = "Отсортировано по возрасту";
            UpdateText();
        }

        private void ПоФамилииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            people.SortByLastName();
            toolStripStatusLabel1.Text = "Отсортировано по фамилии";
            UpdateText();
        }

        private void ПоКлючуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            people.SortByKey();
            toolStripStatusLabel1.Text = "Отсортировано по ключу";
            UpdateText();
        }
    }
}
