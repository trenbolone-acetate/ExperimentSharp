using Data_Structures;
using static Data_Structures.CollectionsCollector;
class Program
{
    static void Main()
    {
        var list1 = new List<int>() { 1, 2, 9, 3};
        var list2 = new List<int>() { 5, 1, 4, 7};
        var set1 = new HashSet<int>() { 15, 22, 95, 31};
        var array1 = new[]{ 4,12,16,32,64};
        int numOdd = 0;
        
        var collectionOfCollections = new CollectionsCollector<int>{list1,list2,set1,array1};
        foreach (var i in collectionOfCollections)
        {
            if (IsOdd(i))
            {
                numOdd++;
            }
        }
        Console.WriteLine($"numOdd:{numOdd}");
        Console.WriteLine();

        //var collectionsThroughArray = CollectionsCollector.Create(new IEnumerable<int>[]{list1,set1,array1});
        //var collectionsThroughArray = CollectionsCollector.Create(list1, set1, array1);
        var collectionsThroughArray = Create(list1, set1, array1);
        foreach (var item in collectionsThroughArray)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();    

        IEnumerable<int> firstSix = Utils.Take(collectionOfCollections,6);
        foreach (var item in firstSix)
        {
            Console.WriteLine(item);
        }
    }
    public static bool IsOdd(int num)
    {
        return (num % 2) != 0;
    }
}