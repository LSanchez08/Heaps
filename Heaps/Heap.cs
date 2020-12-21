using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Heaps
{
    class Heap<T> : IHeap<T>
    {
        private int size;
        private double? height;
        private List<T> valores = new List<T>();



        public int Size { get => valores.Count(); set => size = value; }
        public double? Height { get => GetHeightOfIndex(Size); set => height = value; }

        public Heap()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new Exception("Object of Type <T> must implement the Icomparable Interface");
            }
            Size = 0;
            Height = null;
        }

        public Heap(List<T> data)
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new Exception("Object of Type <T> must implement the Icomparable Interface");
            }
            Size = data.Count;
            Height = GetHeightOfIndex(Size - 1);
            valores = data;
            Heapify(1);
        }


        public void Insert(T element)
        {
            valores.Add(element);
            UpHeapBubbling(Size - 1);
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public T Min()
        {
            if (IsEmpty()) { throw new Exception("The heap is empty"); }
            T first = valores[0];
            int index = 0;

            for (int x = 1; x < Size; x++)
            {
                if (Comparer<T>.Default.Compare(first, valores[x]) == 1) 
                {
                    first = valores[x];
                    index = x; 
                }
            }
            
            return valores[index];
        }

        public T RemoveMin()
        {
            if (IsEmpty()) { throw new Exception("The heap is empty"); }

            T delete = Min();
            valores[0] = valores[Size - 1];
            valores.RemoveAt(Size - 1);
            DownHeapBubbling(0);

            return delete;

        }

        public void UpHeapBubbling(int index)
        {
            int indexActual = index;
            while (indexActual > 0)
            {
                if (Comparer<T>.Default.Compare(valores[getParentIndex(indexActual)], valores[indexActual]) == -1)
                {
                    break;
                }
                else
                {
                    T aux = valores[getParentIndex(indexActual)];
                    valores[getParentIndex(indexActual)] = valores[indexActual];
                    valores[indexActual] = aux;
                }
                indexActual = getParentIndex(indexActual);
            }
        }

        public void DownHeapBubbling(int index)
        {

            int indexActual = index;
            while (GetHeightOfIndex(indexActual) < Height)
            {
                int minChildIndex;
                if (getLeftChildIndex(indexActual)<Size && getRightChildIndex(indexActual) > Size-1)
                {
                    minChildIndex = getLeftChildIndex(indexActual);
                }
                else if (Comparer<T>.Default.Compare(valores[getLeftChildIndex(indexActual)], valores[getRightChildIndex(indexActual)]) == 1)
                {
                    minChildIndex = getRightChildIndex(indexActual);
                }
                else
                {
                    minChildIndex = getLeftChildIndex(indexActual);
                }


                if (Comparer<T>.Default.Compare(valores[indexActual], valores[minChildIndex]) == 1)
                {
                    T aux = valores[indexActual];
                    valores[indexActual] = valores[minChildIndex];
                    valores[minChildIndex] = aux;
                }
                else
                {
                    break;
                }

                indexActual = minChildIndex;
            }
        }

        private void Heapify_rec(int n, int i, int type)
        {
            int largest = i;
            int left = getLeftChildIndex(i);
            int right = getRightChildIndex(i);
            if (left < n && Comparer<T>.Default.Compare(valores[i], valores[left]) == type)
            {
                largest = left;
            }

            if (right < n && Comparer<T>.Default.Compare(valores[largest], valores[right]) == type)
            {
                largest = right;
            }

            if (largest != i)
            {
                T aux = valores[i];
                valores[i] = valores[largest];
                valores[largest] = aux;
                Heapify_rec(n, largest, type);
            }

            
        }

        public void Heapify(int type)
        {

            for (int x = valores.Count; x > -1; x--)
            {
                Heapify_rec(valores.Count, x, type);
            }

        }

        public void HeapSort(int type)
        {
            Heapify(type);
            int n = valores.Count;
            
            for (int x = n - 1; x > 0; x--)
            {
                T aux = valores[x];
                valores[x] = valores[0];
                valores[0] = aux;
                Heapify_rec(x, 0, type);
            }
        }

        private static void Heapify_rec(int n, int i, int type, List<T> valores)
        {
            int largest = i;
            int left = (2 * i) + 1;
            int right = (2 * i) + 2;
            if (left < n && Comparer<T>.Default.Compare(valores[i], valores[left]) == type)
            {
                largest = left;
            }

            if (right < n && Comparer<T>.Default.Compare(valores[largest], valores[right]) == type)
            {
                largest = right;
            }

            if (largest != i)
            {
                T aux = valores[i];
                valores[i] = valores[largest];
                valores[largest] = aux;
                Heapify_rec(n, largest, type, valores);
            }


        }

        public static List<T> Heapify(int type, List<T> valores)
        {

            for (int x = valores.Count; x > -1; x--)
            {
                Heapify_rec(valores.Count, x, type, valores);
            }
            return valores;

        }

        public static List<T> HeapSort(int type, List<T> valores)
        {
            Heapify(type, valores);
            int n = valores.Count;

            for (int x = n - 1; x > 0; x--)
            {
                T aux = valores[x];
                valores[x] = valores[0];
                valores[0] = aux;
                Heapify_rec(x, 0, type, valores);
            }

            return valores;
        }


        private int getParentIndex(int index) => (index-1)/2;
        private int getLeftChildIndex(int index) => (2*index)+1;
        private int getRightChildIndex(int index) => (2*index)+2;
        public double GetHeightOfIndex(int index) => Math.Round(Math.Truncate(Math.Log((index + 1), 2)));

        public override string ToString() => string.Join( ",", valores.ToArray());
    }
}
