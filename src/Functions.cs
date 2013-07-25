using System;
using System.Collections.Generic;

namespace NancyTest
{
    public class Functions
    {
        public Dictionary<string, int> NameToId = new Dictionary<string, int>();
        public Dictionary<int, Func<int, int, int>> IdToFunction = new Dictionary<int, Func<int, int, int>>();

        public Functions()
        {
            NameToId["add"] = 3;
            IdToFunction[3] = (x, y) => x + y;

            NameToId["mult"] = 4;
            IdToFunction[4] = (x, y) => x * y;

        }
    }
}