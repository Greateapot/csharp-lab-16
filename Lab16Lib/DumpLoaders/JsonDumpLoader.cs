using Newtonsoft.Json;

using Lab16Lib.Utils;

namespace Lab16Lib.DumpLoaders
{
    public class JsonDumpLoader<T> : IDumpLoader<T> where T : class
    {
        private static readonly JsonSerializer jsonSerializer = new()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public bool Dump(T obj, string path) => FileStreamWrapper.WithFileStream(
            path,
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

        public T? Load(string path) => FileStreamWrapper.WithFileStream(
            path,
            false,
            fs =>
            {
                using var sr = new StreamReader(fs);
                using var jtr = new JsonTextReader(sr);
                return jsonSerializer.Deserialize<T>(jtr);
            },
            _ => null
        );
    }
}