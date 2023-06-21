namespace Testing;
[Serializable]
public class Sighting
{
    private static readonly Random random = new();

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
        sighting.Place = new Place(
            faker.Address.Country(),
            faker.Address.City(), 
            random.Next(0, Place.Climates.Length));
        bird.SightingsList.Add(sighting);
    }

    private static DateTime RandDateTime()
    {
        int year = random.Next(1980, 2023);
        int month = random.Next(1, 13);
        int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
        int hour = random.Next(0, 24);
        int minute = random.Next(0, 60);
        int second = random.Next(0, 60);

        DateTime randomDateTime = new DateTime(year, month, day, hour, minute, second);
        return randomDateTime;
    }

    public void PrintInfo(Bird bird)
    {
        string text = string.Empty;
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