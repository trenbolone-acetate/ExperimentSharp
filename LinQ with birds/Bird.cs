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

        Console.Write("Enter the bird's name: ");
        bird.Name = Console.ReadLine();

        Console.Write("Enter the bird's family: ");
        bird.Family = Console.ReadLine();

        Console.Write("Enter the bird's primary color: ");
        bird.PrimaryColor = Console.ReadLine();

        Console.Write("Enter the bird's secondary color: ");
        bird.SecondaryColor = Console.ReadLine();

        Console.Write("Enter the bird's length (in cm): ");
        double length;
        while (!double.TryParse(Console.ReadLine(), out length))
        {
            Console.WriteLine("Invalid input! Please enter a valid number for length.");
            Console.Write("Enter the bird's length (in cm): ");
        }
        bird.Length = length;

        Console.Write("Enter the bird's wingspan (in cm): ");
        double wingspan;
        while (!double.TryParse(Console.ReadLine(), out wingspan))
        {
            Console.WriteLine("Invalid input! Please enter a valid number for wingspan.");
            Console.Write("Enter the bird's wingspan (in cm): ");
        }
        bird.Wingspan = wingspan;

        Console.Write("Enter the bird's weight (in kg): ");
        double weight;
        while (!double.TryParse(Console.ReadLine(), out weight))
        {
            Console.WriteLine("Invalid input! Please enter a valid number for weight.");
            Console.Write("Enter the bird's weight (in kg): ");
        }
        bird.Weight = weight;

        Console.Write("Enter the bird's conservation status: ");
        bird.ConservationStatus = Console.ReadLine();

        Console.Write("Enter the bird's conservation code: ");
        bird.ConservationCode = Console.ReadLine();

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
        Console.WriteLine("\nWant to see complete list of sightings of {0}?\n\tY or N",Name);
        char seeSightings = Console.ReadLine()!.ToCharArray().FirstOrDefault();
        switch (seeSightings)
        {
            case 'Y':
            case 'y':
            {
                foreach (var sighting in SightingsList)
                {
                    sighting.PrintInfo(this);
                }
                return;
            }
            case 'N':
            case 'n':
                Console.WriteLine("Okay!");
                break;
            default:
                Console.WriteLine("You should've typed Y or N! Try again\n");
                SeeSightings();
                break;
        }
    }
}