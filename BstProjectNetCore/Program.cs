namespace BstProjectNetCore
{
    class Program
    {
        static void Main()
        {
            var hierarchy = Data.ReadData(@"..\..\data.csv");

            var engine = new Engine((140, 20));
            engine.SetBSTTree(hierarchy);
            engine.Run();

            var node = new IgorNode()
            {
                Question = "Prova Inserimento1",
                ParentKey = 90,
                Key = 466,
                TypeChar = 'Y'
            };

            engine.BstTree.Rotate(node);

            engine.Window.Clear();
            engine.Run();
        }
    }
}
