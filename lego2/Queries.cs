using System;
using System.Diagnostics;
using System.Linq;

namespace lego2
{
    public partial class Program
    {
        public static void pushLegoSet(ref string[] line)
        {
            LegoSet newLegoSet = new LegoSet();
            newLegoSet.id_set = line[0];
            newLegoSet.nameSet = line[1];
            newLegoSet.addPiece(line[2], line[3], line[4]);
            myStack.push(ref newLegoSet);
            setsLinkedList.pushBack(ref newLegoSet);
        }

        public static LegoSet getLegoSetByID(ref LinkedList<LegoSet> setsLinkedList, string givenSetID)
        {
            Node<LegoSet> legoSetNodePointer = setsLinkedList.head;
            while (legoSetNodePointer.next != null)
            {
                if (legoSetNodePointer.key.id_set == givenSetID)
                    return legoSetNodePointer.key;
                legoSetNodePointer = legoSetNodePointer.next;
            }
            return null;
        }

        public static DynamicArray<Piece> getPiecesByColor(string givenColor)
        {
            if (totalLegoPieces.Count() == 0)
            {
                Console.WriteLine("No hay piezas para buscar");
                return null;
            }
            if (!colors.Contains(givenColor))
            {
                Console.WriteLine("No hay piezas de color " + givenColor);
                return null;
            }
            DynamicArray<Piece> returnList = new DynamicArray<Piece>();
            for (int i = 0; i < totalLegoPieces.Count(); i++)
                if (totalLegoPieces.data[i].color == givenColor)
                    returnList.Add(totalLegoPieces.data[i]);
            return returnList;
        }

        public static DynamicArray<LegoSet> getSetByName(string nameLegoSet)
        {
            DynamicArray<LegoSet> returnList = new DynamicArray<LegoSet>();
            Node<LegoSet> nodeIterator = setsLinkedList.head;
            while (nodeIterator.next != null)
            {
                if (nodeIterator.key.nameSet.Contains(nameLegoSet))
                    returnList.Add(nodeIterator.key);
                nodeIterator = nodeIterator.next;
            }
            return returnList;
        }

        public static LegoSet getSetByID(string idLegoSet)
        {
            Node<LegoSet> nodeIterator = setsLinkedList.head;
            while (nodeIterator.next != null)
            {
                if (nodeIterator.key.id_set == idLegoSet)
                    return nodeIterator.key;
                nodeIterator = nodeIterator.next;
            }
            return null;
        }

        public static void removeSetByID(string idLegoSet)
        {
            if (setsLinkedList.head == null) return;
            Node<LegoSet> nodeIterator = setsLinkedList.head;
            if (nodeIterator.key.id_set == idLegoSet || nodeIterator.next == null)
            {
                if (nodeIterator.next == null)
                    setsLinkedList.head = null;
                else
                    setsLinkedList.head = setsLinkedList.head.next;
            }
            else
            {
                Node<LegoSet> prev = setsLinkedList.head;
                nodeIterator = nodeIterator.next;
                while (nodeIterator.next != null)
                {
                    nodeIterator = prev.next;
                    if (nodeIterator.key.id_set == idLegoSet)
                    {
                        prev.next = nodeIterator.next;
                        return;
                    }
                    nodeIterator = nodeIterator.next;
                    prev = prev.next;
                }
            }
        }

        public static void removePieceByID(string givenID)
        {
            
            int removeIndex = totalLegoPieces.arraySize - 1;
            for (int i = 0; i < totalLegoPieces.arraySize; i++)
                if (totalLegoPieces.data[i].lego_id == givenID)
                    removeIndex = i;
            for (int i = removeIndex; i < totalLegoPieces.arraySize - 1; i++)
                totalLegoPieces.data[i] = totalLegoPieces.data[i + 1];

        }

        public static Piece getPieceByID(string givenID)
        {
            for (int i = 0; i < totalLegoPieces.arraySize; i++)
                if (totalLegoPieces.data[i].lego_id == givenID)
                    return totalLegoPieces.data[i];
            return null;
        }


        // Get the name of pieces a set has
        public static DynamicArray<string[]> getPiecesNames(string idLegoSet)
        {
            DynamicArray<string[]> resultList = new DynamicArray<string[]>();
            LegoSet legoSet = getSetByID(idLegoSet);
            for (int i = 0; i < legoSet.pieces.Count(); i++)
            {
                int partIndex = Int32.Parse(legoSet.pieces.data[i][2]);
                Piece currentPiece = totalLegoPieces.data[partIndex];  // find the piece in the list of all Lego pieces
                string[] pieceProperties = { currentPiece.name, currentPiece.lego_id, currentPiece.color };
                resultList.Add(pieceProperties);
            }
            return resultList;
        }
    }
}