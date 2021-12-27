using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods.Methods.LZ77
{
    class LZ77
    {

        static int dictionarySize;
        static int buferSize;
        string inputData;
        string code;
        ListArray<char> dict = new ListArray<char>(dictionarySize);
        ListArray<char> bufer = new ListArray<char>(buferSize);
        public LZ77(string inputData, int dictionarySize_, int buferSize_)
        {
            this.inputData = inputData;
            dictionarySize = dictionarySize_;
            buferSize = buferSize_;

        }

        class ListArray<T>
        {
            T[] m;
            int size;
            List<T> l;
            public ListArray(int size)
            {
                this.size = size;
                m = new T[size];
                l = new List<T>(size);

            }

            void FillM()
            {
                for(int i = 0; i < l.Count; i++)
                {
                    m[i] = l[i];
                }
                for(int i = l.Count - 1; i < size; i++)
                {
                    m[i] = default;
                }
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

            public T Take0()
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
        class Offset
        {
            public int pos;
            public int count;

            public Offset(int pos, int count)
            {
                this.pos = pos;
                this.count = count;
            }
        }

        Offset GetOffset()
        {
            int i = 0;
            int pos = 0;
            int count = 0;
            while (i < buferSize && dict[i] != bufer[i])
            {
                i++;
            }
            if (i != buferSize - 1)
            {
                pos = i;
                while (i < buferSize && dict[i] == bufer[i])
                {
                    count++;
                    i++;
                }
            }
            return new Offset(pos, count);

        }
        void Slide(Offset offset)
        {

        }
        public void Coding()
        {
            for (int i = 0; i < dictionarySize; i++)
            {
                dict.Add((char)0);
            }
            int stringIndex = 0;
            int buferIndex = 0;
            int dictIndex = 0;
            Offset offset;

            // заполнение буфера
            while (buferIndex < buferSize)
            {
                bufer.Add(inputData[stringIndex]);
                buferIndex++;
                stringIndex++;
            }
            buferIndex = 0;
            while (stringIndex < inputData.Length)
            {

                offset = GetOffset();
                int startIndex = offset.pos + ((offset.count % 10 > 0) ? offset.count - 1 : offset.count);
                for (int i = startIndex; i >= 0; i--)
                {
                    dict.Add(bufer.Take0());
                    bufer.Add(inputData[stringIndex]);
                    stringIndex++;
                }

                code += $"({offset.pos}, {offset.count} {dict[0]}\n";

            }
            Console.WriteLine(code);
        }


    }
}

