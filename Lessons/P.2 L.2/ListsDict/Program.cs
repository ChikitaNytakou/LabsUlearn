using System.Collections;

namespace ListsDict
{
    public class MyList<T> : IEnumerable<T>
    {
        public T[] collection;
        int count = 0;

        public int Count { get { return count; } }

        void Enlarge()
        {
            throw new NotImplementedException();
        }
        public MyList()
        {
            collection = new T[100];
        }
        public void Add(T value)
        {
            if (count == collection.Length)
                Enlarge();
            collection[count++] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return collection[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                return collection[index];
            }
            set
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                collection[index] = value;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            foreach (var e in list)
                Console.WriteLine(e);
        }
    }
}
