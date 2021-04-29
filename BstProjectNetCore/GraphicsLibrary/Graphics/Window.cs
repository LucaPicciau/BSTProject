using System;
using System.Linq;
using System.Threading;

namespace GraphicsLibrary.Graphics
{

    public class Window
    {
        public (int, int) Size { get; set; }
        private Grid Grid { get; set; }
        private Grid OffsetGrid { get; set; }


        public Window((int, int) size)
        {
            Console.SetWindowSize(size.Item1 + 20, size.Item2 + 20);
            Console.CursorVisible = false;

            Grid = new Grid(size);
            Size = Grid.Size;
            OffsetGrid = new Grid(size);
        }

        private void Clear()
        {
            OffsetGrid.Clear();
            Console.SetCursorPosition(0, Grid.Map.Count);
        }

        private void UpdateTexture(RectangleShape shape)
        {
            if (shape == null) return;

            for (int i = 0; i < shape.Texture.Length; i++)
            {
                var tile = Grid.GetTile((shape.Position.Item1 + i, shape.Position.Item2));

                if (shape.Texture[i].ToString() != tile.Str)
                    OffsetGrid.SetElementToMap(Grid.GetTile((shape.Position.Item1 + i, shape.Position.Item2)).Position, ".");

                Grid.SetElementToMap((shape.Position.Item1 + i, shape.Position.Item2), shape.Texture[i].ToString());
            }
        }

        public void Update(RectangleShape shape)
        {
            UpdateTexture(shape);
        }

        public void Draw()
        {
            Write(OffsetGrid);
            Write(Grid);

            Clear();
        }

        private void Write(Grid grid)
        {
            for (var y = 0; y < grid.Map.Count; y++)
            {
                var toChange = OffsetGrid.Map[y].Where(a => a.Str == ".");

                if (toChange.Count() == 0) continue;

                foreach (var offsetTile in toChange)
                {
                    var tile = grid.GetTile(offsetTile.Position);
                    Console.SetCursorPosition(tile.Position.Item1, tile.Position.Item2);

                    if (tile.Str != " ") Thread.Sleep(50);
                    Console.Write(tile.Str);
                }

                Console.WriteLine();
            }
        }
    }
}