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
        /*
         * положить все в буфер
         * посмотреть нет ли сопадений словаря с буфером
         * сдвинуть влево элементы (0 из буфера станет последним в словаре и так по всем совпадающим) (записывать позицию и количество
         * записать в code (от, сколько, последний символ из словаря)
         */

        static int dictionarySize;
        static int buferSize;
        string inputData;
        string code;
        ListArray<char> dict;
        ListArray<char> bufer;
                public LZ77(string inputData, int dictionarySize_, int buferSize_)
        {
            this.inputData = inputData;
            dictionarySize = dictionarySize_;
            buferSize = buferSize_;
            dict = new ListArray<char>(dictionarySize);
            bufer = new ListArray<char>(buferSize);

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
            int buferIndex = 0;
            int dictIndex = -1;
            int pos = 0;
            int count = 0;
           for(int idict = 0; idict < dictionarySize; idict++)
            {
                if(dict[idict] == bufer[0])
                {
                    dictIndex = idict;
                    pos = dictIndex;
                    while (dictIndex < dictionarySize && dict[dictIndex] == bufer[buferIndex] && buferIndex < buferSize)
                    {
                        count++;
                        dictIndex++;
                        buferIndex++;
                    }
                    break;
                }
            }
            return new Offset(pos, count);

        }
        void Slide(Offset offset)
        {

        }
        public void Coding()
        {
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
            while (stringIndex < inputData.Length || bufer.Count > 0)
            {

                offset = GetOffset();
                for (int i = offset.pos; i < offset.pos+offset.count+1; i++)
                {
                    dict.Add(bufer.TakeFirst());
                    if (stringIndex < inputData.Length)
                    {
                        bufer.Add(inputData[stringIndex]);
                        stringIndex++;
                    }
                }

                code += $"({offset.pos}, {offset.count} {dict.LookLast()})\n";

            }
            Console.WriteLine(code);
        }


    }
}

