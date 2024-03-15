using System.Runtime.Serialization.Formatters.Binary;

using Lab16Lib.Utils;

namespace Lab16Lib.DumpLoaders
{
    public class BinaryDumpLoader<T> : IDumpLoader<T> where T : class
    {
#pragma warning disable SYSLIB0011 // Тип или член устарел
        private static readonly BinaryFormatter binaryFormatter = new();
#pragma warning restore SYSLIB0011 // Тип или член устарел

        public bool Dump(T obj, string path) => FileStreamWrapper.WithFileStream(
            path,
            true,
            fs =>
            {
                binaryFormatter.Serialize(fs, obj);
                return true;
            },
            _ => false
        );

        public T? Load(string path) => FileStreamWrapper.WithFileStream(
            path,
            false,
            fs => binaryFormatter.Deserialize(fs) as T,
            _ => null
        );
    }
}