namespace Testing;
public class Collections
{
    public enum Climate
    {
        Tropical,
        Dry,
        Temperate,
        Continental,
        Polar
    }
    public static readonly List<string> commands = new()
    {
        "-help",
        "-search",
        "-add bird",
        "-quit"
    };
}
