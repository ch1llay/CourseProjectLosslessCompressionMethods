using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods.Methods.Deflate
{
    class Deflate
    {
        byte[] inputData;
        public static long Compress(string sourceFile, string compressedFile)
        {
            using (FileStream originalFileStream = File.OpenRead(sourceFile))
            {
                using (FileStream compressedFileStream = File.Create(compressedFile))
                {
                    using (DeflateStream compressionStream = new DeflateStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }

                return new FileInfo(compressedFile).Length;
            }
        }
    }
}
