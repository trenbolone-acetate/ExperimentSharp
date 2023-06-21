namespace Common.Collections.Generic
{
    public static class IListExtensions
    {
        private static readonly Random _random = new Random();

        public static T RandomItem<T>(this IList<T> list)
        {
            return list[_random.Next(0, list.Count)];
        }
    } 
}
