namespace lego2
{
    public class Node<T>
    {
        public T key { get; set; }
        public Node<T> next { get; set; }

        public Node(T givenData)
        {
            key = givenData;
            next = null;
        }
    }
}
