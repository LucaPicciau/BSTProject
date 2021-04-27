using BstProjectNetCore.Models;

namespace BstProjectNetCore.Extensions
{
    public static class NodeExtensions
    {
        public static IgorNode GetNodeFromChar(this IgorNode a, IgorNode b) => a.TypeChar switch
        {
            'Y' => b.YesNode,
            'N' => b.NoNode,
             _  => null,
        };
    }
}