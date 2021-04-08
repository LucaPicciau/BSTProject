using System;
using System.Collections.Generic;

namespace BstProject.Models
{
    public class Hierarchy
    {
        public int TotalRoots { get; set; }
        public Tuple<int, int, string, char> Index { get; set; }
        public IList<(int, int, string, char)> SubIndex { get; set; }

        public Hierarchy()
        {
            SubIndex = new List<(int, int, string, char)>();
        }
    }

}