using Lab16.Dialogs;
using Lab16Lib.Entities;
using Lab16Lib.Randomizers;

namespace Lab16
{
    public partial class Form1
    {
        private void CreateCollection(int size)
        {
            people = [];
            people.AddRange(RandomPersonGenerator.GetRandomPersons(size));
            UpdateText();
            toolStripStatusLabel1.Text = "Новая коллекция создана";
        }

        private void ПустойToolStripMenuItem_Click(object sender, EventArgs e) => CreateCollection(0);

        private void ЗаданнойДлиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inputLengthDialog = new InputLengthDialog("Введите кол-во:");
            if (inputLengthDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }
            CreateCollection(inputLengthDialog.Value);
        }

        private void ВручнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            var inputPersonTypeDialog = new InputPersonTypeDialog();
            if (inputPersonTypeDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }

            IInputPersonDialog? inputPersonDialog = (inputPersonTypeDialog.SelectedIndex) switch
            {
                0 => new InputPersonDialog(),
                1 => new InputPupilDialog(),
                2 => new InputStudentDialog(),
                3 => new InputPartTimeStudentDialog(),
                _ => null
            };
            if (inputPersonDialog == null)
            {
                toolStripStatusLabel1.Text = "Тип не выбран";
                return;
            }

            if (inputPersonDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }

            people.Add(inputPersonDialog.Value);
            toolStripStatusLabel1.Text = "Элемент успешно добавлен";
            UpdateText();
        }

        private void ДСЧToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }
            var inputLengthDialog = new InputLengthDialog("Введите кол-во:");
            if (inputLengthDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }
            people.AddRange(RandomPersonGenerator.GetRandomPersons(inputLengthDialog.Value));
            toolStripStatusLabel1.Text = $"{inputLengthDialog.Value} элементов успешно добавлены";
            UpdateText();
        }

        private void КорректироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            var inputPersonDialog = new InputPersonDialog();
            if (inputPersonDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }

            var person = inputPersonDialog.Value;
            var element = people.First(e => person.CompareTo(e) == 0);

            IInputPersonDialog? inputPersonDialog1 = null;

            if (element is PartTimeStudent partTimeStudent)
                inputPersonDialog1 = new InputPartTimeStudentDialog(partTimeStudent);
            else if (element is Student student)
                inputPersonDialog1 = new InputStudentDialog(student);
            else if (element is Pupil pupil)
                inputPersonDialog1 = new InputPupilDialog(pupil);
            else if (element is Person person1)
                inputPersonDialog1 = new InputPersonDialog(person1);
            
            if (inputPersonDialog1 == null)
            {
                toolStripStatusLabel1.Text = $"Обнаружен неизвестный тип данных: {element.GetType()}";
                return;
            }

            if (inputPersonDialog1.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }

            people.Remove(element);
            people.Add(inputPersonDialog1.Value);
            toolStripStatusLabel1.Text = "Элемент успешно откорректирован";
            UpdateText();
        }

        private void УдалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            var inputPersonDialog = new InputPersonDialog();
            if (inputPersonDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }

            var result = people.Remove(inputPersonDialog.Value);
            if (result)
            {
                toolStripStatusLabel1.Text = "Элемент успешно удален";
                UpdateText();
            }
            else
            {
                toolStripStatusLabel1.Text = "Элемент не найден";
            }
        }

        private void ПоискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            var inputPersonDialog = new InputPersonDialog();
            if (inputPersonDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Действие отменено";
                return;
            }

            var result = people.Contains(inputPersonDialog.Value);
            toolStripStatusLabel1.Text = result
                ? "Элемент найден"
                : "Элемент не найден";
        }

        private void ОчиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нет коллекции";
                return;
            }

            people.Clear();
            toolStripStatusLabel1.Text = "Коллекция очищена";
            UpdateText();
        }
    }
}
