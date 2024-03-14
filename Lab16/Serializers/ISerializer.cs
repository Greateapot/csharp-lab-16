using Lab12Lib.BinaryTree;

namespace Lab16.Serializers
{
    internal interface ISerializer<T> where T : ICloneable, new()
    {
        public bool Dump(BinaryTree<T> tree, string path, string fileName);

        public (bool result, BinaryTree<T>? tree) Load(string path, string fileName);
    }
}
