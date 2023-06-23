namespace Testing;

public static class Extensions
{
    private static Random random = new Random();
    public static void Add(this List<Bird> birds)
    {
        birds.Add(Bird.AddBird());
        File.WriteAllText("data.json",JsonConvert.SerializeObject(birds));
    }
    public static T RandomEnum<T>() where T : Enum
    {
        T[] values = (T[])Enum.GetValues(typeof(T));
        return values[random.Next(values.Length)];
    }
}