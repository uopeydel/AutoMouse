using AutoCursorMoveStep.Models;
using AutoCursorMoveStep.Service;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using static AutoCursorMoveStep.Service.MouseOperationsService;
using System.Text;
using Timer = System.Windows.Forms.Timer;
using System.Media;

namespace AutoCursorMoveStep
{
    public partial class Form1 : Form
    {
        #region Hook
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Constants needed for the hook
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_A = 0x41;
        private const int VK_S = 83;
        private const int VK_SPACE = 32;

        // Hook handle
        private IntPtr hookId = IntPtr.Zero;

        // Declare the hook callback as a class member to prevent it from being garbage collected
        private LowLevelKeyboardProc hookCallback;

        // Import the necessary functions from user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }



        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == VK_S)
                {
                    MoveCursorService.isStop = true;
                }

                if (vkCode == VK_A)
                {
                    LeftMouseClick();
                }

                if (vkCode == VK_SPACE)
                {
                    MessageBox.Show($"X {Cursor.Position.X} :  Y{Cursor.Position.Y}  ");
                }

            }
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }
        #endregion



        public Form1()
        {
            InitializeComponent();
            AppendLogs("Start");

            #region Hook
            hookCallback = HookCallback;
            // Start the keyboard hook
            hookId = SetHook(hookCallback);
            //// Stop the keyboard hook
            //UnhookWindowsHookEx(hookId);
            #endregion


            AddRow();

            gvAutoList.CellContentClick += new DataGridViewCellEventHandler(gvAutoList_CellContentClick);

            AppendLogs($"Load");
            LoadToGv();
            SystemSounds.Beep.Play();
        }

        private void gvAutoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Check if the clicked cell is a button cell
            if (e.ColumnIndex == (int)GVHeaderPosition.Fetch)
            {
                if (e.RowIndex >= gvDatas.Count)
                {
                    return;
                }
                // Get the data from the row that the button was clicked in
                //DataGridViewRow row = gvAutoList.Rows[e.RowIndex];

                var item = gvDatas[e.RowIndex];


                var wid = (int)(item.BotRightX - item.TopLeftX);
                var hei = (int)(item.BotRightY - item.TopLeftY);
                item.rectangle = null;
                if (wid > 0 && hei > 0)
                {
                    Rectangle captureArea = new Rectangle((int)item.TopLeftX, (int)item.TopLeftY, wid, hei);
                    CaptureScreen(captureArea);
                    //DataGridViewImageColumn imageCol = new DataGridViewImageColumn(); 
                    gvAutoList.Rows[e.RowIndex].Cells[(int)GVHeaderPosition.ReCheck].Value = _croppedBitmap;

                }

            }

            if (e.ColumnIndex == (int)GVHeaderPosition.IsEqual)
            {
                if (e.RowIndex >= gvDatas.Count)
                {
                    return;
                }
                IsEqual(e.RowIndex);

            }
        }


        private bool IsEqual(int gvRowIndex)
        {
            bool result = false;
            var v1 = gvAutoList.Rows[gvRowIndex].Cells[(int)GVHeaderPosition.Position].Value;
            var v2 = gvAutoList.Rows[gvRowIndex].Cells[(int)GVHeaderPosition.ReCheck].Value;
            if (v1 != null && v2 != null)
            {
                var bm1 = (Bitmap)v1;
                var bm2 = (Bitmap)v2;
                result = ImageComparer.IsLikely(bm1, bm2);
                gvAutoList.Rows[gvRowIndex].Cells[(int)GVHeaderPosition.Equal].Value = result ? "Equal" : "Diff";
            }
            return result;
        }



        private static List<ItemAuto> gvDatas;
        private void FetchImageFromScreen(object? sender, EventArgs e)
        {

        }
        public enum GVHeaderPosition
        {
            Position = 0,
            TopLeftX = 1,
            TopLeftY = 2,
            BotRightX = 3,
            BotRightY = 4,
            Interval = 5,
            Active = 6,


            ReCheck = 7,
            Fetch = 8,
            Equal = 9,
            IsEqual = 10
        }
        private List<ItemAuto> ReadGV()
        {
            var results = new List<ItemAuto>();
            var isNull = gvAutoList?.Rows == null;
            if (isNull)
            {
                return results;
            }
            for (int i = 0; i < gvAutoList.Rows.Count; i++)
            {
                var item = new ItemAuto();


                var TopLeftXTxt = gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.TopLeftX].Value?.ToString();
                decimal.TryParse(TopLeftXTxt, out decimal TopLeftX);
                item.TopLeftX = TopLeftX;


                var TopLeftYTxt = gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.TopLeftY].Value?.ToString();
                decimal.TryParse(TopLeftYTxt, out decimal TopLeftY);
                item.TopLeftY = TopLeftY;


                var BotRightXTxt = gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.BotRightX].Value?.ToString();
                decimal.TryParse(BotRightXTxt, out decimal BotRightX);
                item.BotRightX = BotRightX;


                var BotRightYTxt = gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.BotRightY].Value?.ToString();
                decimal.TryParse(BotRightYTxt, out decimal BotRightY);
                item.BotRightY = BotRightY;



                var IntervalTxt = gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.Interval].Value?.ToString();
                decimal.TryParse(IntervalTxt, out decimal Interval);
                item.Interval = Interval;



                var boolTxt = gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.Active].Value?.ToString();
                bool.TryParse(boolTxt, out bool Active);
                item.Active = Active;

                var wid = (int)(item.BotRightX - item.TopLeftX);
                var hei = (int)(item.BotRightY - item.TopLeftY);
                Rectangle captureArea = new Rectangle((int)item.TopLeftX, (int)item.TopLeftY, wid, hei);
                item.rectangle = captureArea;
                //AppendLogs($"Clear rectangle");
                //if (wid > 0 && hei > 0 && IsStart)
                //{
                //    AppendLogs($"Is Start Chck Capture screen"); 
                //    CaptureScreen(captureArea);
                //    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                //    gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.Position].Value = _croppedBitmap;

                //    var v1 = gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.Position].Value;
                //    var v2 = gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.ReCheck].Value;
                //    if (v1 != null && v2 != null)
                //    {
                //        var bm1 = (Bitmap)v1;
                //        var bm2 = (Bitmap)v2;
                //        item.IsBitMapEqual = true;// ImageComparer.IsLikely(bm1, bm2);
                //        AppendLogs($"Is Likely {item.IsBitMapEqual}");
                //    }
                //}
                if (item.Active == true)
                {
                    results.Add(item);
                }
            }
            gvDatas = results;
            return results;
        }



        private static Bitmap _croppedBitmap;
        private static Bitmap _bmSmall;
        private void CaptureScreen(Rectangle captureArea)
        {
            //Bitmap result;
            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(Point.Empty, Point.Empty, bitmap.Size);
                }
                //Bitmap croppedBitmap = bitmap.Clone(captureArea, bitmap.PixelFormat);
                //result = croppedBitmap; 
                _croppedBitmap = CropBitmap(bitmap, captureArea);
            }
            //return result;
        }
        private Bitmap CropBitmap(Bitmap source, Rectangle cropArea)
        {
            // Check if the crop area is within the bounds of the source bitmap
            if (!cropArea.IntersectsWith(GetBitmapBounds(source)))
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
        private Rectangle GetBitmapBounds(Bitmap bitmap)
        {
            Rectangle bounds = Rectangle.Empty;
            bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            return bounds;
        }
        private void AddRow()
        {
            if (gvAutoList == null)
            {
                gvAutoList = new DataGridView();
            }
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            gvAutoList.Rows.Add();
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AppendLogs($"Click Add Row");
            AddRow();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            AppendLogs($"Click Start");
            if (IsStart == false)
            {
                ReadGV();
                var isRoundCorrect = int.TryParse(txtRoundNumber.Text, out int roundInt);
                if (isRoundCorrect == false || roundInt < 1)
                {
                    AppendLogs($"Round incorrect {txtRoundNumber.Text}");
                    return;
                }
                round = roundInt;

                Application.DoEvents();
                IsStart = true;
                cursorTimer = new Timer();
                cursorTimer.Interval = 100;
                cursorTimer.Tick += (sender, e) => MouseClickAutoTimmer();
                cursorTimer.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AppendLogs($"Click Stop");
        }

        #region Save data
        private SQLiteConnection connection;

        private void SaveToSqlLite()
        {
            connection = new SQLiteConnection("Data Source=MyDatabase.db");

            // Open the connection to the SQLite database
            connection.Open();


            // DROP a   table in the SQLite database
            string dropTableQuery = "DROP TABLE  IF  EXISTS ItemAuto";
            using (SQLiteCommand command = new SQLiteCommand(dropTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            // Create a new table in the SQLite database
            string createTableQuery = "CREATE TABLE IF NOT EXISTS ItemAuto (TopLeftX DECIMAL(18,2), TopLeftY DECIMAL(18,2), BotRightX DECIMAL(18,2), BotRightY DECIMAL(18,2), Interval DECIMAL(18,2), Active INTEGER)";
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
            ReadGV();
            // Insert some data into the SQLite database
            string insertDataQuery = "INSERT INTO ItemAuto (TopLeftX, TopLeftY, BotRightX, BotRightY, Interval, Active) VALUES (@TopLeftX, @TopLeftY, @BotRightX, @BotRightY, @Interval, @Active)";
            using (SQLiteCommand command = new SQLiteCommand(insertDataQuery, connection))
            {
                gvDatas.ForEach(f =>
                {
                    command.Parameters.AddWithValue("@TopLeftX", f.TopLeftX);
                    command.Parameters.AddWithValue("@TopLeftY", f.TopLeftY);
                    command.Parameters.AddWithValue("@BotRightX", f.BotRightX);
                    command.Parameters.AddWithValue("@BotRightY", f.BotRightY);
                    command.Parameters.AddWithValue("@Interval", f.Interval);
                    command.Parameters.AddWithValue("@Active", f.Active == true ? "1" : "0");
                    command.ExecuteNonQuery();
                });

            }

        }
        private void ClearSqlLite()
        {
            connection = new SQLiteConnection("Data Source=MyDatabase.db");

            // Open the connection to the SQLite database
            connection.Open();

            // DROP a   table in the SQLite database
            string createTableQuery = "DROP TABLE  IF  EXISTS ItemAuto";
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

        }
        private void LoadToGv()
        {
            connection = new SQLiteConnection("Data Source=MyDatabase.db");

            // Open the connection to the SQLite database
            connection.Open();

            // Load the data from the SQLite database into the DataGridView
            string loadDataQuery = "SELECT * FROM ItemAuto";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(loadDataQuery, connection))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                gvAutoList.Rows.Clear();
                gvAutoList.Refresh();

                var row = dataSet.Tables[0].Rows;
                for (int i = 0; i < row.Count; i++)
                {
                    AddRow();
                    gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.TopLeftX].Value = row[i].Field<decimal>("TopLeftX").ToString();
                    gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.TopLeftY].Value = row[i].Field<decimal>("TopLeftY").ToString();
                    gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.BotRightX].Value = row[i].Field<decimal>("BotRightX").ToString();
                    gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.BotRightY].Value = row[i].Field<decimal>("BotRightY").ToString();
                    gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.Interval].Value = row[i].Field<decimal>("Interval").ToString();
                    var dtActive = row[i].Field<long>("Active");
                    gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.Active].Value = dtActive == 1 ? true : false;
                }
            }
            ReadGV();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppendLogs($"Save");
            SaveToSqlLite();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            AppendLogs($"Load");
            LoadToGv();
        }

        private void btnTruncate_Click(object sender, EventArgs e)
        {
            AppendLogs($"Clear");
            ClearSqlLite();
        }

        #endregion




        #region Teleport Cursor Click
        private static Timer cursorTimer = new Timer();
        private int timerMilisecCountForStepProcess = 0;
        private int msWaitRecheck = 0;
        private static int round { get; set; } = 0;
        private static int processNumber = 0;
        public static bool IsStart = false;
        private static int roundRecheck = 0;

        private void MouseClickAutoTimmer()
        {
            timerMilisecCountForStepProcess += cursorTimer.Interval;

            //System.Threading.Thread.Sleep(timmerClickAuto.Interval);
            try
            {
                if (round <= 0)
                {
                    cursorTimer.Stop();
                    SystemSounds.Hand.Play();
                    SystemSounds.Asterisk.Play();
                    SystemSounds.Exclamation.Play();
                    AppendLogs($"Round end ");
                    MessageBox.Show($"Round end ");
                    round = 0;
                    IsStart = false;
                    processNumber = 0;
                    roundRecheck = 0;
                    timerMilisecCountForStepProcess = msWaitRecheck = 0;
                    return;
                }

                // AppendLogs($"Round = {round} : Process No = {processNumber} : IsStop = {MoveCursorService.isStop}");
                if (processNumber >= gvDatas.Count)
                {
                    processNumber = 0;
                    round--;
                    timerMilisecCountForStepProcess = msWaitRecheck = 0;
                    roundRecheck = 0;
                    return;
                }

                var isNotActive = (gvDatas[processNumber].Active == true);
                if (!isNotActive)
                {
                    cursorTimer.Stop();
                    AppendLogs($"Found unactive job Process No = {processNumber} ");
                    MessageBox.Show($"Found unactive job Process No = {processNumber} ");
                    round = 0;
                    IsStart = false;
                    processNumber = 0;
                    roundRecheck = 0;
                    timerMilisecCountForStepProcess = msWaitRecheck = 0;
                    return;
                }

                if (timerMilisecCountForStepProcess < convertSecondToMilisecond(gvDatas[processNumber].Interval.Value))
                {
                    //Continue waiting
                    return;
                }

                int limitRoundCheck = 10;
                if (roundRecheck > 0 && roundRecheck <= limitRoundCheck)
                {
                    if (timerMilisecCountForStepProcess > msWaitRecheck)
                    {
                        goto RECHECKEQUAL;
                    }

                    //Continue waiting round recheck
                    return;
                }

                
                roundRecheck = 1;
            RECHECKEQUAL:
                if (roundRecheck > limitRoundCheck)
                {
                    //if (processNumber == 2)
                    //{
                    //    System.Threading.Thread.Sleep(3000);
                    //    limitRoundCheck = 10;
                    //    goto RECHECKEQUAL;
                    //}
                    cursorTimer.Stop();
                    AppendLogs($"Unable to check image same = {processNumber} ");
                    MessageBox.Show($"Unable to check image same = {processNumber} ");
                    round = 0;
                    IsStart = false;
                    processNumber = 0;
                    roundRecheck = 0;
                    timerMilisecCountForStepProcess = msWaitRecheck = 0;
                    return;
                }

                var isEqual = SearchEqualImageInScreen(processNumber);// gvDatas[processNumber].IsBitMapEqual;// true;// 
                AppendLogs($"Round = {round} : Process No = {processNumber} : Is Equal :X {isEqual}");
                if (isEqual == false)
                { 
                    msWaitRecheck = GenerateRandomMillisecond(4, 6) + timerMilisecCountForStepProcess;
                    
                    AppendLogs($"Round = {round} : Process No = {processNumber} : WaitRound {roundRecheck} | Wait Time {msWaitRecheck}");

                    roundRecheck++;
                    return;
                }
                var mousePoint = GetRandomPointInRectangle(gvDatas[processNumber].rectangle.Value);
                Cursor.Position = mousePoint;
                AppendLogs($"Mouse point :X {mousePoint.X} , Y {mousePoint.Y}");
                LeftMouseClick();

                processNumber++;
                roundRecheck = 0;
                timerMilisecCountForStepProcess = msWaitRecheck = 0;
            }
            catch (Exception ex)
            {
                cursorTimer.Stop();
                AppendLogs($"ex {ex.Message}");
                MessageBox.Show($"ex {ex.Message}");
            }

        }

        private bool SearchEqualImageInScreen(int processNumber)
        {
            Rectangle captureAreaForSearch = new Rectangle((int)0, (int)0, (int)Screen.PrimaryScreen.Bounds.Width, (int)Screen.PrimaryScreen.Bounds.Height);
            CaptureScreen(captureAreaForSearch);
            var screenShort = _croppedBitmap;

            _bmSmall = (Bitmap)gvAutoList.Rows[processNumber].Cells[(int)GVHeaderPosition.ReCheck].Value;

            var rectWidth = gvDatas[processNumber].BotRightX - gvDatas[processNumber].TopLeftX;
            var rectHeight = gvDatas[processNumber].BotRightY - gvDatas[processNumber].TopLeftY;
            Point positionResult = FindBitmapSmallPosition(screenShort, _bmSmall);
            
            if (positionResult.X != -1 && positionResult.Y != -1)
            {
                AppendLogs("bitmapSmall is found at position (" + positionResult.X + ", " + positionResult.Y + ")");

                Rectangle captureAreaFound = new Rectangle((int)positionResult.X, (int)positionResult.Y, (int)rectWidth, (int)rectHeight);
                CaptureScreen(captureAreaFound);
                gvAutoList.Rows[processNumber].Cells[(int)GVHeaderPosition.Position].Value = _croppedBitmap;
                return true;
            }
            else
            {
                Rectangle captureAreaFound = new Rectangle((int)gvDatas[processNumber].TopLeftX, (int)gvDatas[processNumber].TopLeftY, (int)rectWidth, (int)rectHeight);
                CaptureScreen(captureAreaFound);
                gvAutoList.Rows[processNumber].Cells[(int)GVHeaderPosition.Position].Value = _croppedBitmap;
                SystemSounds.Question.Play();
                AppendLogs("bitmapSmall is not found in bitmapBig");
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

        private static int convertSecondToMilisecond(decimal seconds)
        {
            // TimeSpan.FromSeconds(seconds);
            int milliseconds = (int)(seconds * 1000);
            return milliseconds;
        }

        public static Point GetRandomPointInRectangle(Rectangle rectangle)
        {
            Random random = new Random();
            int x = random.Next(rectangle.Left, rectangle.Right);
            int y = random.Next(rectangle.Top, rectangle.Bottom);

            Point randomPoint = new Point(x, y);
            return randomPoint;
        }

        public void AppendLogs(string logs)
        {

            if (string.IsNullOrEmpty(logs))
            {
                return;
            }

            logs = DateTime.Now.ToString("HH:mm:sss | ") + logs;
            lbLog.Items.Add(logs);
        }
        #endregion
    }
}