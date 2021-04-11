namespace BstProject.Graphics
{
    public class Tile
    {
        public string Str { get; set; }
        public (int, int) Position { get; set; }

        public Tile(string str, (int, int) position) => (Str, Position) = (str, position);
    }
}