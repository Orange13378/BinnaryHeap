namespace BinaryHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var startItems = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                startItems.Add(random.Next(-1000, 1000));
            }

            var heap = new Heap(startItems);

            for (int i = 0; i < 100; i++)
            {
                heap.Add(random.Next(-1000, 1000));
            }

            foreach (var item in heap)
            {
                Console.WriteLine(item);
            }
        }
    }
}