using BstProjectNetCore.Models;
using GraphicsLibrary.Graphics;
using System;

namespace BstProjectNetCore
{
    public class Engine
    {
        public Window Window { get; private set; }
        public IgorBstTree BstTree { get; private set; }
        public int TreeLength { get; private set; }

        public Engine((int, int) sizeWindow) => (Window, BstTree) = (new Window(sizeWindow), new IgorBstTree());

        public void SetBSTTree(Hierarchy hierarchy)
        {
            TreeLength = hierarchy.TotalRoots;

            BstTree.Root = new IgorNode
            {
                Key = hierarchy.Index.Item1,
                ParentKey = hierarchy.Index.Item2,
                Question = hierarchy.Index.Item3,
                TypeChar = hierarchy.Index.Item4,
                Position = (30, 0),
                Shape = new RectangleShape() { Position = (30, 0), Texture = hierarchy.Index.Item1.ToString() }
            };

            foreach (var data in hierarchy.SubIndex)
            {
                BstTree.Insert(new IgorNode
                {
                    Key = data.Item1,
                    ParentKey = data.Item2,
                    Question = data.Item3,
                    TypeChar = data.Item4,
                    Position = BstTree.Root.Position
                });
            }
        }

        public void Run()
        {
            UpdateData(BstTree.Root);

            Window.Draw();


            Console.WriteLine("\nPremere un tasto per continuare");
            Console.ReadLine();
        }

        public void UpdateData(IgorNode node)
        {
            node.Render(Window);

            if (node.YesNode != null)
            {
                node.YesNode.Update(node.YesNode, node.Position, node.Key.ToString().Length);
                UpdateData(node.YesNode);
            }

            if (node.NoNode != null)
            {
                node.NoNode.Update(node.NoNode, node.Position, node.Key.ToString().Length);
                UpdateData(node.NoNode);
            }
        }
    }
}
