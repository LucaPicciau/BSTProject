using System.Collections.Generic;

namespace BstProject.Graphics
{
    public class Grid
    {
        public List<List<Tile>> Map { get; set; }
        public Vector2i Size { get; set; }

        public Grid(Vector2i size)
        {
            Map = new List<List<Tile>>();
            Size = size;

            InitMap();
        }

        public void Clear()
        {
            foreach (var y in Map)
                foreach (var x in y)
                    x.Str = " ";
        }

        public void SetElementToMap(int x, int y, string str)
        {
            if (Size.Y >= y && Size.X >= x && y >= 0 && x >= 0)
                Map[y][x].Str = str;
        }

        private void InitMap()
        {
            for (var i = 0; i < Size.Y; i++)
            {
                Map.Add(new List<Tile>());

                for (var j = 0; j < Size.X; j++)
                    Map[i].Add(new Tile(" ", new Vector2i(j, i)));
            }
        }
    }
}