namespace Data_Structures;

public static class Utils
{
    public static IEnumerable<T> Take<T>(IEnumerable<T> source, int amount)
    {
        int counter = 0;
        foreach (var item in source)
        {
            yield return item;
            if (++counter==amount)
            {
                yield break;
            }
        }
    }
}
