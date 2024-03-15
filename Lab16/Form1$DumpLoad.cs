using Lab16Lib.DumpLoaders;
using Lab16Lib.Entities;

namespace Lab16
{
    public partial class Form1
    {
        public const string DatFilter = "Binary files (*.dat)|*.dat";
        public const string XmlFilter = "XML files (*.xml)|*.xml";
        public const string JsonFilter = "JSON files (*.json)|*.json";

        private void LoadCollection(string title, string filter, IDumpLoader<List<Person>> dumpLoader)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = title,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = filter,
            };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Файл не был выбран";
                return;
            }
            var tmp = dumpLoader.Load(openFileDialog.FileName);
            if (tmp == null)
            {
                toolStripStatusLabel1.Text = "Не удалось загрузить файл";
                return;
            }
            people = tmp;
            toolStripStatusLabel1.Text = "Файл успешно загружен";
            UpdateText();
        }

        private void DumpCollection(string title, string filter, IDumpLoader<List<Person>> dumpLoader)
        {
            if (people == null)
            {
                toolStripStatusLabel1.Text = "Нечего сохранять";
                return;
            }
            var saveFileDialog = new SaveFileDialog()
            {
                Title = title,
                OverwritePrompt = true,
                CheckWriteAccess = true,
                CheckPathExists = true,
                AddExtension = true,
                Filter = filter,
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                toolStripStatusLabel1.Text = "Файл не был выбран";
                return;
            }
            var result = dumpLoader.Dump(people, saveFileDialog.FileName);
            toolStripStatusLabel1.Text = result
                ? "Коллекция успешно сохранена"
                : "Не удалось сохранить в файл";
        }
        // bin load
        private void BinarybinToolStripMenuItem_Click(object sender, EventArgs e)
            => LoadCollection("Pick your binary file", DatFilter, new BinaryDumpLoader<List<Person>>());

        // bin dump
        private void BinarydatToolStripMenuItem_Click(object sender, EventArgs e)
            => DumpCollection("Pick your binary file", DatFilter, new BinaryDumpLoader<List<Person>>());

        // xml load
        private void XmlxmlToolStripMenuItem_Click(object sender, EventArgs e)
            => LoadCollection("Pick your xml file", XmlFilter, new XmlDumpLoader<List<Person>>());

        // xml dump
        private void XmlxmlToolStripMenuItem1_Click(object sender, EventArgs e)
            => DumpCollection("Pick your xml file", XmlFilter, new XmlDumpLoader<List<Person>>());

        // json load
        private void JsonjsonToolStripMenuItem_Click(object sender, EventArgs e)
            => LoadCollection("Pick your json file", JsonFilter, new JsonDumpLoader<List<Person>>());

        // json dump
        private void JsonjsonToolStripMenuItem1_Click(object sender, EventArgs e)
            => DumpCollection("Pick your json file", JsonFilter, new JsonDumpLoader<List<Person>>());
    }
}
