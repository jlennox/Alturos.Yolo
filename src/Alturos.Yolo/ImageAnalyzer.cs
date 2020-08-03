using System;
using System.Collections.Generic;
using System.Text;

namespace Alturos.Yolo
{
    public class ImageAnalyzer
    {
        private static readonly Dictionary<string, byte[]> _imageFormats = new Dictionary<string, byte[]>
        {
            { "bmp", Encoding.ASCII.GetBytes("BM") },
            { "png", new byte[] { 137, 80, 78, 71 } },
            { "jpeg", new byte[] { 255, 216, 255 } }
        };

        public bool IsValidImageFormat(Span<byte> imageData)
        {
            if (imageData == null)
            {
                return false;
            }

            if (imageData.Length <= 3)
            {
                return false;
            }

            foreach (var imageFormat in ImageAnalyzer._imageFormats)
            {
                if (imageData.StartsWith(imageFormat.Value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
