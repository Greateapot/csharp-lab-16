namespace Lab16Lib.Utils
{
    public static class FileStreamWrapper
    {
        public static T? WithFileStream<T>(
            string path,
            bool write,
            Func<FileStream, T> predicate,
            Func<Exception, T>? onError = null
        )
        {
            try
            {
                using var fs = write 
                    ? File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None)
                    : File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None);
                return predicate(fs);
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                if (onError != null)
                    return onError(e);
                else
                    return default;
            }
        }
    }
}