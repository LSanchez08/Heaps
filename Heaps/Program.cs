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

            heap.Heapify(1);
            // heap.HeapSort(1);
            Console.WriteLine(heap.ToString());
            Console.WriteLine(heap.RemoveMin());
            Console.WriteLine(heap.ToString());
            //heap.Insert(4);
            //Console.WriteLine(heap.ToString());
            Console.WriteLine("End");

            List<int> num2 = new List<int> { 4, 8, 3, 7, 4, 1 };

            

            Console.WriteLine(string.Join(",", Heap<int>.Heapify(1, num2).ToArray()));

            Console.WriteLine("_____HeapSort_____");
            Console.WriteLine(string.Join(",", Heap<int>.HeapSort(-1, num2).ToArray()));
            Console.ReadLine();
        }
    }
    public class Auto{

    }
}
