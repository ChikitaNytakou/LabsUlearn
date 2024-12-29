namespace GenericQueue
{
    class QueueItem
    {
        public int Value { get; set; }
        public QueueItem Next { get; set; }
    }

    class Queue
    {
        QueueItem head;
        QueueItem tail;

        public void Enqueue(int value)
        {
            var newItem = new QueueItem { Value = value };
            if (head == null)
            {
                head = tail = newItem;
            }
            else
            {
                tail.Next = newItem;
                tail = newItem;
            }
        }

        public int Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var delValue = head.Value;
            head = head.Next;
            if (head == null) tail = null;
            return delValue;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
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
