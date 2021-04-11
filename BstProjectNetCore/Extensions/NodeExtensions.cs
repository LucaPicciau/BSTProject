using BstProject.Models;

namespace BstProject.Extensions
{
    public static class NodeExtensions
    {
        public static IgorNode GetNodeFromChar(this IgorNode a, IgorNode b) =>
            a.TypeChar switch
            {
                'Y': => b.YesNode;
                case 'N': return b.NoNode;
                _
            }

        }
    }
}