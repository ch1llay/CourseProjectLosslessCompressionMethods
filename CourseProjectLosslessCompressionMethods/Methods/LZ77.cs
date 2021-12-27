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
            while (byteIndex < inputData.Length || bufer.Count > 0)
            {

                offset = GetOffset();
                for (int i = offset.pos; i < offset.pos + offset.count + 1; i++)
                {
                    dict.Add(bufer.TakeFirst());
                    if (byteIndex < inputData.Length)
                    {
                        bufer.Add(inputData[byteIndex]);
                        byteIndex++;
                    }
                }
                byte[] bytes = new byte[] { offset.pos, offset.count, dict.LookLast() };
                foreach (byte b in bytes)
                { 

                    code.Add(b);
                }

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

