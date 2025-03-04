using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafovias.Classes;
    

public class Heap<T> where T:IComparable<T>
{
    private List<T> heap;

    public Heap()
    {
        heap = new List<T>();
    }

    public void Insert(T item)
    {
        heap.Add(item);
        HeapifyUp(heap.Count - 1);
    }

    public T ExtractMin()
    {
        if (heap.Count == 0){
             throw new InvalidOperationException("Heap is empty");
            }

        T min = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        HeapifyDown(0);
        return min;
    }

    public bool IsEmpty()
    {
        return heap.Count == 0;
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index].CompareTo(heap[parentIndex]) >= 0)
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChild, rightChild, smallestChild;
        while (true)
        {
            leftChild = 2 * index + 1;
            rightChild = 2 * index + 2;
            smallestChild = index;

            if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[smallestChild]) < 0)
                smallestChild = leftChild;

            if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[smallestChild]) < 0)
                smallestChild = rightChild;

            if (smallestChild == index)
                break;

            Swap(index, smallestChild);
            index = smallestChild;
        }
    }

    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}

