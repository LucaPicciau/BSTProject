using BstProjectNetCore.Models;

namespace BstProjectNetCore
{
    partial class Program
    {
        static void Main()
        {
            while (true)
            {
                var hierarchy = Data.ReadData(@"..\..\..\data.csv");

                var engine = new Engine((60, 20));
                engine.SetBSTTree(hierarchy);
                engine.Run();

                var node = new IgorNode()
                {
                    Question = "Prova Rotazione1",
                    ParentKey = 90,
                    Key = 466,
                    TypeChar = 'Y'
                };

                engine.BstTree.Rotate(node);


                var node2 = new IgorNode()
                {
                    Question = "Prova Inserimento2",
                    ParentKey = 67,
                    Key = 450,
                    TypeChar = 'N'
                };

                var node3 = new IgorNode()
                {
                    Question = "Prova Inserimento2",
                    ParentKey = 98,
                    Key = 444,
                    TypeChar = 'N'
                };

                var node4 = new IgorNode()
                {
                    Question = "Prova Inserimento2",
                    ParentKey = 444,
                    Key = 442,
                    TypeChar = 'N'
                };

                var node5 = new IgorNode()
                {
                    Question = "Prova Inserimento2",
                    ParentKey = 93,
                    Key = 441,
                    TypeChar = 'N'
                };

                node3.Insert(node4);

                engine.BstTree.Insert(node2);
                engine.BstTree.Insert(node3);
                engine.BstTree.Insert(node5);

                engine.Run();

                engine.Window.Clear();
            }
        }
    }

}
