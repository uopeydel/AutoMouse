using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoCursorMoveStep.Service
{
    public class ImageComparer
    {
        public static bool IsLikely(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            // Convert the images to byte arrays
            byte[] image1Bytes = GetImageBytes(pictureBox1.Image);
            byte[] image2Bytes = GetImageBytes(pictureBox2.Image);

            // Calculate the distance between the image byte arrays
            double distance = CalculateDistance(image1Bytes, image2Bytes);

            // Determine if the images are likely or close
            return distance < 0.1;
        }

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


        public static bool IsLikely(Bitmap pictureBox1, Bitmap pictureBox2 , Action<string> AppendLogs , int fource =0)
        {
            // Convert the images to byte arrays
            byte[] image1Bytes = GetImageBytes(pictureBox1);
            byte[] image2Bytes = GetImageBytes(pictureBox2);

            // Calculate the distance between the image byte arrays
            double distance = CalculateDistance(image1Bytes, image2Bytes);

            // Determine if the images are likely or close
            //return distance < 0.1;
            var result1 = distance < 1;
            if (result1 == false)
            {
                var percent = CompareByteArraysWithoutOrderAndRemoveMatches(image1Bytes, image2Bytes);
                if (fource == 0)
				{
					AppendLogs($"Percent : {percent}");
				}
                return (percent > 75);

            }
            else
            {
                return result1;
            }
        }
        public static float CompareByteArraysWithoutOrderAndRemoveMatches(byte[] arr1, byte[] arr2)
        {
            if (arr1 == null || arr2 == null)
            {
                throw new ArgumentException("Arrays must be of not null.");
            }

            List<byte> list1 = new List<byte>(arr1); // Convert arr1 to a List<byte>
            List<byte> list2 = new List<byte>(arr2);
            int numMatches = 0;

            int _i = 0;
            int _j = 0;

            try
            {
                for (int i = list1.Count - 1; i > 0; i--) // Iterate through the List
                {
                    _i = i;
                    for (int j = list2.Count - 1; j > 0; j--)
                    {
                        _j = j;
                        if (list1[i] == list2[j])
                        {
                            numMatches++;
                            list2.RemoveAt(j);
                            list1.RemoveAt(i);
                            i--;
                            j--;
                            continue;
                        }
                    }
                }
            }catch(Exception e)
            {

            };
            return (float)numMatches / (arr1.Length/* + arr2.Length*/) * 100;
        }

        private static byte[] GetImageBytes(Bitmap bitmap)
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
    }
}
