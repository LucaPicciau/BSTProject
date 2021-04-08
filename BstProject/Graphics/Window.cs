using BstProject.Models;
using System;
using System.Linq;

namespace BstProject.Graphics
{
    public class Window
    {
        public Vector2i Size { get; set; }
        private Grid Grid { get; }

        public Window(Vector2i size)
        {
            Console.SetWindowSize(size.X + 20, size.Y + 20);

            Grid = new Grid(new Vector2i(size.X, size.Y));
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
                Grid.SetElementToMap(node.Position.X + i, node.Position.Y, str[i].ToString());
        }

        private void UpdateSeparators(IgorNode node, string str, params string[] separator)
        {
            var separators = separator.Where(x => x != string.Empty).ToList();

            foreach (var s in separators)
            {
                var x = 0;

                switch (s)
                {
                    case "\\": x = node.Position.X + str.Length; break;
                    case "/": x = node.Position.X - 1; break;
                }

                Grid.SetElementToMap(x, node.Position.Y + 1, s);
            }
        }

        public void Clear() => Grid.Clear();
    }
}