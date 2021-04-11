using BstProjectNetCore.Extensions;

namespace BstProjectNetCore.Models
{
    public class IgorBstTree
    {
        public IgorNode Root { get; set; }

        public void Insert(IgorNode newNode) => Root.Insert(newNode);
        public IgorNode FindByKey(int key) => Root.Find(key);

        public void Rotate(IgorNode node)
        {
            var nodeFinded = Root.Find(node.ParentKey);

            if (nodeFinded == null)return;

            var oldNode = node.GetNodeFromChar(nodeFinded);
            nodeFinded.Insert(node);

            if (oldNode != null)
            {
                oldNode.ParentKey = node.Key;
                node.Insert(oldNode);
            }
        }
    }

}