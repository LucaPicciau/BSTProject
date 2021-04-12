using System;
using System.Collections.Generic;
using System.Threading;

namespace BstProjectNetCore.Graphics
{
    public class Grid
    {
        public List<List<Tile>> Map { get; set; }
        public List<Tile> ChangedMap { get; private set; }

        public (int, int) Size { get; set; }

        public Grid((int, int) size)
        {
            Map = new List<List<Tile>>();
            ChangedMap = new List<Tile>();

            Size = size;

            InitMap();
        }

        public void Clear()
        {
            foreach (var y in Map)
                foreach (var x in y)
                    x.Str = " ";
        }

        public void SetElementToMap((int, int) position, string str)
        {
            if (Size.Item2 >= position.Item2 && Size.Item1 >= position.Item1 && position.Item2 >= 0 && position.Item1 >= 0 &&
                Map[position.Item2][position.Item1].Str != str)
            {
                Thread.Sleep(50);
                Console.SetCursorPosition(position.Item1, position.Item2);

                Map[position.Item2][position.Item1].Str = str;

                ChangedMap.Add(new Tile(".", position));
                Console.Write(ChangedMap[0].Str);
            }
        }

        private void InitMap()
        {
            for (var i = 0; i < Size.Item2; i++)
            {
                Map.Add(new List<Tile>());

                for (var j = 0; j < Size.Item1; j++)
                    Map[i].Add(new Tile(" ", (j, i)));
            }
        }
    }
}