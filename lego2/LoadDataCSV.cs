using System;
using System.Diagnostics;
using System.IO;

namespace lego2
{
    public partial class Program
    {
        public static void loadData()
        {
            Stopwatch sw = new Stopwatch();
            string path = "../../../../Data/Filtered queries/set_parts.csv";
            try
            {
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
                Console.WriteLine("Se han cargado los datos de los sets en " + sw.Elapsed.ToString() + "segundos");
                sw.Reset();
            }
            catch (FileNotFoundException)
            { 
              Console.WriteLine("El archivo de set_parts no existe. Revise que esté bien escrita su ruta y vuelva a ejecutar");
              Environment.Exit(0); // aborts program execution
            }
            catch (IOException)
            {
                Console.WriteLine("Hay otro programa que está abriendo el archivo de sets. Ciérrelo y vuelva a ejecutar.");
                Environment.Exit(0); // aborts program execution
            }

            path = "../../../../Data/Filtered queries/parts.csv";
            try
            {
                string[] piecesLines = System.IO.File.ReadAllLines(path);
                sw.Start();
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
                sw.Stop();
                Console.WriteLine("Se han cargado los datos de las piezas en " + sw.Elapsed.ToString() + "segundos");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El archivo de parts no existe. Revise que esté bien escrita su ruta y vuelva a ejecutar.");
                Environment.Exit(0); // aborts program execution
            }
            catch (IOException)
            {
                Console.WriteLine("Hay otro programa que está abriendo el archivo de partes. Ciérrelo y vuelva a ejecutar.");
                Environment.Exit(0); // aborts program execution
            }
            Console.WriteLine("Se han cargado satisfactoriamente los datos de sets y de partes.");
        }
    }
}