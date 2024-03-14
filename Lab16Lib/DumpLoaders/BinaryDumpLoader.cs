using System.Runtime.Serialization.Formatters.Binary;

using Lab16Lib.BinaryTree;
using Lab16Lib.Entities;

namespace Lab16Lib.DumpLoaders
{
    public class BinaryDumpLoader : IDumpLoader<BinaryTree<Person>>
    {
#pragma warning disable SYSLIB0011 // Тип или член устарел
        private static readonly BinaryFormatter binaryFormatter = new();
#pragma warning restore SYSLIB0011 // Тип или член устарел

        public bool Dump(BinaryTree<Person> obj, string path, string filename) => Utils.WithFileStream(
            path,
            filename,
            true,
            fs =>
            {
                binaryFormatter.Serialize(fs, obj);
                return true;
            },
            _ => false
        );

        public BinaryTree<Person>? Load(string path, string filename) => Utils.WithFileStream(
            path,
            filename,
            false,
            fs => binaryFormatter.Deserialize(fs) as BinaryTree<Person>,
            _ => null
        );
    }
}