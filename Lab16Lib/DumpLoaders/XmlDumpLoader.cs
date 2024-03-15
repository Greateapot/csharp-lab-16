using System.Xml.Serialization;

using Lab16Lib.Entities;
using Lab16Lib.Utils;

namespace Lab16Lib.DumpLoaders
{
    public class XmlDumpLoader<T> : IDumpLoader<T> where T : class
    {
        private static readonly XmlSerializer xmlSerializer = new(
            typeof(T),
            [
                typeof(Person),
                typeof(Pupil),
                typeof(Student),
                typeof(PartTimeStudent),
            ]
        );

        public bool Dump(T obj, string path) => FileStreamWrapper.WithFileStream(
            path,
            true,
            fs =>
            {
                xmlSerializer.Serialize(fs, obj);
                return true;
            },
            _ => false
        );

        public T? Load(string path) => FileStreamWrapper.WithFileStream(
            path,
            false,
            fs => xmlSerializer.Deserialize(fs) as T,
            _ => null
        );
    }
}