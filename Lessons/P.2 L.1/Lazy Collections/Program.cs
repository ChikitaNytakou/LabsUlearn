using System.Collections;

namespace Lazy_Collections
{
    public class Sequences
    {
        public static IEnumerable<long> Fibonacci
        {
            get
            {
                long previous = 1;
                long current = 1;
                yield return 1;
                yield return 1;
                while (true)
                {
                    var newValue = previous + current;
                    previous = current;
                    current = newValue;
                    yield return current;
                }

            }
        }

        public static IEnumerable<long> Exponential(int multiplier)
        {
            var value = 1;
            while (true)
            {
                yield return value;
                value *= multiplier;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var e in Sequences.Exponential(2))
            {
                Console.WriteLine(e);
                Thread.Sleep(100);
                if (Console.KeyAvailable) break;
            }
        }
    }
}
