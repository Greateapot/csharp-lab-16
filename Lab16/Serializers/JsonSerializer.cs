using Lab12Lib.BinaryTree;
using System.Text.Json;

namespace Lab16.Serializers
{
    internal class JsonSerializer<T> : ISerializer<T> where T : ICloneable, new()
    {
        public bool Dump(BinaryTree<T> tree, string path, string fileName) => Utils.WithFileInfo(
            path, fileName, fi =>
            {
                using var fs = fi.OpenWrite();
                JsonSerializer.Serialize(fs, tree);
                return true;
            }
        );

        public (bool result, BinaryTree<T>? tree) Load(string path, string fileName)
        {
            BinaryTree<T>? tree = null;
            bool result = Utils.WithFileInfo(
                path, fileName, fi =>
                {
                    using var fs = fi.OpenRead();
                    try
                    {
                        var result = JsonSerializer.Deserialize(fs, typeof(BinaryTree<T>));
                        if (result is null)
                            return false;
                        tree = result as BinaryTree<T>;
                        return true;
                    }
                    catch (JsonException)
                    {
                        return false;
                    }
                }
            );
            return (result, tree);
        }
    }
}
