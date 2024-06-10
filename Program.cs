using Delegates_Events;

MaxElement.Run();

Console.WriteLine("Задача 'Вывести в консоль сообщения, возникающие при срабатывании событий.'");
Console.WriteLine("Отмена дальнейшего поиска, если найден файл с расширением '.py'\n\r");

TraversingFileDirectory traversingFileDirectory = new();
int t = 0;
List<string> filesnames = [];

EventHandler<FileArgs> handler = (search, fileArgs) =>
{
    filesnames.Add(fileArgs.SearchFile);
    fileArgs.CancelingSearch = false;

    if (fileArgs.SearchFile.Contains(".py"))
        fileArgs.CancelingSearch = true;
    t++;
};

traversingFileDirectory.FileFound += handler;

traversingFileDirectory.Search(@"D:\OTUS\Делегаты и события", "*");
traversingFileDirectory.FileFound -= handler;


Console.WriteLine($"\n\rНайдено файлов: {t}");
Console.WriteLine($"Отмена обработчика на {Path.GetFileName(filesnames[t-1])}");