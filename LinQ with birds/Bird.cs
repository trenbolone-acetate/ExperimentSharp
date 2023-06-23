namespace Testing;
[Serializable]
public class Bird
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("family")]
    public string Family { get; set; }
    [JsonProperty("primary_color")]
    public string PrimaryColor { get; set; }
    [JsonProperty("secondary_color")]
    public string SecondaryColor { get; set; }
    [JsonProperty("length")]
    public double Length { get; set; }
    [JsonProperty("wingspan")]
    public double Wingspan { get; set; }
    [JsonProperty("weight")]
    public double Weight { get; set; }

    private string Size
    {
        get
        {
            if (Length < 15) return "Tiny";
            if (Length < 30) return "Small";
            if (Length < 50) return "Medium";
            return "Large";
        }
    }

    public List<Sighting> SightingsList { get; } = new();
    [JsonProperty("conservation_status")]
    public string ConservationStatus{ get; set; }
    [JsonProperty("conservation_code")]
    public string ConservationCode { get; set; }

    public Bird(){}

    public Bird(string name, string family, string primaryColor, string secondaryColor, double length, 
        double wingspan, double weight, string conservationStatus, string conservationCode)
    {
        Name = name;
        Family = family;
        PrimaryColor = primaryColor;
        SecondaryColor = secondaryColor;
        Length = length;
        Wingspan = wingspan;
        Weight = weight;
        ConservationStatus = conservationStatus;
        ConservationCode = conservationCode;
        SightingsList.Clear();
        Sighting.AddRandom(this);
    }
    public static Bird AddBird()
    {
        Bird bird = new Bird();

        bird.Name = ReadString("Enter the bird's name: ");
        bird.Family = ReadString("Enter the bird's family: ");
        bird.PrimaryColor = ReadString("Enter the bird's primary color: ");
        bird.SecondaryColor = ReadString("Enter the bird's secondary color: ");
        bird.Length = ReadDouble("Enter the bird's length (in cm): ");
        bird.Wingspan = ReadDouble("Enter the bird's wingspan (in cm): ");
        bird.Weight = ReadDouble("Enter the bird's weight (in kg): ");
        bird.ConservationStatus = ReadString("Enter the bird's conservation status: ");
        bird.ConservationCode = ReadString("Enter the bird's conservation code: ");

        bird.SightingsList.Clear();
        Sighting.AddRandom(bird);

        return bird;
    }
    public void PrintShortInfo()
    {
        string text = $"{Size} {PrimaryColor.ToLower()}/{SecondaryColor.ToLower()} {Name} from {Family} family. " +
                      $"\nIt's {Length}cm in length, its wingspan is {Wingspan}cm and its weight is {Weight}kg\n";
        Console.WriteLine(text);
        Logger.Log(text);    
    }
    public void PrintInfo()
    {
        string divider = "==================================";
        string text = $"\n{divider}\nBirds name: {Name}\nFamily: {Family}\n Primary color: {PrimaryColor}\n Secondary color: {SecondaryColor}\n " +
                      $"Length: {Length}\n Wingspan: {Wingspan}\n Weight: {Weight}\n Comparative size: {Size}\nConservation status: {ConservationStatus}" +
                      $"\nConservation code: {ConservationCode}\n";
        Console.WriteLine(text);
        Logger.Log(text);
        SeeSightings();
    }

    private void SeeSightings()
{
    Console.WriteLine($"\nWant to see complete list of sightings of {Name}?\n\tY or N");

    char seeSightings;
    while (true)
    {
        seeSightings = Console.ReadKey().KeyChar;
        seeSightings = char.ToLower(seeSightings);

        if (seeSightings == 'y' || seeSightings == 'n')
            break;

        Console.WriteLine("You should've typed Y or N! Try again\n");
    }

    if (seeSightings == 'y')
    {
        foreach (var sighting in SightingsList)
        {
            sighting.PrintInfo(this);
        }
    }
    else
    {
        Console.WriteLine("Okay!");
    }
}
    
    private static string ReadString(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    private static double ReadDouble(string message)
    {
        double value;
        bool isValid;

        do
        {
            Console.Write(message);
            isValid = double.TryParse(Console.ReadLine(), out value);

            if (!isValid)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }

        } while (!isValid);

        return value;
    }
}