using static Testing.Program;

namespace UnitTest;
[TestFixture]
public class Tests
{
    private const string DeserializationPath = @"C:\Users\User-PC\Desktop\sharpFun\Testing\Testing\TheBirdWatcher\bin\Debug\net6.0\data.json";
    private List<Bird>? birds;

    [SetUp]
    public void Setup()
    {
        birds = JsonConvert.DeserializeObject<List<Bird>>(File.ReadAllText(DeserializationPath));
    }
    private string[] GetLines(string output)
    {
        return output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }

    [Test]
    public void SearchForBird_NoMatchingSearch_NothingFound()
    {
        string input = "name\nScarlet Ibis";

        using StringReader stringReader = new StringReader(input);
        Console.SetIn(stringReader);
        using StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter); 

        Search.SearchForBird(birds);
        string output = stringWriter.ToString();
        string[] lines = GetLines(output);
        string lastLine = lines.LastOrDefault();
        Assert.That(lastLine, Is.EqualTo("Nothing found!"));
    }
    [Test]
    public void SearchForBird_NameAmericanRobin_AmericanRobinShortInfo()
    {
        string input = "name\nAmerican Robin";

        using StringReader stringReader = new StringReader(input);
        Console.SetIn(stringReader);
        using StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter); 

        Search.SearchForBird(birds);
        string output = stringWriter.ToString();
        string[] lines = GetLines(output);
        string finalOutput = lines.LastOrDefault();
        using StringWriter shortInfoStringWriter = new StringWriter();
        Console.SetOut(shortInfoStringWriter);
        birds[0].PrintShortInfo();
        string expectedString = shortInfoStringWriter.ToString().Trim() + '\n';
        Assert.That(finalOutput, Is.EqualTo(expectedString));
    }
    [Test]
    public void CommandHandler_CommandHelp_OutputsListOfCommands()
    {
        string input = "-help\n-quit";

        using StringReader stringReader = new StringReader(input);
        Console.SetIn(stringReader);
        using StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter); 

        CommandHandler.HandleCommand();
        string output = stringWriter.ToString();
        string[] lines = GetLines(output);
        string[] finalOutput = lines.Where(line => line.StartsWith('\t')).ToArray();
        for (var index = 0; index < finalOutput.Length; index++) {
            finalOutput[index] = finalOutput[index].Trim('\t');
        }

        using StringWriter finalOutputStringWriter = new StringWriter();
        Console.SetOut(finalOutputStringWriter);
        foreach (var outputItem in finalOutput)
        {
            Console.WriteLine(outputItem);
        }
        string result = finalOutputStringWriter.ToString().Trim();
        
        using StringWriter shortInfoStringWriter = new StringWriter();
        Console.SetOut(shortInfoStringWriter);
        foreach (var command in Collections.commands)
        {
            Console.WriteLine(command);
        }
        string expectedString = shortInfoStringWriter.ToString().Trim();
        Assert.That(result, Is.EqualTo(expectedString));
    }
    [Test]
    public void Deserialization_BirdNameType_MatchesExpectedType()
    {
        var testDeserializtionBirds = JsonConvert.DeserializeObject<List<Bird>>(File.ReadAllText(DeserializationPath));
        Type type = testDeserializtionBirds[0].Name.GetType();
        string nameString = "example";
        Assert.That(type, Is.EqualTo(nameString.GetType()));
    }
    [Test]
    public void PrintShortInfo_OutputsCorrectString()
    {
        Bird bird = birds[0];
        string expectedOutput = "Tiny brown/white American Robin from Turdidae family. " +
                                "\nIt's 10cm in length, its wingspan is 16cm and its weight is 2,7kg";
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        bird.PrintShortInfo();
        string output = sw.ToString().Trim();
        Assert.That(output, Is.EqualTo(expectedOutput));
    }
    [Test]
    public void Constructor_AllParameters_SetAllProperties()
    {
        string name = "Eagle";
        string family = "Accipitridae";
        string primaryColor = "Brown";
        string secondaryColor = "White";
        double length = 70;
        double wingspan = 200;
        double weight = 4.5;
        string conservationStatus = "Least Concern";
        string conservationCode = "LC";

        Bird bird = new Bird(name, family, primaryColor, secondaryColor, length, wingspan, weight, conservationStatus,
            conservationCode);

        Assert.That(bird.Name, Is.EqualTo(name));
        Assert.That(bird.Family, Is.EqualTo(family));
        Assert.That(bird.PrimaryColor, Is.EqualTo(primaryColor));
        Assert.That(bird.SecondaryColor, Is.EqualTo(secondaryColor));
        Assert.AreEqual(bird.Length, length);
        Assert.AreEqual(bird.Wingspan, wingspan);
        Assert.AreEqual(bird.Weight, weight);
        Assert.That(bird.ConservationStatus, Is.EqualTo(conservationStatus));
        Assert.That(bird.ConservationCode, Is.EqualTo(conservationCode));
    }
}