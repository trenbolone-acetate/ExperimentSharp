namespace Testing;

public static class ExtensionsAndUtils
{
    private static Random random = new Random();
    public static void Add(this List<Bird>? birds)
    {
        birds.Add(Bird.AddBird());
        File.WriteAllText("data.json",JsonConvert.SerializeObject(birds,Formatting.Indented));
    }
    public static T RandomItem<T>(this List<T> items)
    {
        return items[random.Next(items.Count)];
    }
    private static DateTime start = new(1980, 1, 1);
    private static int range = (DateTime.Today - start).Days; 
    private static int randomDay = random.Next(range);
    public static DateTime RandomDate()
    {
        TimeSpan randomTime = new TimeSpan(0, 0, random.Next(1440));
        return start.AddDays(randomDay).Date + randomTime;
    }
}