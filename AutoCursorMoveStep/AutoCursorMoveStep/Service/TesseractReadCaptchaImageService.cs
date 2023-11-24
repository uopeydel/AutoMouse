using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Tesseract;

namespace AutoCursorMoveStep.Service
{
    public  class TesseractReadCaptchaImageService
    {
        public static string ReadCaptchaImage(string imagePath)
        { 
            try
            {
                // Load the captcha image
                Bitmap captchaImage = new Bitmap(imagePath);

                // Create a Tesseract OCR engine instance
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    // Set the page segmentation mode to single character
                    engine.SetVariable("tessedit_pageseg_mode", "7");

                    // Set the image to be recognized and Recognize the text from the image
                    var result = engine.Process(captchaImage);
                     
                    // Return the recognized text
                    return result.GetText();
                }
            }
            catch (Exception e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
                return "";
            }
        }
    }
}
