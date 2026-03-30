using System;
using System.IO;
using System.IO.Format;

namespace FormatUSBCommand
{
    internal class Program
    {
        public static void FormatDrive(string driveLetter)
        {
            if (!DriveInfo.GetDrives().Any(drive => drive.Name == driveLetter))
            {
                Console.WriteLine("Drive not found.");
                return;
            }

            DriveInfo drive = new DriveInfo(driveLetter);

            if (!drive.IsReady)
            {
                Console.WriteLine("Drive is not ready.");
                return;
            }

            Console.WriteLine($"Formatting drive {driveLetter} will erase all data. Are you sure? (y/n)");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                try
                {
                    using (DriveFormatter formatter = DriveFormatter.Create(drive))
                    {
                        formatter.Format(FileSystemFormat.NTFS, "MyFlashDrive");
                    }
                    Console.WriteLine($"Drive {driveLetter} formatted successfully.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error formatting drive: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Formatting canceled.");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the drive letter to format (e.g., E): ");
            string driveLetter = Console.ReadLine();

            FormatDrive(driveLetter);
        }
    }
}