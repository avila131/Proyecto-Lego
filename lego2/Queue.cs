namespace lego2
{
    public class Queue<T>
    {
        private LinkedList<T> data;
        public void enqueue(T element) => data.pushBack(ref element);
        public T dequeue() { return data.popFront(); }
        public bool is_empty() { return data.isEmpty(); }
        public T peek() { return data.topFront(); }
        public Queue()
        { data = new LinkedList<T>(); }
    }
}