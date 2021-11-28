using System;
using System.Diagnostics;

namespace lego2
{
    public partial class Program
    {
        public static void loadData()
        {
            string path = "../../../../Data/Filtered queries/set_parts.csv";

            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Load Sets_Parts
            foreach (var line in System.IO.File.ReadLines(path))
            {
                string[] columns = line.Split(',');
                if (myStack.is_empty())
                    pushLegoSet(ref columns);
                else if (myStack.top().id_set != columns[0]) // Different set
                    pushLegoSet(ref columns);
                else
                    myStack.top().addPiece(columns[2], columns[3], columns[4]);
            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);


            path = "../../../../Data/Filtered queries/parts.csv";
            string[] piecesLines = System.IO.File.ReadAllLines(path);
         
            // Load totalLegoPieces
            foreach (string line in piecesLines)
            {
                string[] columns = line.Split(',');
                Piece newPiece = new Piece();
                newPiece.lego_id = columns[0];
                newPiece.name = columns[1];
                newPiece.index = Int32.Parse(columns[2]);
                newPiece.color = columns[3];
                totalLegoPieces.Add(newPiece);
            }
        }
    }
}
