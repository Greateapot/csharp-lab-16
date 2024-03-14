namespace Lab16Lib
{
    public static class Utils
    {
        public static T? WithFileStream<T>(
            string path,
            string filename,
            bool write,
            Func<FileStream, T> predicate,
            Func<Exception, T>? onError = null
        )
        {
            try
            {
                using var fs = new FileStream(
                    Path.Combine(path, filename),
                    FileMode.OpenOrCreate | (write ? FileMode.Truncate : 0),
                    write ? FileAccess.Write : FileAccess.Read
                );
                return predicate(fs);
            }
            catch (Exception e)
            {
                if (onError != null)
                    return onError(e);
                else
                    return default;
            }
        }
    }
}