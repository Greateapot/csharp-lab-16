namespace Lab16Lib.DumpLoaders
{
    public interface IDumpLoader<T>
    {
        public bool Dump(T obj, string path);
        public T? Load(string path);
    }
}