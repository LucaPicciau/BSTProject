using BstProject.Graphics;

namespace BstProject.Models
{
    public class IgorNode
    {
        public int ParentKey { get; set; }
        public int Key { get; set; }
        public string Question { get; set; }
        public IgorNode YesNode { get; set; }
        public IgorNode NoNode { get; set; }
        public char TypeChar { get; set; }
        public Vector2i Position { get; set; }

        public bool IsLeaf => YesNode == null && NoNode == null;

        public IgorNode()
        {
            Position = new Vector2i();
        }

        public IgorNode Find(int key)
        {
            if (Key == key)
                return this;

            return YesNode?.Find(key) ?? NoNode?.Find(key);
        }

        public void Insert(IgorNode node)
        {
            var nodeFinded = Find(node.ParentKey);

            if (nodeFinded == null)
                return;

            switch (node.TypeChar)
            {
                case 'Y': nodeFinded.YesNode = node; break;
                case 'N': nodeFinded.NoNode = node; break;
            }
        }
    }
}