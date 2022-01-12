using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods.Methods.LZ77
{


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
    class LZ77
    {

        byte[] inputData;
        int sizeInputData;
        static int buferSize;
        static int dictSize;
        Part bufer;
        Part dict;
        List<byte[]> code;
        public LZ77(int dictSize_, int buferSize_ = 16)
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
                        if (count < 2)
                        {
                            count = 0;
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
        public int Compress(byte[] inputData)
        {
            BitList output = new BitList();
            this.inputData = inputData;
            sizeInputData = inputData.Length;
            Offset offset;
            CommonSlide(buferSize);
            while (dict.Head < sizeInputData - 1)
            {
                offset = GetOffset();
                CommonSlide(offset.count + 1);
                if (offset.count != 0)
                {
                    output.Write(true);
                    output.Write((byte)(offset.pos >> 4));
                    output.Write((byte)((offset.pos & 0xf) << 4 | offset.count));
                }
                else
                {
                    output.Write(false);
                    output.Write(inputData[dict.Head]);
                }
            }
            return output.GetBytes();
        }

    }
}


