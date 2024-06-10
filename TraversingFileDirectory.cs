namespace Delegates_Events
{
    /// <summary>
    /// Класс, обходящий каталог файлов
    /// и выдающий событие при нахождении каждого файла
    /// </summary>
    public class TraversingFileDirectory
    {
        public event EventHandler<FileArgs> FileFound;

        public void Search(string dir, string param)
        {
            foreach (var file in Directory.EnumerateFiles(dir, param))
            {
                var fileFound = ShowFoundFile(file);
                Console.WriteLine($"Файл {Path.GetFileName(file)} найден");

                if (fileFound.CancelingSearch)
                    break;
            }
        }

        private FileArgs ShowFoundFile(string file)
        {
            var fileArgs = new FileArgs(file);
            FileFound(this, fileArgs);
            return fileArgs;
        }
    }
}