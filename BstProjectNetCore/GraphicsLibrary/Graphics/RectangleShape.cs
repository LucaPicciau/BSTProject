namespace GraphicsLibrary.Graphics
{
    public class RectangleShape
    {
        public (int, int) Position { get; set; }
        public string Texture { get; set; }

        public RectangleShape() => Texture = string.Empty;
    }
}