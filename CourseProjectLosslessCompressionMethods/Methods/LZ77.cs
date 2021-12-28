using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        byte[] inputData;
        List<byte> code;
        ListArray<byte> dict;
        ListArray<byte> bufer;
        public LZ77(int dictionarySize_, int buferSize_)
        {
            dictionarySize = dictionarySize_;
            buferSize = buferSize_;
            dict = new ListArray<byte>(dictionarySize);
            bufer = new ListArray<byte>(buferSize);
            code = new List<byte>();

        }


        class Offset
        {
            public byte pos;
            public byte count;

            public Offset(byte pos, byte count)
            {
                this.pos = pos;
                this.count = count;
            }
        }

        Offset GetOffset()
        {
            int buferIndex = 0;
            int dictIndex = -1;
            byte pos = 0;
            byte count = 0;
            for (int idict = 0; idict < dictionarySize; idict++)
            {
                if (dict[idict] == bufer[0])
                {
                    dictIndex = idict;
                    pos = (byte)dictIndex;
                    while (dictIndex < dictionarySize && buferIndex < buferSize && dict[dictIndex] == bufer[buferIndex])
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
        public void Coding()
        {
            int byteIndex = 0;
            int buferIndex = 0;
            Offset offset;

            // заполнение буфера
            while (buferIndex < buferSize)
            {
                bufer.Add(inputData[byteIndex]);
                buferIndex++;
                byteIndex++;
            }
            int per = 0;
            int length = inputData.Length;
            while (bufer.Count > 0)
            {
                if(byteIndex >  length / 3 * 2)
                {
                    Console.WriteLine();
                }
                per = (byteIndex / length * 100);
                if (per > 0 && per % 10 == 0)
                {
                    Console.WriteLine(per);
                }

                offset = GetOffset();
                for (int i = offset.pos; i < offset.pos + offset.count + 1; i++)
                {
                    dict.Add(bufer.TakeFirst());
                    if (byteIndex < length)
                    {
                        bufer.Add(inputData[byteIndex]);
                        byteIndex++;
                    }
                }
                code.Add(offset.pos);
                code.Add(offset.count);
                code.Add(dict.LookLast());

            }
        }
        public void CompressFile(string inputFilename)
        {
            inputData = File.ReadAllBytes(inputFilename);
            Coding();

            File.WriteAllBytes($"{inputFilename}.lz77", code.ToArray());
        }

    }
}

