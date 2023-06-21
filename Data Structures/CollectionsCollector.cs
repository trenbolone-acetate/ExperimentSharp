using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures;

static class CollectionsCollector
{
    public static CollectionsCollector<T> Create<T>(params IEnumerable<T>[] collections)
    {
        return new CollectionsCollector<T>(collections);
    }
} 
class CollectionsCollector<T> : IEnumerable<T>
{
    private List<IEnumerable<T>> _collections;

    public CollectionsCollector(IEnumerable<IEnumerable<T>> collections)
    {
        _collections = collections.ToList();
    }
    public CollectionsCollector()
    {
        _collections = new List<IEnumerable<T>>();
    }
    public void Add(IEnumerable<T> collection)
    {
        _collections.Add(collection);
    }
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var collection in _collections)
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}