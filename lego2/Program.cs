using System;
using System;
using System.Diagnostics;

namespace lego2
{
    public partial class Program
    {
        public static Stack<LegoSet> myStack = new Stack<LegoSet>();
        public static LinkedList<LegoSet> setsLinkedList = new LinkedList<LegoSet>();
        public static DynamicArray<Piece> totalLegoPieces = new DynamicArray<Piece>();
        public static Queue<LegoSet> userWishQueue = new Queue<LegoSet>();
         
        static void Main(string[] args)
        {
            loadData();
            setsLinkedList.popBack();

            // Get a list of all green pieces   O(n)
            DynamicArray<Piece> greenPieces = getPiecesByColor("Green");

            // Get all LegoSets with a given name
            DynamicArray<LegoSet> legoNinjago = getSetByName("Ninjago");
            
            // Get LegoSet with given id_set
            LegoSet basicBuildingSet = getSetByID("011-1");
            
            // Get list of Pieces in a LegoSet
            DynamicArray<string[]> piecesIn = getPiecesNames("011-1");
                        
            // Count number of pieces in a LegoSet
            int totalPieces = getSetByID("011-1").pieces.Count();

            // Update a LegoSet name given its id
            LegoSet setToUpdate = getSetByID("028-1");  // Nurse set
            setToUpdate.nameSet = "Nombre modificado para prueba";        

            // Delete a LegoSet given its id
            removeSetByID("001-1");  // Gears          

            // Delete a LegoPiece given its lego_id
            removePieceByID("1"); // Remove 2nd piece from original data      

            //Update a LegoPiece given its lego_id
            Piece pieceToUpdate = getPieceByID("10000"); // Duplo Animal Brick 2 x 2 Elephant Head
            pieceToUpdate.color = "Modified color!";


            //          Implement user wish queue               

            // First add some sets
            userWishQueue.enqueue(getSetByID("WIESBADEN-1")); // This one's at the end of list
            userWishQueue.enqueue(getSetByID("WEETABIX4-1")); // Also at end of list
            userWishQueue.enqueue(getSetByID("6414-1"));

            // Now dequeue: Only "WEETABIX4-1" and "6414-1" will remain in queue
            userWishQueue.dequeue(); // ignore return value

            // Print the current project the user is working on
            Console.WriteLine("The current project user's working on is: " + userWishQueue.peek().id_set + " which is called " + userWishQueue.peek().nameSet);
        }
    }
}