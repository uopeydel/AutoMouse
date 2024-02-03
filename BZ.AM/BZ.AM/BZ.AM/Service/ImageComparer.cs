using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace BZ.AM.Service
{
    public class ImageComparer
    {
         
        private static byte[] GetImageBytes(Image image)
        {
            // Convert the image to a bitmap
            Bitmap bitmap = new Bitmap(image);

            // Lock the bitmap's bits
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // Get the image's byte array
            byte[] imageBytes = new byte[bitmapData.Stride * bitmapData.Height];
            Marshal.Copy(bitmapData.Scan0, imageBytes, 0, imageBytes.Length);

            // Unlock the bitmap's bits
            bitmap.UnlockBits(bitmapData);

            return imageBytes;
        }
        public static bool IsLikely(string base64_1, string base64_2)
        {
            // Convert the images to byte arrays
            byte[] image1Bytes = ConvertFromBase64String(base64_1);
            byte[] image2Bytes = ConvertFromBase64String(base64_2);

            // Calculate the distance between the image byte arrays
            double distance = CalculateDistance(image1Bytes, image2Bytes);

            // Determine if the images are likely or close
            //return distance < 0.1;
            return distance < 1;
        }

        public static bool IsLikely(Bitmap pictureBox1, Bitmap pictureBox2)
        {
            // Convert the images to byte arrays
            byte[] image1Bytes = GetImageBytes(pictureBox1);
            byte[] image2Bytes = GetImageBytes(pictureBox2);

            // Calculate the distance between the image byte arrays
            double distance = CalculateDistance(image1Bytes, image2Bytes);

            // Determine if the images are likely or close
            //return distance < 0.1;
            return distance < 1;
        }
        public static byte[] GetImageBytes(Bitmap bitmap)
        {
            // Lock the bitmap's bits
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // Get the image's byte array
            byte[] imageBytes = new byte[bitmapData.Stride * bitmapData.Height];
            Marshal.Copy(bitmapData.Scan0, imageBytes, 0, imageBytes.Length);

            // Unlock the bitmap's bits
            bitmap.UnlockBits(bitmapData);

            return imageBytes;
        }

         public static byte[] ConvertFromBase64String(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                throw new ArgumentNullException("base64String");
            }

            return Convert.FromBase64String(base64String);
        }
        private static double CalculateDistance(byte[] image1Bytes, byte[] image2Bytes)
        {
            // Check if the image byte arrays are of equal length
            if (image1Bytes.Length != image2Bytes.Length)
            {
                //return diff
                return 0.0000199;
            }

            // Calculate the distance between the image byte arrays
            double distance = 0;
            for (int i = 0; i < image1Bytes.Length; i++)
            {
                distance += Math.Pow(image1Bytes[i] - image2Bytes[i], 2);
            }

            distance = Math.Sqrt(distance);
            return distance;
        }

        public static Bitmap ConvertByteToBitmap(byte[] bytes)
        { 
            // Create a MemoryStream from the decoded bytes
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                // Create a Bitmap object from the MemoryStream
                Bitmap bitmap = (Bitmap)Image.FromStream(memoryStream);
                return bitmap;
            }
        }
    }
} 
