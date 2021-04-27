using GraphicsLibrary.Graphics;

namespace BstProjectNetCore.Models
{
    public class IgorNode
    {
        public int ParentKey { get; set; }
        public int Key { get; set; }
        public string Question { get; set; }
        public IgorNode YesNode { get; set; }
        public IgorNode NoNode { get; set; }
        public char TypeChar { get; set; }
        public (int, int) Position { get; set; }
        public RectangleShape LeftSeparator { get; set; }
        public RectangleShape RightSeparator { get; set; }
        public RectangleShape Shape { get; set; }


        public bool IsLeaf => YesNode == null && NoNode == null;
        public IgorNode Find(int key) => (Key == key) ? this : YesNode?.Find(key) ?? NoNode?.Find(key);


        public void Insert(IgorNode node)
        {
            var nodeFinded = Find(node.ParentKey);

            if (nodeFinded == null)
                return;

            node.Shape ??= new RectangleShape() { Position = node.Position, Texture = node.Key.ToString() };

            switch (node.TypeChar)
            {
                case 'Y':
                    nodeFinded.YesNode = node;
                    nodeFinded.LeftSeparator = new RectangleShape() { Position = (node.Position.Item1 - 1, node.Position.Item2 + 1), Texture = "/" };
                    break;

                case 'N':
                    nodeFinded.NoNode = node;
                    nodeFinded.RightSeparator = new RectangleShape() { Position = (node.Position.Item1 + node.Key.ToString().Length, node.Position.Item2 + 1), Texture = "\\" };
                    break;
            }
        }

        public void Update(IgorNode node, (int, int) parentPosition, int length)
        {
            var space = (length > node.Key.ToString().Length ? node.Key.ToString().Length : length) + 1;
            node.Position = (parentPosition.Item1 + (node.TypeChar == 'Y' ? -space : space), parentPosition.Item2 + 2);
            Shape.Position = node.Position;

            if(LeftSeparator != null)
                LeftSeparator.Position = (node.Position.Item1 - 1, node.Position.Item2 + 1);

            if (RightSeparator != null)
                RightSeparator.Position = (node.Position.Item1 + Shape.Texture.Length, node.Position.Item2 + 1);
        }

        public void Render(Window window)
        {
            window.Update(Shape);
            window.Update(LeftSeparator);
            window.Update(RightSeparator);
        }
    }
}