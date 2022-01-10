using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods.Methods
{
    public class BitList
    {
        //List<byte> bits = new List<byte>();
        int countByte;
        byte bit;
        byte sum;

        public BitList()
        {
            bit = 128;
            sum = 0;
            countByte = 0;
        }

        public void Write(bool c)
        {
            if (c)
            {
                sum |= bit;
            }
            if (bit > 0)
            {
                bit >>= 1;
            }
            if(bit == 0)
            {
                countByte++;
                sum = 0;
                bit = 128;
            }

        }

        public void Write(byte n, int countBit= 7)
        {
            for (int i = 0; i <= countBit; i++)
            {
                Write((n >> i & 1) > 0 ? true : false);
            }
        }
        public int GetBytes()
        {
            if (sum > 0)
            {
                countByte++;
            }
            
            return countByte;
        }
    }
}
