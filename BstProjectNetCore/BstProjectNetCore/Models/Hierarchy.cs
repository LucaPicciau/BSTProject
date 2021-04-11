using System.Collections.Generic;

namespace BstProjectNetCore.Models
{
    public class Hierarchy
    {
        public int TotalRoots { get; set; }
        public (int, int, string, char) Index { get; set; }
        public IList<(int, int, string, char)> SubIndex { get; set; }

        public Hierarchy() => SubIndex = new List<(int, int, string, char)>();
    }

}