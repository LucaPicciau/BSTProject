using BstProject.Graphics;
using BstProject.Models;
using System;

namespace BstProject
{
    public class Engine
    {
        public Window Window { get; private set; }
        public IgorBstTree BstTree { get; private set; }
        public int TreeLength { get; private set; }

        public Engine((int, int) sizeWindow)
        {
            Window = new Window(sizeWindow);
            BstTree = new IgorBstTree();
        }

        public void SetBSTTree(Hierarchy hierarchy)
        {
            TreeLength = hierarchy.TotalRoots;

            BstTree.Root = new IgorNode
            {
                Key = hierarchy.Index.Item1,
                ParentKey = hierarchy.Index.Item2,
                Question = hierarchy.Index.Item3,
                TypeChar = hierarchy.Index.Item4,
                Position = (30, 0)
            };

            foreach (var data in hierarchy.SubIndex)
            {
                BstTree.Insert(new IgorNode
                {
                    Key = data.Item1,
                    ParentKey = data.Item2,
                    Question = data.Item3,
                    TypeChar = data.Item4,
                    Position = (BstTree.Root.Position.Item1, BstTree.Root.Position.Item2)
                });
            }
        }


        public void Run()
        {
            //Game();

            for (int i = 0; i < TreeLength; i++)
                PrintData(BstTree.Root);

            Window.Render();
            Window.Clear();

            Console.WriteLine("\nPremere un tasto per continuare");
            Console.ReadLine();
            Console.SetCursorPosition(0, 0);
        }


        public void PrintData(IgorNode node)
        {
            Window.Update(node, 1, node.YesNode != null ? "/" : "", node.NoNode != null ? "\\" : "");

            if (node.YesNode != null)
            {
                UpdatePosition(node.YesNode, node.Position);
                PrintData(node.YesNode);
            }

            if (node.NoNode != null)
            {
                UpdatePosition(node.NoNode, node.Position);
                PrintData(node.NoNode);
            }
        }

        private void UpdatePosition(IgorNode node, (int, int) position)
        {
            var space = node.Key.ToString().Length + 1;
            node.Position = (position.Item1 + ( node.TypeChar == 'Y' ? -space : space), position.Item2 + 2);
        }

        private void Game()
        {
            /*
            var index = 100;

            while (true)
            {
                Console.Clear();

                ConsoleKey key = ConsoleKey.NoName;


                var node = BstTree.FindByKey(index);
                Window.Update(node);
                Window.Render();
                Console.Write("Left: {0}, Right: {1}", (node.YesNode == null ? "null" : node.YesNode.Key.ToString()), (node.NoNode == null ? "null" : node.NoNode.Key.ToString()));
                Console.WriteLine();
                
                while (true)
                {
                    var select = Console.ReadKey();

                    if (select.Key == ConsoleKey.Y)
                        key = ConsoleKey.Y;
                    else if (select.Key == ConsoleKey.N)
                        key = ConsoleKey.N;

                    if (key != ConsoleKey.NoName)
                        break;
                }
                
                switch (key)
                {
                    case ConsoleKey.Y: index = node.YesNode.Key; break;

                    case ConsoleKey.N: index = node.NoNode.Key; break;
                }
                
                Window.Update(node, 0, node.YesNode != null && key == ConsoleKey.Y ? "/" : "", node.NoNode != null && key == ConsoleKey.N ? "\\" : "");
            }
            */
        }
    }
}