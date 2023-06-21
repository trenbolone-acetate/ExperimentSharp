namespace Testing;
[Serializable]
public class Place
{
    [JsonIgnore]
    public static readonly string[] Climates =
    {
        "Tropical",
        "Dry",
        "Temperate",
        "Continental",
        "Polar"
    };
    [JsonProperty("country")]
    private string Country { get; set; }
    [JsonProperty("city")]
    private string City { get; set; }
    [JsonProperty("climate")]
    private string Climate { get; set; }

    public Place(string country, string city, int chooseClimate)
    {
        Country = country;
        City = city;
        Climate = Climates[chooseClimate];
    }

    public void PrintInfo()
    {
        string text = $"\n\tCountry: {Country}\n\t City: {City}\n\t Climate: {Climate}";
        Console.WriteLine(text);
        File.AppendAllText(Program.LastSessionLog,"\n"+text+"\n");
    }
}