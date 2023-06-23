namespace Testing;
[Serializable]
public class Sighting
{
    [JsonProperty("sighting_date")]
    private DateTime SightingDate { get; set; }
    [JsonProperty("observer_firstname")]
    private string ObserverFirstName { get; set; }
    [JsonProperty("observer_lastname")]
    private string ObserverLastName { get; set; }
    [JsonProperty("place")]
    private Place Place { get; set; }

    public static void AddRandom(Bird bird)
    {
        Sighting sighting = new Sighting
        {
            SightingDate = RandDateTime()
        };
    
        Faker faker = new Faker();
        sighting.ObserverFirstName = faker.Name.FirstName();
        sighting.ObserverLastName = faker.Name.LastName();
    
        Place place = GenerateRandomPlace();
        sighting.Place = place;
    
        bird.SightingsList.Add(sighting);
    }

    private static Place GenerateRandomPlace()
    {
        Faker faker = new Faker();
        string country = faker.Address.Country();
        string city = faker.Address.City();
        string climate =  $"{Collections.climates.RandomItem()}";
        return new Place(country, city, climate);
    }

    private static DateTime RandDateTime()
    {
        DateTime randomDateTime = ExtensionsAndUtils.RandomDate();
        return randomDateTime;
    }

    public void PrintInfo(Bird bird)
    {
        string text;
        using (StringWriter stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            Place.PrintInfo();
            text = $" Name: {bird.Name}\n When was observed: " +
                          $"{SightingDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)}\n " +
                          $"Who observed? {ObserverFirstName} {ObserverLastName}\n Where? {stringWriter}";
        }
        Console.Write(text);
        File.AppendAllText(Program.LastSessionLog,"\n"+text);
    }
}