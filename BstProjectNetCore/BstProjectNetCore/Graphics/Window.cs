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
            //Console.CursorVisible = false;

            Grid = new Grid(size);
            Size = Grid.Size;
        }

        public void Update(IgorNode node, int dataPrint = 0, params string[] separator)
        {
            var str = dataPrint switch
            {
                0 => node.Question.ToString(),
                _ => node.Key.ToString(),
            };

            UpdateText(node, str);
            UpdateSeparators(node, str, separator);
        }

        public void Render()
        {
            for (var y = 0; y < Grid.Map.Count; y++)
            {
                var toChange = Grid.ChangedMap.Where(a => a.Position.Item2 == y).ToList();

                if (toChange.Count == 0)
                    continue;

                for (var x = 0; x < toChange.Count; x++)
                {
                    Console.SetCursorPosition(toChange[x].Position.Item1, toChange[x].Position.Item2);

                    var tile = Grid.Map[toChange[x].Position.Item2][toChange[x].Position.Item1];

                    if (tile.Str != " ") Thread.Sleep(100);
                    Console.Write(tile.Str);
                }

                Console.WriteLine();
            }

            Grid.ChangedMap.Clear();
            Console.SetCursorPosition(0, Grid.Map.Count);
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
                var x = s switch
                {
                    "\\"    => node.Position.Item1 + str.Length,
                    "/"     => node.Position.Item1 - 1,
                    _       => 0,
                };

                Grid.SetElementToMap((x, node.Position.Item2 + 1), s);
            }
        }

        public void Clear()
        {
            for (int y = 0; y < Size.Item2; y++)
                for (int x = 0; x < Size.Item1; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Grid.SetElementToMap((x, y), " ");
                }

        }
    }
}