using BstProjectNetCore.Models;
using System;
using System.Linq;
using System.Threading;

namespace BstProjectNetCore.Graphics
{
    public class Window
    {
        public (int, int) Size { get; set; }
        private Grid Grid { get; }

        public Window((int, int) size)
        {
            Console.SetWindowSize(size.Item1 + 20, size.Item2 + 20);
            Console.CursorVisible = false;

            Grid = new Grid(size);
            Size = Grid.Size;
        }

        public void Update(IgorNode node, int dataPrint = 0, params string[] separator)
        {
            string str;

            if (dataPrint == 0)
                str = node.Question.ToString();
            else
                str = node.Key.ToString();

            UpdateText(node, str);
            UpdateSeparators(node, str, separator);
        }

        public void Render()
        {
            foreach (var y in Grid.Map)
            {
                foreach (var x in y)
                    Console.Write(x.Str);

                Thread.Sleep(10);
                Console.WriteLine();
            }
        }

        private void UpdateText(IgorNode node, string str)
        {
            for (int i = 0; i < str.Length; i++)
                Grid.SetElementToMap((node.Position.Item1 + i, node.Position.Item2), str[i].ToString());
        }

        private void UpdateSeparators(IgorNode node, string str, params string[] separator)
        {
            foreach (var s in separator.Where(x => x != string.Empty))
            {
                var x = 0;

                switch (s)
                {
                    case "\\": x = node.Position.Item1 + str.Length; break;
                    case "/": x = node.Position.Item1 - 1; break;
                }

                Grid.SetElementToMap((x, node.Position.Item2 + 1), s);
            }
        }

        public void Clear()
        {
            for (int y = 0; y < Size.Item2; y++)
                for(int x = 0; x < Size.Item1; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Grid.SetElementToMap((x, y), " ");
                }
        }
    }
}