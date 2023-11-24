using AutoCursorMoveStep.Models;
using AutoCursorMoveStep.Service;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using static AutoCursorMoveStep.Service.MouseOperationsService;

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

        private static void LeftMouseClick()
        {
            MouseOperationsService.MouseEvent(MouseOperationsService.MouseEventFlags.LeftDown);
            System.Threading.Thread.Sleep(GenerateRandomMillisecond(1, 4));
            MouseOperationsService.MouseEvent(MouseOperationsService.MouseEventFlags.LeftUp);
        }

        public Form1()
        {
            InitializeComponent();
            AppendLogs("Start");

            FetchLogsTimmer();

            #region Hook
            hookCallback = HookCallback;
            // Start the keyboard hook
            hookId = SetHook(hookCallback);
            //// Stop the keyboard hook
            //UnhookWindowsHookEx(hookId);
            #endregion


            //FetchImageTimmer();

            AddRow();

            gvAutoList.CellContentClick += new DataGridViewCellEventHandler(gvAutoList_CellContentClick);
        }
        private System.Windows.Forms.Timer timerFetchLogs;
        private void FetchLogsTimmer()
        {
            timerFetchLogs = new System.Windows.Forms.Timer();
            timerFetchLogs.Interval = 1000; // Capture every 100 milliseconds
            timerFetchLogs.Tick += new EventHandler(FetchLogs);
            timerFetchLogs.Start();
        }
        private void FetchLogs(object? sender, EventArgs e)
        {
            lock (LogsAuto)
            {

                LogsAuto.ForEach(f =>
                {
                    lbLog.Items.Add(f);
                });
                lbLog.SelectedIndex = lbLog.Items.Count - 1;
                LogsAuto = new List<string>();
            }
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
                    var img = CaptureScreen(captureArea);
                    //DataGridViewImageColumn imageCol = new DataGridViewImageColumn(); 
                    gvAutoList.Rows[e.RowIndex].Cells[(int)GVHeaderPosition.ReCheck].Value = img;

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


        private System.Windows.Forms.Timer timerFetchImage;
        private void FetchImageTimmer()
        {
            timerFetchImage = new System.Windows.Forms.Timer();
            timerFetchImage.Interval = 1000; // Capture every 100 milliseconds
            timerFetchImage.Tick += new EventHandler(FetchImageFromScreen);
            timerFetchImage.Start();
        }

        private static List<ItemAuto> gvDatas;
        private void FetchImageFromScreen(object? sender, EventArgs e)
        {
            ReadGV();
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
                item.rectangle = null;
                if (wid > 0 && hei > 0)
                {
                    Rectangle captureArea = new Rectangle((int)item.TopLeftX, (int)item.TopLeftY, wid, hei);
                    var img = CaptureScreen(captureArea);
                    //DataGridViewImageColumn imageCol = new DataGridViewImageColumn(); 
                    gvAutoList.Rows[i].Cells[(int)GVHeaderPosition.Position].Value = img;
                    item.rectangle = captureArea;
                }
                if (item.Active == true)
                {
                    results.Add(item);
                }
            }
            gvDatas = results;
            return results;
        }

        private Bitmap CaptureScreen(Rectangle captureArea)
        {
            Bitmap result;
            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(Point.Empty, Point.Empty, bitmap.Size);
                }
                Bitmap croppedBitmap = bitmap.Clone(captureArea, bitmap.PixelFormat);
                result = croppedBitmap;
                //bitmap.Dispose();
                //croppedBitmap.Dispose();
            }
            return result;
        }

        private void btnFetchImageManual_Click(object sender, EventArgs e)
        {
            var gvDatas = ReadGV();
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

        public Point GetRandomPointInRectangle(Rectangle rectangle)
        {
            Random random = new Random();
            int x = random.Next(rectangle.Left, rectangle.Right);
            int y = random.Next(rectangle.Top, rectangle.Bottom);

            Point randomPoint = new Point(x, y);
            return randomPoint;
        }

        private int convertSecondToMilisecond(decimal seconds)
        {
            // TimeSpan.FromSeconds(seconds);
            int milliseconds = (int)(seconds * 1000);
            return milliseconds;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            AppendLogs($"Click Start");
            timmerClickAuto = new System.Windows.Forms.Timer();
            timmerClickAuto.Interval = 100; // Capture every 100 milliseconds
            timmerClickAuto.Tick += new EventHandler(MouseClickAutoTimmer);
            timmerClickAuto.Start();


        }
        private System.Windows.Forms.Timer timmerClickAuto;
        private void MouseClickAutoTimmer(object? sender, EventArgs e)
        {
            int round = 3;
            int index = 0;
            var gvDatas = ReadGV();
            while (round > 0)
            {
                AppendLogs($"Round = {round} : index = {index.ToString()} : IsStop = {MoveCursorService.isStop.ToString()}");
                if (index < gvDatas.Count)
                {
                    var isAbleToRun = (gvDatas[index].Active == true && gvDatas[index].rectangle != null);
                    if (isAbleToRun)
                    {
                        int roundRecheck = 0;
                    RECHECKEQUAL:
                        if (roundRecheck > 3)
                        {
                            round = 0; break; return;
                        }
                        var isEqual = true;// IsEqual(index);
                        AppendLogs($"Round = {round} : index = {index.ToString()} : isEqual :X {isEqual.ToString()}");
                        if (!isEqual)
                        {
                            roundRecheck++;
                            System.Threading.Thread.Sleep(convertSecondToMilisecond(3));
                            goto RECHECKEQUAL;
                        }
                        var mousePoint = GetRandomPointInRectangle(gvDatas[index].rectangle.Value);
                        Cursor.Position = mousePoint;
                        AppendLogs($"Mouse point :X {mousePoint.X} , Y {mousePoint.Y}");
                        System.Threading.Thread.Sleep(convertSecondToMilisecond(gvDatas[index].Interval.Value));
                        LeftMouseClick();
                    }
                    index++;
                }
                else
                {
                    index = 0;
                    round--;
                }
            }
            timmerClickAuto.Stop();
            lbStatusValue.Text = MoveCursorService.isStop.ToString();
            AppendLogs($"Done job");
        }
        private static List<string> LogsAuto { get; set; }
        private static void AppendLogs(string logs)
        {
            if (LogsAuto == null)
            {
                LogsAuto = new List<string>();
            }

            if (string.IsNullOrEmpty(logs))
            {
                return;
            }

            logs = DateTime.Now.ToString("HH:mm:sss") + logs;
            LogsAuto.Add(logs);
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
            var dataList = ReadGV();
            // Insert some data into the SQLite database
            string insertDataQuery = "INSERT INTO ItemAuto (TopLeftX, TopLeftY, BotRightX, BotRightY, Interval, Active) VALUES (@TopLeftX, @TopLeftY, @BotRightX, @BotRightY, @Interval, @Active)";
            using (SQLiteCommand command = new SQLiteCommand(insertDataQuery, connection))
            {
                dataList.ForEach(f =>
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

        private void btnStop_Click(object sender, EventArgs e)
        {

            AppendLogs($"Click Stop");
        }
    }
}