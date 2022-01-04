using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods
{
    class Part
    {
        int size;
        public int Head;
        public int Tail;
        public Part(int size, int head, int tail)
        {
            this.size = size;
            Head = head;
            Tail = tail;
        }
        public void Slide(int count)
        {
            Head += count;
            Tail += count;
        }
        public int Differense { get => Head - Tail + 1; }
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

    class OptimazeLz77
    {
        byte[] inputData;
        int sizeInputData;
        static int buferSize;
        static int dictSize;
        Part bufer;
        Part dict;
        List<byte[]> code;
        public OptimazeLz77(int buferSize_, int dictSize_)
        {
            buferSize = buferSize_;
            dictSize = dictSize_;
            code = new List<byte[]>();
            bufer = new Part(buferSize, -1, -buferSize);
            dict = new Part(dictSize, -buferSize - 1, -buferSize - dictSize);

        }
        void CommonSlide(int count)
        {
            bufer.Slide(count);
            dict.Slide(count);
        }
        Offset GetOffset()
        {
            byte count = 0;
            byte pos = 0;
            if (dict.Head >= 0)
            {
                int dictIndex = (dict.Tail >= 0) ? 0 : -dict.Tail;
                int tempDictIndex = (dict.Tail >= 0) ? dict.Tail : 0;
                for (int idict = tempDictIndex; idict <= dict.Head; idict++, dictIndex++)
                {
                    if (inputData[idict] == inputData[bufer.Tail])
                    {
                        tempDictIndex = idict;
                        int buferIndex = bufer.Tail;
                        pos = (byte)dictIndex;
                        while (tempDictIndex < dict.Head && buferIndex < bufer.Head && buferIndex < sizeInputData - 1 && inputData[tempDictIndex] == inputData[buferIndex])
                        {
                            count++;
                            tempDictIndex++;
                            buferIndex++;
                        }
                        break;
                    }
                }
            }
            if (count == 0)
            {
                pos = 0;
            }
            return new Offset(pos, count);
        }
        string to2(byte n)
        {
            string s = Convert.ToString(n, 2);
            //int lengthOn1 = CountBit(dictSize);
            //int length = s.Length;
            //int countGroupForLength = (int)Math.Ceiling((double)length / (double)lengthOn1);
            //if(length < countGroupForLength*lengthOn1)
            //{
            //    for(int i = 0; i < countGroupForLength * lengthOn1 - length; i++)
            //    {
            //        s = s.Insert(0, "0");
            //    }
            //}
            return s;


        }
        int CountBit(int value) {
            if(value < 2)
            {
                return 1;
            }
            if(value == 2)
            {
                return 2;
            }
            return (int)Math.Ceiling(Math.Log(value, 2));
        }
        byte[] Bits2Bytes()
        {
            byte sum = 0;
            byte bit = 128;
            int bitsAmount = (int)Math.Log(Math.Min(buferSize, dictSize), 2) + 1;
            List<byte> bits = new List<byte>();
            byte tempByte;
            
            foreach (byte[] data in code)
            {

                WriteBits(data[0], CountBit(dictSize));
                WriteBits(data[1], CountBit(buferSize));
                WriteBits(data[2],  8);
            }
            void WriteBits(byte v, int countBit)
            {
                string s = "";
                for (int j = countBit-1; j >= 0; j--)
                {
                    int c = (v >> j) & 1;
                    s += c;
                    if (c > 0)
                    {
                        sum |= bit;
                    }
                    if (bit > 0)
                    {
                        bit >>= 1;
                    }
                    if(bit == 0)
                    {
                        bits.Add(sum);
                        sum = 0;
                        bit = 128;
                    }

                }
            }
            if(sum > 0)
            {
                bits.Add(sum);
            }
            return bits.ToArray();
            
        }
        public void CompressFile(string inputFilename)
        {
            inputData = File.ReadAllBytes(inputFilename);
            sizeInputData = inputData.Length;
            Coding();
            byte[] outputData = Bits2Bytes();
            File.WriteAllBytes($"{inputFilename}.lz77", outputData);

        }
        public void Coding()
        {
            Offset offset;
            CommonSlide(buferSize);
            while (dict.Head < sizeInputData - 1)
            {
                offset = GetOffset();
                CommonSlide(offset.count + 1);
                byte[] tempBytes = new byte[] { offset.pos, offset.count, inputData[dict.Head] };
                Console.WriteLine($"({offset.pos}, {offset.count}, {(char)inputData[dict.Head]})");
                code.Add(tempBytes);

            }
        }

    }
}


