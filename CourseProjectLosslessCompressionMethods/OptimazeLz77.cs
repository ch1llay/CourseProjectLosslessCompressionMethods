using System;
using System.Collections.Generic;
using System.IO;
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
            dict = new Part(dictSize, -buferSize - 1, -buferSize - 1 - dictSize);

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
                int dictIndex = (dict.Tail >= 0) ? -1 : -dict.Tail - 1;
                int tempDictIndex = (dict.Tail >= 0) ? dict.Tail : 0;
                for (int idict = tempDictIndex; idict <= dict.Head; idict++, dictIndex++)
                {
                    if (inputData[idict] == inputData[bufer.Tail])
                    {
                        tempDictIndex = idict;
                        int buferIndex = bufer.Tail;
                        pos = (byte)dictIndex;
                        while (idict < dict.Head && buferIndex < bufer.Head && buferIndex < sizeInputData - 1 && inputData[tempDictIndex] == inputData[buferIndex])
                        {
                            count++;
                            tempDictIndex++;
                            buferIndex++;
                        }
                        break;
                    }
                }
            }
            if(count == 0)
            {
                pos = 0;
            }
            return new Offset(pos, count);
        }
        string to2(byte n)
        {
            string s = Convert.ToString(n, 2);
            return s;


        }
        byte[] Bits2Bytes()
        {
            byte sum = 0;
            byte bit = 1;
            List<byte> bits = new List<byte>();
            foreach (byte[] data in code)
            {
                foreach (byte b in data)
                {
                    foreach (var c in to2(b))
                    {
                        if (c == '1')
                        {
                            sum |= bit;
                        }
                        if (bit < 128)
                        {
                            bit <<= 1;
                        }
                        else
                        {
                            bits.Add(sum);
                            sum = 0;
                            bit = 1;
                        }

                    }
                }
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


