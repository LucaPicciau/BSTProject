using BstProject.Models;

namespace BstProject.Extensions
{
    public static class NodeExtensions
    {
        public static IgorNode GetNodeFromChar(this IgorNode a, IgorNode b)
        {
            switch(a.TypeChar)
            {
                case 'Y': return b.YesNode;
                case 'N': return b.NoNode;
            }

            return null;
        }
    }
}