namespace Testing;
[Serializable]
public class Place
{
    [JsonProperty("country")]
    private string Country { get; set; }
    [JsonProperty("city")]
    private string City { get; set; }
    [JsonProperty("climate")]
    private string Climate { get; set; }

    public Place(string country, string city, string chosenClimate)
    {
        Country = country;
        City = city;
        Climate = chosenClimate;
    }

    public void PrintInfo()
    {
        string text = $"\n\tCountry: {Country}\n\t City: {City}\n\t Climate: {Climate}";
        Console.WriteLine(text);
        File.AppendAllText(Program.LastSessionLog,"\n"+text+"\n");
    }
}