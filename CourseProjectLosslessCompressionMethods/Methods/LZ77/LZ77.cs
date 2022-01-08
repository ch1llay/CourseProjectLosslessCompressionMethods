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

    class LZ77
    {
        // 12 bits to store maximum offset distance.
        public const int MAX_WINDOW_SIZE = (1 << 12) - 1;

        // 4 bits to store length of the match.
        public const int LOOK_AHEAD_BUFFER_SIZE = (1 << 4) - 1;

        // sliding window size
        private int windowSize = MAX_WINDOW_SIZE;
        int inputDataSize;
        byte[] inputData;
        public LZ77(int windowSize)
        {

            this.windowSize = Math.Min(windowSize, MAX_WINDOW_SIZE);
        }
        Offset GetOffset(int currentPos)
        {
            byte count = 0;
            byte pos = 0;
            int end = Math.Min(currentPos + LOOK_AHEAD_BUFFER_SIZE, inputDataSize + 1);
            for (int j = currentPos + 2; j < end; j++)
            {
                int startPos = Math.Max(0, currentPos - windowSize);
                int bytesToMatchLength = j - currentPos;
                byte[] bytesToMatch = new byte[bytesToMatchLength];
                Array.Copy(inputData, currentPos, bytesToMatch, 0, bytesToMatchLength);

                for (int i = startPos; i < currentPos; i++)
                {
                    int repeat = bytesToMatchLength / (currentPos - i);
                    int remaining = bytesToMatchLength % (currentPos - i);
                    byte[] tempArray = new byte[(currentPos - i) * repeat + (remaining)];
                    int m = 0;
                    int destPos;
                    for (; m < repeat; m++)
                    {
                        destPos = m * (currentPos - i);
                        Array.Copy(inputData, i, tempArray, destPos, currentPos - i);
                    }
                    destPos = m * (currentPos - i);
                    Array.Copy(inputData, i, tempArray, destPos, remaining);
                    if (tempArray.SequenceEqual(bytesToMatch))
                    {
                        count = (byte)bytesToMatchLength;
                        pos = (byte)(currentPos - i);
                    }

                }
            }
            if(pos > 0 && count > 0)
            {
                return new Offset(pos, count);
            }
            return null;
        }
        public int Compress(string inputFilename)
        {
            inputData = File.ReadAllBytes(inputFilename);
            inputDataSize = inputData.Length;
            int outputData = Compress();
            return outputData;


        }
        public int Compress()
        {
            BitList output = new BitList();

            Offset offset;
            for (int i = 0; i < inputDataSize;)
            {
                offset = GetOffset(i);
                if (offset != null)
                {
                    output.Write(true);
                    output.Write((byte)(offset.pos >> 4));
                    output.Write((byte)((offset.pos & 0xf) << 4| offset.count));
                    i += offset.count;
                }
                else
                {
                    output.Write(false);
                    output.Write(inputData[i]);
                    i++;
                }
            }
            return output.GetBytes();
        }

    }
}


