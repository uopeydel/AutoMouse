using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Management;
using System.IO; 
using System.Runtime.InteropServices;

namespace FormatUSBWindow
{
    internal class Program
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FormatVolume(string driveLetter, string volumeLabel, uint fileSystem);

        private const uint FILE_SYSTEM_SIZE_FULL_REPAIRS = 0;

        public static void FormatDrive(string driveLetter)
        {
            if (!FormatVolume(driveLetter, "", FILE_SYSTEM_SIZE_FULL_REPAIRS))
            {
                int errorCode = Marshal.GetLastWin32Error();
                Console.WriteLine($"Error formatting drive: {errorCode}");
            }
            else
            {
                Console.WriteLine($"Drive {driveLetter} formatted successfully.");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Formatting a drive can be risky. Are you sure? (y/n)");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                Console.WriteLine("Enter the drive letter to format (e.g., E): ");
                string driveLetter = "E";// Console.ReadLine();

                FormatDrive(driveLetter);
            }
            else
            {
                Console.WriteLine("Formatting canceled.");
            }
            Console.ReadKey();
        }


    }


   
     
}