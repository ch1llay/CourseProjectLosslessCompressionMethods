using System;
using System.Collections.Generic;
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
        public int Differense { get => Head - Tail+1; }
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
        string inputData;
        static int buferSize;
        static int dictSize;
        Part bufer;
        Part dict;
        List<string> code;
        public OptimazeLz77(int buferSize_, int dictSize_, string inputData_)
        {
            buferSize = buferSize_;
            dictSize = dictSize_;
            this.inputData = inputData_;
            code = new List<string>();
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
                int dictIndex = (dict.Tail >= 0) ? -1 : -dict.Tail-1;
                int tempDictIndex = (dict.Tail >= 0) ? dict.Tail : 0;
                for (int idict = tempDictIndex; idict <= dict.Head && idict >= 0; idict++, dictIndex++)
                {
                    if (inputData[idict] == inputData[bufer.Tail])
                    {
                        tempDictIndex = idict;
                        int buferIndex = bufer.Tail;
                        pos = (byte)dictIndex;
                        while (idict < dict.Head && buferIndex < bufer.Head && inputData[tempDictIndex] == inputData[buferIndex])
                        {
                            count++;
                            tempDictIndex++;
                            buferIndex++;
                        }
                        break;
                    }
                }
            }
            return new Offset(pos, count);
        }
        public void Coding()
        {
            Offset offset;
            CommonSlide(buferSize);
            while (dict.Tail < inputData.Length)
            {
                offset = GetOffset();
                CommonSlide(offset.count+1);
                code.Add($"({offset.pos} {offset.count} {inputData[dict.Head]}");

            }
        }

    }

}
