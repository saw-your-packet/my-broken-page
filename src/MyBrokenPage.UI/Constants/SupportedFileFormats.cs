using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBrokenPage.UI.Constants
{
    public class SupportedFileFormats
    {
        public static List<byte[]> FileSignatures { get; } = new List<byte[]>
        {
            StringWithHexValuesToByteArray(0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A), //PNG
            StringWithHexValuesToByteArray(0xFF, 0xD8) // JPG
        };

        public static List<string> Extensions { get; } = new List<string>
        {
            ".jpg",
            ".jpeg",
            ".png"
        };

        private static byte[] StringWithHexValuesToByteArray(params int[] hexValues)
        {
            var byteArray = hexValues.Select(hexValue => Convert.ToByte(hexValue))
                                     .ToArray();

            return byteArray;
        }
    }
}
