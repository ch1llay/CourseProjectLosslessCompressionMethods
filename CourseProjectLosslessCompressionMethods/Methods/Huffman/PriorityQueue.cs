using System.Collections.Generic;

namespace CourseProjectLosslessCompressionMethods.Methods.Huffman
{
    internal class PriorityQueue<T>
    {
        int size;
        int Size { get { return size; } }
        SortedDictionary<int, Queue<T>> storage;

        public PriorityQueue()
        {
            storage = new SortedDictionary<int, Queue<T>>();
            size = 0;

        }
        public void Enqueue(int priority, T item)
        {
            if (!storage.ContainsKey(priority))
            {
                storage.Add(priority, new Queue<T>());
            }
            storage[priority].Enqueue(item);
            size++;
        }
        public T Dequeue()
        {
            if(size == 0)
            {
                throw new System.Exception("Queue is empty");
            }
            size--;
            foreach(Queue<T> q in storage.Values)
            {
                if(q.Count > 0)
                {
                    return q.Dequeue();
                }
            }
            throw new System.Exception("Queue error");
        }
    }
}