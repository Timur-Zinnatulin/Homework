using System;
using System.Collections.Generic;


namespace SortedSet
{
    public class ByListSize : IComparer<List<string>>
    {
        int IComparer<List<string>>.Compare(List<string> x, List<string> y)
        {
            if (x.Count >= y.Count)
            {
                if (List<string>.Equals(x, y))
                {
                    return 0;
                }

                return 1;
            }

            return -1;
        }
    }
}
