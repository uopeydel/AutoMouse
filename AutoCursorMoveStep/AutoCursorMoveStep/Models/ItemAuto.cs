using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCursorMoveStep.Models
{
    public class ItemAuto
    { 
        public PictureBox? Position { get; set; }
        public decimal? TopLeftX { get; set; }
        public decimal? TopLeftY { get; set; }
        public decimal? BotRightX { get; set; }
        public decimal? BotRightY { get; set; }
        public decimal? Interval { get; set; }
        public bool? Active { get; set; }




        public Rectangle? rectangle { get; set; }
    }
}
