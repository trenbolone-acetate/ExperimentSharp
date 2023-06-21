namespace Testing;

public class Program
{
    public const string LastSessionLog = "log.txt";
    public static readonly List<Bird> Birds = JsonConvert.DeserializeObject<List<Bird>>(File.ReadAllText("data.json"));

    static void Main()
    {
        Console.Title = "The Bird Watcher";
        CommandHandler.HandleCommand();    
    }
}