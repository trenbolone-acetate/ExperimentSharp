namespace Testing;

public static class ListExtensions
{
    public static void AddItem(this List<Bird> birds)
    {
        birds.Add(Bird.AddBird());
        File.WriteAllText("data.json",JsonConvert.SerializeObject(birds));
    }
}