namespace lego2
{
    public class LegoSet
    {
        public string id_set { get; set; }
        public string nameSet { get; set; }
        
        public DynamicArray<string[]> pieces = new DynamicArray<string[]>();

        public void addPiece(string pieceName, string quantity, string partIndex)
        {
            string[] newPiece = { pieceName, quantity, partIndex };
            pieces.Add(newPiece);
        }
    }
}