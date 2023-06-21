using System.Collections.Generic;
using Common.Collections.Generic;

class Program
{
    static void Main()
    {
        var insults = new List<string>()
        {
            "moron",
            "idiot",
            "cunt",
            "fucker",
            "dickhead",
            "loser",
            "bastard"
        };
        Console.WriteLine($"I'm {insults.RandomItem()}!");
        Console.WriteLine($"I'm {IListExtensions.RandomItem(insults)}!");
    }

}