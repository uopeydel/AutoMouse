using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DetectSameImageInScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static Bitmap _croppedBitmap;
        private static Bitmap _bmSmall;
        private  void CaptureScreen(Rectangle captureArea)
        {
            //Bitmap result;
            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(Point.Empty, Point.Empty, bitmap.Size);
                }

                //_croppedBitmap = bitmap.Clone(captureArea, bitmap.PixelFormat); // Clone make error out of memory
                _croppedBitmap = CropBitmap(bitmap, captureArea);
            }
            //return result;
        }

        public Rectangle GetBitmapBounds(Bitmap bitmap)
        {
            Rectangle bounds = Rectangle.Empty;
            bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            return bounds;
        }
        public Bitmap CropBitmap(Bitmap source, Rectangle cropArea)
        {
            // Check if the crop area is within the bounds of the source bitmap
            if (!cropArea.IntersectsWith( GetBitmapBounds (source ))) 
            {
                throw new ArgumentException("Crop area is outside the bounds of the source bitmap");
            }

            // Create a new bitmap with the same dimensions as the crop area
            Bitmap croppedBitmap = new Bitmap(cropArea.Width, cropArea.Height);

            // Use Graphics to draw the cropped portion of the source bitmap onto the new bitmap
            using (Graphics g = Graphics.FromImage(croppedBitmap))
            {
                g.DrawImage(source, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);
            }

            // Return the cropped bitmap
            return croppedBitmap;
        }
        private void btnCropInitial_Click(object sender, EventArgs e)
        {
            if (1 >= nBaseHeigh.Value || 1 >= nBaseWidth.Value)
            {
                return;
            }

            Rectangle captureArea = new Rectangle((int)nBaseX.Value, (int)nBaseY.Value, (int)nBaseWidth.Value, (int)nBaseHeigh.Value);
            CaptureScreen(captureArea);
            pbBase.Image = _croppedBitmap;
            _bmSmall = _croppedBitmap;
            pbBase.Refresh();
            //_croppedBitmap.Dispose();
            //_croppedBitmap = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEqualImageInScreen();
        }

        private bool SearchEqualImageInScreen()
        {
            Rectangle captureAreaForSearch = new Rectangle((int)0, (int)0, (int)Screen.PrimaryScreen.Bounds.Width, (int)Screen.PrimaryScreen.Bounds.Height);
            CaptureScreen(captureAreaForSearch);
            pbScreenShort.Image = _croppedBitmap;
            pbScreenShort.Refresh();


            Point position = FindBitmapSmallPosition(_croppedBitmap, _bmSmall);
            //_croppedBitmap.Dispose();
            //_croppedBitmap = null;


            if (position.X != -1 && position.Y != -1)
            {
                MessageBox.Show("bitmapSmall is found at position (" + position.X + ", " + position.Y + ")");
                nFoundX.Value = position.X;
                nFoundY.Value = position.Y;

                nFoundHeigh.Value = pbBase.Image.Height;
                nFoundWidth.Value = pbBase.Image.Width;


                Rectangle captureAreaFound = new Rectangle((int)nFoundX.Value, (int)nFoundY.Value, (int)nFoundWidth.Value + 500, (int)nFoundHeigh.Value + 500);
                CaptureScreen(captureAreaFound);
                pbFound.Image = _croppedBitmap;
                pbFound.Refresh();
                //_croppedBitmap.Dispose();
                //_croppedBitmap = null;
                return true;
            }
            else
            {
                MessageBox.Show("bitmapSmall is not found in bitmapBig");
                return false;
            }
        }

        public static Point FindBitmapSmallPosition(Bitmap bitmapBig, Bitmap bitmapSmall)
        {
            // Check if bitmapSmall is smaller than bitmapBig
            if (bitmapSmall.Width > bitmapBig.Width || bitmapSmall.Height > bitmapBig.Height)
            {
                throw new ArgumentException("bitmapSmall must be smaller than bitmapBig");
            }

            // Iterate through each pixel of bitmapBig
            for (int x = 0; x < bitmapBig.Width - bitmapSmall.Width; x++)
            {
                for (int y = 0; y < bitmapBig.Height - bitmapSmall.Height; y++)
                {
                    // Check if the current pixel in bitmapBig matches the corresponding pixel in bitmapSmall
                    bool matches = true;
                    for (int i = 0; i < bitmapSmall.Width; i++)
                    {
                        for (int j = 0; j < bitmapSmall.Height; j++)
                        {
                            Color pixelBig = bitmapBig.GetPixel(x + i, y + j);
                            Color pixelSmall = bitmapSmall.GetPixel(i, j);

                            if (pixelBig != pixelSmall)
                            {
                                matches = false;
                                break;
                            }
                        }

                        if (!matches)
                        {
                            break;
                        }
                    }

                    // If all pixels match, then bitmapSmall is found at the current position
                    if (matches)
                    {
                        return new Point(x, y);
                    }
                }
            }
            // If bitmapSmall is not found, return (-1, -1)
            return new Point(-1, -1);
        }

    }
}