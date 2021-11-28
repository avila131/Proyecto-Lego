namespace lego2
{
    public class Stack<T>
    {
        private LinkedList<T> data;
        public void push(ref T element) => data.pushFront(element);
        public T pop() { return data.popFront(); }
        public T top() { return data.topFront(); }
        public bool is_empty() { return data.isEmpty(); }

        public Stack()
        { data = new LinkedList<T>(); }
    }
}