using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace GenericQueue
{
    class QueueItem<TValue>
    {
        public TValue Value { get; set; }
        public QueueItem<TValue> Next { get; set; }
    }

    class Queue<TValue> : IEnumerable<TValue>
    {
        QueueItem<TValue> head;
        QueueItem<TValue> tail;

        public void Enqueue(TValue value)
        {
            var newItem = new QueueItem<TValue> { Value = value };
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

        public TValue Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var delValue = head.Value;
            head = head.Next;
            if (head == null) tail = null;
            return delValue;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            foreach (var item in queue)
                Console.WriteLine(item);
        }
    }
}
