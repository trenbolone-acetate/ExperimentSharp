namespace Testing;

public static class Search
{
    public static void SearchForBird(List<Bird> birds)
        {
            while (true)
            {
                Console.WriteLine("By what parameter would you like to search?" +
                              "\n-Name\n-Family\n-Primary color\n-Secondary color\n-Length\n-" +
                              "Wingspan\n-Weight\n-Conservation status\n-Conservation code?" +
                              "\nType here: ");
                var parameter = Console.ReadLine()?.ToLower();

                Console.WriteLine("Input parameter value: ");
                var parameterValue = Console.ReadLine()?.ToLower();

                IEnumerable<Bird> foundBirds;
                switch (parameter)
                {
                    case "name":
                        foundBirds = birds.FindAll(bird => string.Equals(bird.Name, parameterValue, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "family":
                        foundBirds = birds.FindAll(bird => string.Equals(bird.Family, parameterValue, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "primary color":
                        foundBirds = birds.FindAll(bird => string.Equals(bird.PrimaryColor, parameterValue, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "secondary color":
                        foundBirds = birds.FindAll(bird => string.Equals(bird.SecondaryColor, parameterValue, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "length":
                        foundBirds = birds.FindAll(bird => Math.Abs(bird.Length - Convert.ToDouble(parameterValue)) < Double.Epsilon);
                        break;
                    case "wingspan":
                        foundBirds = birds.FindAll(bird => Math.Abs(bird.Wingspan - Convert.ToDouble(parameterValue)) < Double.Epsilon);
                        break;
                    case "weight":
                        foundBirds = birds.FindAll(bird => Math.Abs(bird.Weight - Convert.ToDouble(parameterValue)) < Double.Epsilon);
                        break;
                    case "conservation status":
                        foundBirds = birds.FindAll(bird => string.Equals(bird.ConservationStatus, parameterValue, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "conservation code":
                        foundBirds = birds.FindAll(bird => string.Equals(bird.ConservationCode, parameterValue, StringComparison.OrdinalIgnoreCase));
                        break;
                    default:
                        Console.WriteLine("Wrong parameter! Maybe you misspelled it!\nTry again!");
                        continue;
                }
                if (foundBirds.Any()) { DisplayResult(foundBirds); }
                else { DisplayNoResult();}
                break;
            }
        }

    private static void DisplayNoResult()
    {
        Console.WriteLine("Nothing found!");
    }

    private static void DisplayResult(IEnumerable<Bird> foundBirds)
    {
        Console.WriteLine("\nYou were searching for: ");
        foreach (var foundBird in foundBirds)
        {
            foundBird.PrintShortInfo();
        }
    }

}