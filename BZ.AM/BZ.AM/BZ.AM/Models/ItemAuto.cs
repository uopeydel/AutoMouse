using System.Drawing;

namespace BZ.AM.Models
{
	public class ItemAuto
	{
		public string CurrentImageBase64 { get; set; }
		public string CompareImageBase64 { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
        public int Height { get; set; }
        public int Interval { get; set; }

		public int SkipToStepIfImageNotFound { get; set; }
        public bool Active { get; set; }

		 
	}
}
