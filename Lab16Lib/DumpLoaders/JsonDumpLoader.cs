using Newtonsoft.Json;

using Lab16Lib.BinaryTree;
using Lab16Lib.Entities;

namespace Lab16Lib.DumpLoaders
{
    public class JsonDumpLoader : IDumpLoader<BinaryTree<Person>>
    {
        private static readonly JsonSerializer jsonSerializer = new()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public bool Dump(BinaryTree<Person> obj, string path, string filename) => Utils.WithFileStream(
            path,
            filename,
            true,
            fs =>
            {
                using var sw = new StreamWriter(fs);
                using var jtw = new JsonTextWriter(sw);
                jsonSerializer.Serialize(jtw, obj);
                return true;
            },
            _ => false
        );

        public BinaryTree<Person>? Load(string path, string filename) => Utils.WithFileStream(
            path,
            filename,
            false,
            fs =>
            {
                using var sr = new StreamReader(fs);
                using var jtr = new JsonTextReader(sr);
                return jsonSerializer.Deserialize<BinaryTree<Person>>(jtr);
            },
            _ => null
        );
    }
}