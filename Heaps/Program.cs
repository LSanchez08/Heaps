using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = new List<int> { 9, 7, 3, 5, 1, 3, 10 };

            Heap<int> heap = new Heap<int>(num);
            Heap<int> emptyHeap = new Heap<int>();

            Console.WriteLine("\n-------- Size --------");
            Console.WriteLine($"Size: {heap.Size}");

            Console.WriteLine("\n-------- isEmpty --------");
            Console.WriteLine($"isEmpty: {heap.IsEmpty()}");
            Console.WriteLine($"isEmpty: {emptyHeap.IsEmpty()}");

            Console.WriteLine("\n-------- isEmpty --------");
            Console.WriteLine($"original heap: {heap.ToString()}");
            heap.Insert(22);
            heap.Insert(-5);
            Console.WriteLine($"changed heap: {heap.ToString()}");

            Console.WriteLine("\n-------- Mins --------");
            Console.WriteLine($"Minimum: {heap.Min()}");
            heap.RemoveMin();
            Console.WriteLine($"changed heap: {heap.ToString()}");

            Console.WriteLine("\n-------- HeapSort inside heap --------");
            heap.HeapSort(-1);
            Console.Write("List: [ ");
            foreach (int e in num)
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine("]");



            List<int> num2 = new List<int> { 4, 8, 3, 7, 4, 1 };


            Console.WriteLine("\n-------- Static method Heapify --------");
            Console.WriteLine($"Min heap: {string.Join(",", Heap<int>.Heapify(1, num2).ToArray())}");
            Console.WriteLine($"Max heap: {string.Join(",", Heap<int>.Heapify(-1, num2).ToArray())}");

            Console.WriteLine("\n-------- Static method HeapSort --------");
            Console.WriteLine($"smallest - largest: {string.Join(",", Heap<int>.HeapSort(-1, num2).ToArray())}");
            Console.WriteLine($"largest - smallest: {string.Join(",", Heap<int>.HeapSort(1, num2).ToArray())}");


            // Heap<Auto> Autos = new Heap<Auto>();
            Console.ReadLine();
        }

    }
    public class Auto{

    }
}
