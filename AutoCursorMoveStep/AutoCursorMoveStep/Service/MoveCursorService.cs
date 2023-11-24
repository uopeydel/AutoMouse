using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AutoCursorMoveStep.Service
{
    public class MoveCursorService
    {
        private static Timer cursorTimer = new Timer();
        private static int totalTimeInSeconds = 20; 
        public static bool isStop = false;
        private static int steps = 0;
        public static double stepX = 0;
        public static double stepY = 0;
        private static double dx = 0;
        private static double dy = 0;
        private static int radius = 1;
        public static double distance { get; set; }
       
        public static Point destinationPoint { get; set; }

        private static double FixAbsDirection(double resultDir)
        {

            if (resultDir > 0 && resultDir < 1 && distance >= radius)
            {
                resultDir = 1;
            }
            if (resultDir < 0 && resultDir > -1 && distance >= radius)
            {
                resultDir = -1;
            }
            return resultDir;
        }
        private static double calDirectionX()
        {
            var resultDir = (destinationPoint.X - Cursor.Position.X) / (double)steps;
            resultDir = FixAbsDirection(resultDir);
            return resultDir;
        }

        private static double calDirectionY()
        {
            var resultDir = (destinationPoint.Y - Cursor.Position.Y) / (double)steps;
            resultDir = FixAbsDirection(resultDir);
            return resultDir;
        }

        private static bool IsInit = true;
        public static void Init()
        {
            if (IsInit)
            {
                CalculateDistance();
                isStop = false;
                IsInit = false;
                cursorTimer = new Timer();
                // Calculate the step size for smoother movement
                //steps = (totalTimeInSeconds * 1000) / cursorTimer.Interval;
                //steps = (int)distance * 1000;
                //cursorTimer.Interval = 1000 / steps; // Adjust the timer interval based on the number of steps
                cursorTimer.Interval = (int)distance;
                cursorTimer.Tick += (sender, e) => MoveCursorTick(sender, e);
                cursorTimer.Start();
            }
        }
        public static void MoveCursor(Point _destinationPoint)
        {
            destinationPoint = _destinationPoint;
            Init();


            while (!IsCursorInRectangle())
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(cursorTimer.Interval); 
            }

            cursorTimer.Stop();
            isStop = true;
            IsInit = true; 
        }

        private static void MoveCursorTick(object sender, EventArgs e)
        {
            bool isCursorInCircle = IsCursorInRectangle();
            if (isCursorInCircle || isStop)
            {
                IsInit = true;
                isStop = true;
                cursorTimer.Stop();
                return;
            }
            // Check if the cursor has reached the destination
            if (Cursor.Position.X == destinationPoint.X && Cursor.Position.Y == destinationPoint.Y)
            {
                IsInit = true;
                isStop = true;
                cursorTimer.Stop();
                return;
            }

            stepX = calDirectionX();
            stepY = calDirectionY();
            // Move the cursor by the calculated step
            Cursor.Position = new Point((int)(Cursor.Position.X + stepX), (int)(Cursor.Position.Y + stepY)); 
        }

        private static bool IsCursorInRectangle()
        {
            CalculateDistance();

            // Check if the distance is less than or equal to the radius
            return distance <= radius;
        }

        private static void CalculateDistance()
        {
            // Get the cursor position
            Point cursorPosition = Cursor.Position;

            // Calculate the distance between the cursor position and the center point
            dx = Math.Pow(cursorPosition.X - destinationPoint.X, 2);
            dy = Math.Pow(cursorPosition.Y - destinationPoint.Y, 2);
            distance = Math.Sqrt(dx + dy); 
        }
    }
}
