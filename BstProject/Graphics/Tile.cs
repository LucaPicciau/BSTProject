namespace BstProject.Graphics
{
    public class Tile
    {
        public string Str { get; set; }
        public Vector2i Position { get; set; }

        public Tile(string str, Vector2i position)
        {
            Str = str;
            Position = position;
        }
    }
}