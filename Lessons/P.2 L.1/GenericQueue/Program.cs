namespace GenericQueue
{
    class Stack
    {
        List<int> list = new List<int>();
        public void Push(int value)
        {
            list.Add(value);
        }
        public int Pop()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }
    }

    class Queue
    {
        List<int> list = new List<int> ();
        public void Enqueue(int value)
        {
            list.Add(value);
        }

        public int Dequeue()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list[0];
            list.RemoveAt(0);
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            var queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
