using System.Xml.Serialization;

using Lab16Lib.BinaryTree;
using Lab16Lib.Entities;

namespace Lab16Lib.DumpLoaders
{
    public class XmlDumpLoader : IDumpLoader<BinaryTree<Person>>
    {
        private static readonly XmlSerializer xmlSerializer = new(
            typeof(BinaryTree<Person>),
            [
                typeof(Person),
                typeof(Pupil),
                typeof(Student),
                typeof(PartTimeStudent),
            ]
        );

        public bool Dump(BinaryTree<Person> obj, string path, string filename) => Utils.WithFileStream(
            path,
            filename,
            true,
            fs =>
            {
                xmlSerializer.Serialize(fs, obj);
                return true;
            },
            _ => false
        );

        public BinaryTree<Person>? Load(string path, string filename) => Utils.WithFileStream(
            path,
            filename,
            false,
            fs => xmlSerializer.Deserialize(fs) as BinaryTree<Person>,
            _ => null
        );
    }
}