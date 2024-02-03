using System.Runtime.InteropServices;

namespace BZ.AM.Service
{
	public class MouseOperationsService
	{
		[Flags]
		public enum MouseEventFlags
		{
			LeftDown = 0x00000002,
			LeftUp = 0x00000004,
			MiddleDown = 0x00000020,
			MiddleUp = 0x00000040,
			Move = 0x00000001,
			Absolute = 0x00008000,
			RightDown = 0x00000008,
			RightUp = 0x00000010,
			MOUSEEVENTF_WHEEL = 0x0800
		}

		[DllImport("user32.dll", EntryPoint = "SetCursorPos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetCursorPos(int x, int y);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetCursorPos(out MousePoint lpMousePoint);

		[DllImport("user32.dll")]
		private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

		public static void SetCursorPosition(int x, int y)
		{
			SetCursorPos(x, y);
		}

		public static void SetCursorPosition(MousePoint point)
		{
			SetCursorPos(point.X, point.Y);
		}

		public static MousePoint GetCursorPosition()
		{
			MousePoint currentMousePoint;
			var gotPoint = GetCursorPos(out currentMousePoint);
			if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
			return currentMousePoint;
		}
		 
		public static void MouseEvent(MouseEventFlags value, MousePoint point)
		{
			mouse_event
				((int)value,
				 point.X,
				 point.Y,
				 0,
				 0)
				;
		}


		[StructLayout(LayoutKind.Sequential)]
		public struct MousePoint
		{
			public int X;
			public int Y;

			public MousePoint(int x, int y)
			{
				X = x;
				Y = y;
			}
		}

		public static void LeftMouseClick(MousePoint point)
		{
			MouseEvent(MouseEventFlags.LeftDown, point);
			System.Threading.Thread.Sleep(GenerateRandomMillisecond(1, 2)); 
			MouseEvent(MouseEventFlags.LeftUp, point);
		}
		 

		public static int GenerateRandomMillisecond(int start, int end)
		{
			if (start > end)
			{
				throw new ArgumentException("Start value must be less than or equal to end value.");
			}

			Random random = new Random();
			double randomRange = (double)(end - start);
			double randomSecond = 0.0;

			while (randomSecond % 0.3 != 0)
			{
				randomSecond = random.NextDouble() * randomRange;
				randomSecond += start;
			}

			int randomMillisecond = (int)randomSecond * 1000;
			return randomMillisecond;
		}


	}
}
