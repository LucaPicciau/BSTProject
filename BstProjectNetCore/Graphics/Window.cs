using BstProject.Models;
using System;
using System.Linq;

namespace BstProject.Graphics
{
    public class Window
    {
        public (int, int) Size { get; set; }
        private Grid Grid { get; }

        public Window((int, int) size)
        {
            Console.SetWindowSize(size.Item1 + 20, size.Item2 + 20);

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
                y.ForEach(x => Console.Write(x.Str));

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
            var separators = separator.Where(x => x != string.Empty).ToList();

            foreach (var s in separators)
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

        public void Clear() => Grid.Clear();
    }
}