namespace Lab16
{
    internal static class Utils
    {
        public static bool WithFileInfo(
            string path,
            string fileName,
            Predicate<FileInfo> callback
        )
        {
            try
            {
                return callback(new FileInfo(Path.Combine(path, fileName)));
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
    }
}
