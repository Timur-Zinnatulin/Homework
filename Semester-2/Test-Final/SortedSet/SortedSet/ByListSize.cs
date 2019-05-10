using System;
using System.Collections.Generic;


namespace SortedSet
{
    public class ByListSize : IComparer<List<string>>
    {
        int IComparer<List<string>>.Compare(List<string> x, List<string> y)
        {
            return (new Comparer<int>()).Compare(x.Count, y.Count);
        }
    }
}
