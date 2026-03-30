using System.Diagnostics;

namespace TrimVideo
{
    class Program
    {
        static void Main()
        {
            string inputFilePath = @"C:\Users\lapad\Downloads\1807\1807.mp4";
            string outputFilePath = @"C:\Users\lapad\Downloads\1807\1807_trimmed_master_short.mp4";
            TimeSpan startTime = TimeSpan.FromSeconds(6870);
            TimeSpan duration = TimeSpan.FromSeconds(230); // 10 minutes (from 110 to 120 minutes)

            // Command to trim the video using ffmpeg
            string ffmpegArgs = $"-i \"{inputFilePath}\" -ss {startTime} -t {duration} -c:v copy -c:a copy \"{outputFilePath}\"";

            // Execute the ffmpeg command
            ExecuteCommand("ffmpeg", ffmpegArgs);

            Console.WriteLine("Video trimming complete.");
            Console.ReadKey();
        }

        static void ExecuteCommand(string command, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo(command, arguments)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(output))
                    Console.WriteLine("Output: " + output);

                if (!string.IsNullOrEmpty(error))
                    Console.WriteLine("Error: " + error);
            }
        }
    }


}

//using System;
//using System.Diagnostics;
