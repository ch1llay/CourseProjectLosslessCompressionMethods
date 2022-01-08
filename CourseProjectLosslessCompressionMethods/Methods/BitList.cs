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
            bit = 1;
            sum = 0;
            countByte = 0;
        }

        public void Write(bool c)
        {
            if (c)
            {
                sum |= bit;
            }
            if (bit < 128)
            {
                bit <<= 1;
            }
            else
            {
                countByte++;
                sum = 0;
                bit = 1;
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
