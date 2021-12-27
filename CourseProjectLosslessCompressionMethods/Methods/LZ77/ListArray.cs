using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods.Methods.LZ77
{
    class ListArray<T>
    {
        T[] m;
        int size;
        List<T> l;
        int indexFromDown = 0;
        int indexFromUp = 0;
        public ListArray(int size)
        {
            this.size = size;
            m = new T[size];
            l = new List<T>(size);

        }

        void FillM()
        {
            for (int i = 0; i < l.Count; i++)
            {
                m[i] = l[i];
            }
            for (int i = l.Count - 1; i < size; i++)
            {
                m[i] = default;
            }
        }
        public void FillMFromDown()
        {
            
        }
        public void Add(T el)
        {
            if (l.Count < size)
            {
                l.Add(el);
                FillM();

            }
            else
            {
                throw new Exception("Переполнение");
            }
        }

        public T TakeFirst()
        {
            if (l.Count > 0)
            {
                T el = l[0];
                l.RemoveAt(0);
                FillM();
                return el;
            }
            else
            {
                throw new Exception("Пусто");
            }

        }
        public T LookLast()
        {
            if (l.Count > 0)
            {
                T el = l.Last();
                return el;
            }
            else
            {
                throw new Exception("Пусто");
            }

        }
        public T this[int index]
        {
            get
            {
                return m[index];
            }

            set
            {
                m[index] = value;
            }
        }


    }
}
