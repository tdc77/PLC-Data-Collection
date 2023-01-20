using ClosedXML.Excel;
using libplctag;
using libplctag.DataTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;



namespace DataCollectionTest
{
    public partial class Form1 : Form
    {

        public bool DataAck = false; //ack to plc that data was read
        public int Sending = 0;//sending email
        public bool CanRead = false; // data is ready from plc
        public bool InAuto = false;// only read from plc if machine is in auto
        //Check to see if camera barcode tb has changed
        public bool TextWasChanged = false;
        //where is file to be saved save by date!!
        string fileName = @"C:\\Users\\Public\\Test\\DataCollection\\" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx";
        //For Second shift
        string fileName2 = @"C:\\Users\\Public\\Test\\DataCollection\\" + DateTime.Today.ToString("yyyyMMdd_2") + ".xlsx";
        public int shift1;
        public int shift2;
        public int shift1EmailReady;
        public int shift2EmailReady;
        public int partsMadeFirst;
        public int partsMadeSecond;
        public Form1()
        {

            InitializeComponent();
            add_Columns();
            timer1.Start();
            SecTimer.Start();
            timer1.Interval = Int32.Parse(tbInterval.Text);//set data collect interval from textbox.


        }

        //Main control--after so many seconds check to see if camerabarcode tb has been changed.
        //if it has then write the new data to table and excel.
        //default is set to 5.7sec interval can be set with textbox on Form.
        public void timer1_Tick(object sender, EventArgs e)
        {
            //Check if we are connected first this will prevent a crash hopefully
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();

            int timeout = 1000;
            System.Net.NetworkInformation.PingReply reply = pingSender.Send(tbIP.Text.ToString(), timeout);

            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                tbStatus.ForeColor = System.Drawing.Color.Green;
                tbStatus.Text = "Connected";
                PLCGetData();//Get data from PLC if ready
            }
            else
            {
                //if not connected escape here
                tbStatus.ForeColor = System.Drawing.Color.Red;
                tbStatus.Text = "Not Connected";
                TimedMessageBox.Show("Cannot connect to PLC", "ERROR", 2000);
                GC.Collect();
                return;
            }
           
            //check if camera barcode changed in textbox if so write to excel sheet
            if (TextWasChanged == true)
            {

                WritetoDGView();

            }

        }

        //Timer that ticks every second use for time and other functions
        //that need to fire at a exact given time.
        private void SecTimer_Tick(object sender, EventArgs e)
        {
            tbTime.Text = DateTime.Now.ToString("HH:mm:ss");//Date time textbox

            try
            {
                //Read DowntimeData Information at top of every hour
                if (DateTime.Now.Minute == 1 && DateTime.Now.Second == 0)
                {
                    DowntimeData();
                }

                //*******************************************************************
                //Check what time of day it is to verify what shift is running
                //only email when isnt same shift 
                //
                //*******************************************************************
                TimeSpan time = DateTime.Now.TimeOfDay;
               
                //First shift time period
                if (time > new TimeSpan(02, 35, 00) //Hours, Minutes, Seconds
                 && time < new TimeSpan(15, 30, 01))
                {
                    
                    shift1 = 1;
                    shift2 = 0;
                    shift2EmailReady = 1;
                    shift1EmailReady = 0;
                    tbShift.Text = shift1.ToString();
                }   
                //Second shift
                else
                {
                    shift1 = 0;
                    shift2 = 2;
                    shift1EmailReady = 1;
                    shift2EmailReady = 0;
                    tbShift.Text = shift2.ToString();
                }
                //create a new file at 3am ( For 1st shift ) so 2nd shift has chance to finish

                if (DateTime.Now.Hour == 3 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 13)
                {
                    dataGridView1.Rows.Clear();
                    //first shift sheet   
                    CreateExcel();
                   
                    GC.Collect();//garbage collect
                }

                //Make second shift sheet
                if (DateTime.Now.Hour == 15 && DateTime.Now.Minute == 30 && DateTime.Now.Second == 11)
                {
                    dataGridView1.Rows.Clear();//clear Form datagrid
                    //second shift sheet
                    CreateExcel();

                    GC.Collect();//garbage collect
                }

                //Send Email set a bit to tell PLC logic that im sending email so dont write to excel at that time.
                if (cbEmail.Checked && DateTime.Now.Hour == 15 && DateTime.Now.Minute == 45 && DateTime.Now.Second == 11)
                {
                    Sending = 1;
                    SendEmaiTime();
                    Sending = 0;
                }
                //send second shift email
                if (cbEmail.Checked && DateTime.Now.Hour == 2 && DateTime.Now.Minute == 37 && DateTime.Now.Second == 11)
                {
                    Sending = 1;
                    SendEmaiTime();
                    Sending = 0;
                }

            }
            catch (Exception)
            {
                TimedMessageBox.Show("Cant connect to PLC", "ERROR", 2000);
            }

        }


        //Add other column name here that need to be added to sheet.
        private void add_Columns()
        {

            //setup the columns to be added if more are needed change this number to amount of columns!!
            dataGridView1.ColumnCount = 8;
            //Set the columns Width and Name.
            dataGridView1.Columns[0].Name = "PartBarcode";
            dataGridView1.Columns[0].Width = 145;
            dataGridView1.Columns[1].Name = "CameraBarcode";
            dataGridView1.Columns[1].Width = 185;
            dataGridView1.Columns[2].Name = "Pallet Number";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Name = "CameraType";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Name = "Sherlock Camera Result";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Name = "Component Camera Result";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Name = "Date";
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Name = "CompCamera Fail\\Backup Cam Reason";
            dataGridView1.Columns[7].Width = 275;


        }

        //Get data from textboxes and insert into Gridview and Excel
        public DataTable getData()
        {
            DataTable dt = new DataTable();
            // table.TableName = tableName;
            dt.Columns.Add("PartBarcode", typeof(string));
            dt.Columns.Add("CameraBarcode", typeof(string));
            dt.Columns.Add("Pallet Number", typeof(string));
            dt.Columns.Add("CameraType", typeof(string));
            dt.Columns.Add("Sherlock Camera Result", typeof(string));
            dt.Columns.Add("Component Camera Result", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Component\\Backup Cam Failure", typeof(string));


            //get data that is in textboxes--Must be same order as header columns
            dt.Rows.Add(tbPartNumber.Text.ToString(), tbCameraPartNo.Text.ToString(), tbPalletNo.Text.ToString(), tbCameraType.Text.ToString(), tbBackupCamResult.Text.ToString(), tbComponentCheckResult.Text.ToString(), tbDate.Text = DateTime.Now.ToString(), tbCamFailReason.Text.ToString());

            return dt;

        }


        //Create excel sheet if it doesnt exsist.
        public void CreateExcel()
        {
            try
            {

                if (shift1 == 1)
                {
                    fileName = @"C:\\Users\\Public\\Test\\DataCollection\\" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx";
                    //If file Doesnt exists then create it.
                    if (!File.Exists(fileName))
                    {
                        var wb = new XLWorkbook();
                        var ws = wb.Worksheets.Add(getData(), "MachData");
                        wb.SaveAs(fileName);
                        wb.Dispose();//free up resources
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                    }
                }

                if (shift2 == 2)
                {
                    fileName2 = @"C:\\Users\\Public\\Test\\DataCollection\\" + DateTime.Today.ToString("yyyyMMdd_2") + ".xlsx";

                    //if file DOESNT exists then create it second shift sheet
                    if (!File.Exists(fileName2))
                    {
                        var wb2 = new XLWorkbook();
                        var ws2 = wb2.Worksheets.Add(getData(), "MachData2");
                        wb2.SaveAs(fileName2);
                        wb2.Dispose();//free up resources
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                    }
                }
            }
            //If error occured 
            catch (Exception)
            {
                TimedMessageBox.Show("No File was Made", "ERROR", 2000);
            }

        }
          


        //check if texboxes had data changed if so set textwaschanged to true so pc knows
        //to write new data to excel
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextWasChanged = true;

        }

        void UpdateExcel()
        {

            if (TextWasChanged == true)
            {
                //write data to excel sheet
                WritetoExcel();

                //reset textwaschanged to false so pc doesnt keep writing same data to excel.
                TextWasChanged = false;

            }
            else
            {
                return;
            }
        }


        //The method that writes data to the datagridview.
        public void WritetoDGView()
        {
            DataTable dt = new DataTable();
            dt = getData();

            try
            {
             
                {
                    // add row here or it will be one short when writing to excel file
                    // I used textboxes to fill datatgridview so I didnt have to databind the table!
                    dataGridView1.Rows.Add(tbPartNumber.Text.ToString(), tbCameraPartNo.Text.ToString(), tbPalletNo.Text.ToString(), tbCameraType.Text.ToString(), tbBackupCamResult.Text.ToString(), tbComponentCheckResult.Text.ToString(), tbDate.Text.ToString(), tbCamFailReason.Text.ToString());

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        if (dataGridView1.Rows.Count - 1 > row.Index)
                        {

                            dt.Rows.Add();
                

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();


                                //if camera passes set background of row to green
                                if (row.Cells[5].Value.ToString() == "PASS" && row.Cells[4].Value.ToString() == "PASS")
                                {
                                    row.DefaultCellStyle.BackColor = Color.Green;
                                }
                                //Backup Pass Component Bypass
                                else if (row.Cells[4].Value.ToString() == "PASS" && row.Cells[5].Value.ToString() == "BYPASSED")
                                {
                                    row.DefaultCellStyle.BackColor = Color.Yellow;
                                }
                                //if service make a blue line
                                else if (row.Cells[4].Value.ToString() == "Service" && row.Cells[5].Value.ToString() == "PASS")
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                                }
                                //Service Camera Component Bypass
                                else if (row.Cells[4].Value.ToString() == "Service" && row.Cells[5].Value.ToString() == "BYPASSED")
                                {
                                    row.DefaultCellStyle.BackColor = Color.CadetBlue;
                                }    
                                else
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red;
                                }

                            }

                        }
                    }
                }


                // now update excel sheet
                UpdateExcel();
            }

            catch (Exception)
            {
                TimedMessageBox.Show("Cannot write to DGView", "ERROR", 2000);
            }


        }

        public void WritetoExcel()
        {

            try
            {
                CreateExcel();
                DataTable dt = new DataTable();
               

                //Adding data to exsisiting excel sheet goes by date
                if (shift1 == 1)
                {
                    using (XLWorkbook wb = new XLWorkbook(@"C:\\Users\\Public\\Test\\DataCollection\\" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx"))

                    {
                        IXLWorksheet ws = wb.Worksheet("MachData");
                        int NumberOfLastRow = ws.LastRowUsed().RowNumber();
                        IXLCell CellForNewData = ws.Cell(NumberOfLastRow + 1, 1);
                        CellForNewData.InsertData(getData());


                        //Set the color of Header Row.
                        //A resembles First Column while C resembles Third column.
                        wb.Worksheet(1).Cells("A1:H1").Style.Fill.BackgroundColor = XLColor.AirForceBlue;
                        int thisRow = NumberOfLastRow + 1;

                        for (int i = 1; i <= NumberOfLastRow; i++)
                        {
                            string cellRange = string.Format("A{0}:H{0}", i + 1);


                            //Header row is at Position 1 and hence First row starts from Index 2.
                            /* Note:
                            * My gridview and excel sheet were looking for pass/fails on certain components.  I made "Fail" turn line red,
                            * Service turned blue, if part failed to finish cycle I turned it orange and if something was bypassed
                            * I made it yellow.  This will need to be changed for your own values you need.
                            */

                            if (ws.Worksheet.Cell(NumberOfLastRow + 1, 5).Value.ToString() == "PASS" && ws.Worksheet.Cell(NumberOfLastRow + 1, 6).Value.ToString() == "PASS")
                            {

                                wb.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.Green;
                            }

                           else if (ws.Worksheet.Cell(NumberOfLastRow + 1, 5).Value.ToString() == "PASS" && ws.Worksheet.Cell(NumberOfLastRow + 1, 6).Value.ToString() == "BYPASSED")
                            {
                                wb.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.Yellow;
                            }

                            else if (ws.Worksheet.Cell(NumberOfLastRow + 1, 5).Value.ToString() == "Service" && ws.Worksheet.Cell(NumberOfLastRow + 1, 6).Value.ToString() == "PASS")
                            {
                                wb.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.LightGreen;
                            }

                            else if (ws.Worksheet.Cell(NumberOfLastRow + 1, 5).Value.ToString() == "Service" && ws.Worksheet.Cell(NumberOfLastRow + 1, 6).Value.ToString() == "BYPASSED")
                            {
                                wb.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.Blue;
                            }

                            else 
                            {
                                wb.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.Red;
                            }

                        }

                        //Adjust widths of Columns.
                        wb.Worksheet(1).Columns().AdjustToContents();
                        wb.Worksheet(1).Columns().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        //Add DataTable in worksheet

                        using (MemoryStream stream = new MemoryStream())

                        {

                            wb.SaveAs(fileName);
                            
                            wb.Dispose();//free up resources
                            stream.Close();
                            GC.Collect();//garbage collect
                            GC.WaitForPendingFinalizers();
                            GC.Collect();

                        }
                    }

                }


                if (shift2 == 2)
                 {
                   
                    using (XLWorkbook wb2 = new XLWorkbook(@"C:\\Users\\Public\\Test\\DataCollection\\" + DateTime.Today.ToString("yyyyMMdd_2") + ".xlsx"))

                    {
                        IXLWorksheet ws2 = wb2.Worksheet("MachData2");
                        int NumberOfLastRow = ws2.LastRowUsed().RowNumber();
                        IXLCell CellForNewData = ws2.Cell(NumberOfLastRow + 1, 1);
                        CellForNewData.InsertData(getData());


                        //Set the color of Header Row.
                        //A resembles First Column while C resembles Third column.
                        wb2.Worksheet(1).Cells("A1:H1").Style.Fill.BackgroundColor = XLColor.AirForceBlue;
                        int thisRow = NumberOfLastRow + 1;

                        for (int i = 1; i <= NumberOfLastRow; i++)
                        {
                            string cellRange = string.Format("A{0}:H{0}", i + 1);


                            //Header row is at Position 1 and hence First row starts from Index 2.
                            /* Note:
                             * My gridview and excel sheet were looking for pass/fails on certain components.  I made "Fail" turn line red,
                             * Service turned blue, if part failed to finish cycle I turned it orange and if something was bypassed
                             * I made it yellow.  This will need to be changed for your own values you need.
                             */

                            if (ws2.Worksheet.Cell(NumberOfLastRow + 1, 5).Value.ToString() == "PASS" && ws2.Worksheet.Cell(NumberOfLastRow + 1, 6).Value.ToString() == "PASS")
                            {

                                wb2.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.Green;
                            }

                            else if (ws2.Worksheet.Cell(NumberOfLastRow + 1, 5).Value.ToString() == "PASS" && ws2.Worksheet.Cell(NumberOfLastRow + 1, 6).Value.ToString() == "BYPASSED")
                            {
                                wb2.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.Yellow;
                            }

                            else if (ws2.Worksheet.Cell(NumberOfLastRow + 1, 5).Value.ToString() == "Service" && ws2.Worksheet.Cell(NumberOfLastRow + 1, 6).Value.ToString() == "PASS")
                            {
                                wb2.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.LightGreen;
                            }

                            else if (ws2.Worksheet.Cell(NumberOfLastRow + 1, 5).Value.ToString() == "Service" && ws2.Worksheet.Cell(NumberOfLastRow + 1, 6).Value.ToString() == "BYPASSED")
                            {
                                wb2.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.Blue;
                            }

                            else
                            {
                                wb2.Worksheet(1).Row(thisRow).Style.Fill.BackgroundColor = XLColor.Red;
                            }

                        }

                        //Adjust widths of Columns.
                        wb2.Worksheet(1).Columns().AdjustToContents();
                        wb2.Worksheet(1).Columns().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        //Add DataTable in worksheet

                        using (MemoryStream stream2 = new MemoryStream())

                        {

                            wb2.SaveAs(fileName2);
                            wb2.Dispose();//free up resources
                            stream2.Close();
                            GC.Collect();//garbage collect
                            GC.WaitForPendingFinalizers();
                            GC.Collect();

                        }

                    }
                }
            
        }
            catch (Exception)
            {
                TimedMessageBox.Show("cannot write to EXCEL", "ERROR", 2000);
            }
        }


        //Read Write Data to PLC Program Here
        public void PLCGetData()
        {
            string Gateway = tbIP.Text.ToString();
            
            /* Note:
             * Probably smarter to convert all that you can to string and put in one array for easier calls.
             * I didnt do that here, so look at tag names you will have to change to what you use in the PLC
             */
            
            try
            {
                //Always read part totals!!!
             /*   var DataReadPLCParts = new Tag<StringPlcMapper, string[]>()
                {
                    Name = "DataReadPLCParts[0]",
                    Gateway = Gateway,
                    Path = "1,0",
                    Protocol = Protocol.ab_eip,
                    PlcType = PlcType.ControlLogix,
                    ArrayDimensions = new int[] { 10 }, //add more to array if needed do same in plc
                };

                    DataReadPLCParts.Read();

                for (int i = 0; i < DataReadPLCParts.Value[i].Length; i++)

                    tbPMF.Text = DataReadPLCParts.Value[0].ToString();
                    tbPMS.Text = DataReadPLCParts.Value[1].ToString();
             */

                // Make sure machine is in auto before we worry about reading
                var InAuto = new Tag<BoolPlcMapper, bool>()

                {
                    Name = "MachAuto",
                    Gateway = Gateway,
                    Path = "1,0",
                    Protocol = Protocol.ab_eip,
                    PlcType = PlcType.ControlLogix,

                };
                InAuto.Read();
                bool isAuto = InAuto.Value;
               
                //Only Read if in AutoMode to prevent wasted Connection time.
                if (isAuto)
                {
                    //If data is ready from PLC then Read it and reset the ready bit.
                    var DataReady = new Tag<BoolPlcMapper, bool>()

                    {
                        Name = "DataSend",
                        Gateway = Gateway,
                        Path = "1,0",
                        Protocol = Protocol.ab_eip,
                        PlcType = PlcType.ControlLogix,

                    };
                    DataReady.Read();

                    CanRead = DataReady.Value;

                    if (CanRead == true)
                    {
                        //put string data in this array. if more are needed then
                        //lengthen array
                        var DataReadPLC = new Tag<StringPlcMapper, string[]>()
                        {
                            Name = "DataReadPLC[0]",
                            Gateway = Gateway,
                            Path = "1,0",
                            Protocol = Protocol.ab_eip,
                            PlcType = PlcType.ControlLogix,
                            ArrayDimensions = new int[] { 10 }, //add more to array if needed do same in plc
                        };
                        DataReadPLC.Read();

                        for (int i = 0; i < DataReadPLC.Value[i].Length; i++)

                            // These were names of my text boxes on form.  Change to your names here.
                             tbPartNumber.Text = DataReadPLC.Value[0].ToString();
                             tbCameraPartNo.Text = DataReadPLC.Value[1].ToString();
                             tbPalletNo.Text = DataReadPLC.Value[2].ToString();
                             tbCameraType.Text = DataReadPLC.Value[3].ToString();
                             tbBackupCamResult.Text = DataReadPLC.Value[4].ToString();
                             tbComponentCheckResult.Text = DataReadPLC.Value[5].ToString();
                             tbCamFailReason.Text = DataReadPLC.Value[6].ToString();
                             tbPMF.Text = DataReadPLC.Value[7].ToString();//Parts made first
                             tbPMS.Text = DataReadPLC.Value[8].ToString();// Parts made second



                        //Write Ack to PLC to reset DataRead Bit
                        // This sends bit back to PLC to acknowledge we got data.
                        var DataAck = new Tag<BoolPlcMapper, bool>()

                        {
                            Name = "DataReadFromPLC",
                            Gateway = Gateway,
                            Path = "1,0",
                            Protocol = Protocol.ab_eip,
                            PlcType = PlcType.ControlLogix,

                        };

                        DataAck.Value = true;
                        DataAck.Write();
                        CanRead = false;
                        Thread.Sleep(800);// I leave ack bit on for 800ms to make sure PLC has time to read it.
                        DataAck.Value = false;//Turn ack bit off
                        DataAck.Write();

                    }


                }
                GC.Collect();//garbage collect

            }
            catch (Exception)
            {
                TimedMessageBox.Show("Connection Timeout", "ERROR", 2000);

            }
        }

        //Get downtime Data from PLC
        public void DowntimeData()
        {
        
         int MachDowntime = 0;
         int MaintDowntime = 0;
         int St2_Downtime = 0;
         int St3_Downtime = 0;
         int St4_Downtime = 0;
         int St5_Downtime = 0;
         int St6_Downtime = 0;
       
             
         string connection = tbIP.Text.ToString();
        
            //Dint Mapper Read Downtime

            var M_Data = new Tag<DintPlcMapper, int[]>()
            {
                Name = "T_Data[0]",
                Gateway = connection,
                Path = "1,0",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                ArrayDimensions = new int[] { 10 },
            };

            M_Data.Read();



            for (int i = 0; i < M_Data.Value.Length; i++)
            {

                MachDowntime = M_Data.Value[0];
                MaintDowntime = M_Data.Value[1];
                St2_Downtime = M_Data.Value[2];
                St3_Downtime = M_Data.Value[3];
                St4_Downtime = M_Data.Value[4];
                St5_Downtime = M_Data.Value[5];
                St6_Downtime = M_Data.Value[6];
               
            }


            tbTotalDT.Text = MachDowntime.ToString();
            tbSt2Downtime.Text = St2_Downtime.ToString();
            tbSt3Downtime.Text = St3_Downtime.ToString();
            tbSt4Downtime.Text = St4_Downtime.ToString();
            tbSt5Downtime.Text = St5_Downtime.ToString();
            tbSt6Downtime.Text = St6_Downtime.ToString();


            //Floating Points
            var realTag = new Tag<RealPlcMapper, float>()
            {
                Name = "OEE_HMI",
                Gateway = connection,
                Path = "1,0",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip
            };
            realTag.Read();
           
            tbOEE.Text = realTag.Value.ToString();

            GC.Collect();//garbage collect
        }


        private void cbc_TextChanged(object sender, EventArgs e)
        {
            TextWasChanged = true;
        }


        /*use this for pop up message box 
        you cant use messagebox.show() because
        those are modular and stop program flow 
        so we need a way to open a message box and 
        close it after a short time. */
        public class TimedMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            DialogResult _result;
            DialogResult _timerResult;
            bool timedOut = false;

            TimedMessageBox(string text, string caption, int timeout, MessageBoxButtons buttons = MessageBoxButtons.OK, DialogResult timerResult = DialogResult.None)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                _timerResult = timerResult;
                using (_timeoutTimer)
                    _result = MessageBox.Show(text, caption, buttons);
                if (timedOut) _result = _timerResult;
            }

            public static DialogResult Show(string text, string caption, int timeout, MessageBoxButtons buttons = MessageBoxButtons.OK, DialogResult timerResult = DialogResult.None)
            {
                return new TimedMessageBox(text, caption, timeout, buttons, timerResult)._result;
            }

            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
                timedOut = true;
            }

            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);


        }


        private void SendEmaiTime()
        {   
               SendMail();       
        }

       //Send Email Program
    public void SendMail()
    {
        try
        {

            if (shift1EmailReady == 1)
            {
                //// Create the Outlook application by using inline initialization.
                Outlook.Application oApp = new Outlook.Application();

                ////Create the new message by using the simplest approach.
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                //Add a recipient.
                // TODO: Change the following recipient where appropriate.
                Outlook.Recipients oRecips = oMsg.Recipients;
                List<string> oTORecip = new List<string>();
                List<string> oCCRecip = new List<string>();

               
                oTORecip.Add("test.name@somewhere.com"); // TO
                oCCRecip.Add("testname2@somewhere.com"); // CC
                
                foreach (string t in oTORecip)
                {
                    Outlook.Recipient oTORecipt = oRecips.Add(t);
                    oTORecipt.Type = (int)Outlook.OlMailRecipientType.olTo;
                    oTORecipt.Resolve();
                }

                foreach (string t in oCCRecip)
                {
                    Outlook.Recipient oCCRecipt = oRecips.Add(t);
                    oCCRecipt.Type = (int)Outlook.OlMailRecipientType.olCC;
                    oCCRecipt.Resolve();
                }
                // DateTime.Now.ToString("yyyyMMdd")
                //Set the basic properties.
                oMsg.Subject = "Subject of Mail- " + DateTime.Today.ToString("MM/dd/yyyy");
                oMsg.HTMLBody = "<html>" +
                    "<head>" +
                    "<title>Machine Automated Mail</title>" +
                    "</head>" +
                    "<body style='background-color:#E6E6E6;'>" +
                    "<div style='font-family: Georgia, Arial; font-size:14px; '>Hi All,<br /><br />"
                     +
                    "This is from Machine. Please see my production today!!." +
                    "Files can be found on PC @C:\\Users\\Public\\Test\\DataCollection<br /><br /><br /><br /><br />" +
                    "Parts Made 1st = " + tbPMF.Text.ToString() + "<br/><br/>" +

                    "Thanks & Regards<br />" +
                    "Machine Automted response" +
                    "</div>" +
                    "</body>" +
                    "</html>";
                string date = DateTime.Today.ToString("MM-dd-yyyy");

                //Add an attachment.
                // TODO: change file path where appropriate

                String sSource = @"C:\\Users\\Public\\Test\\DataCollection\\" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx"; // find file on pc
                String sDisplayName = "Machine Production First Shift"; //name of attachment
                int iPosition = (int)oMsg.Body.Length + 1;
                int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                Outlook.Attachment oAttach = oMsg.Attachments.Add(sSource, iAttachType, iPosition, sDisplayName);
                // If you want to, display the message.
                // oMsg.Display(true);  //modal

                //Send the message.
                oMsg.Save();
                oMsg.Send();

                //Explicitly release objects.
                oTORecip = null;
                oCCRecip = null;
                oAttach = null;
                oMsg = null;
                oApp = null;

                shift1EmailReady = 0;
                GC.Collect();//garbage collect
            }

            if (shift2EmailReady == 2) // Shift 2 email response
            {
                //// Create the Outlook application by using inline initialization.
                Outlook.Application oApp2 = new Outlook.Application();

                ////Create the new message by using the simplest approach.
                Outlook.MailItem oMsg2 = (Outlook.MailItem)oApp2.CreateItem(Outlook.OlItemType.olMailItem);

                //Add a recipient.
                // TODO: Change the following recipient where appropriate.
                Outlook.Recipients oRecips = oMsg2.Recipients;
                List<string> oTORecip2 = new List<string>();
                List<string> oCCRecip2 = new List<string>();

               // ADD EMAIL NAMES HERE
                oTORecip2.Add("test.name@somewhere.com");
                oCCRecip2.Add("test.name2.carlisle@somewhere.com");
                
                foreach (string t in oTORecip2)
                {
                    Outlook.Recipient oTORecipt = oRecips.Add(t);
                    oTORecipt.Type = (int)Outlook.OlMailRecipientType.olTo;
                    oTORecipt.Resolve();
                }

                foreach (string t in oCCRecip2)
                {
                    Outlook.Recipient oCCRecipt = oRecips.Add(t);
                    oCCRecipt.Type = (int)Outlook.OlMailRecipientType.olCC;
                    oCCRecipt.Resolve();
                }
                // DateTime.Now.ToString("yyyyMMdd")
                //Set the basic properties.
                oMsg2.Subject = "Machine Subject Mail- " + DateTime.Today.ToString("MM/dd/yyyy");
                oMsg2.HTMLBody = "<html>" +
                    "<head>" +
                    "<title>Machine Automated Mail</title>" +
                    "</head>" +
                    "<body style='background-color:#E6E6E6;'>" +
                    "<div style='font-family: Georgia, Arial; font-size:14px; '>Hi All,<br /><br />"
                     +
                    "This is from Machine. Please see my production today!!. " +
                    "Files can be found on PC @C:\\Users\\Public\\Test\\DataCollection<br /><br /><br /><br /><br />" +

                    "Parts Made 2nd = " + tbPMS.Text.ToString() + "<br/><br/>" +
                    "Thanks & Regards<br />" +
                    "Machine Automted response" +
                    "</div>" +
                    "</body>" +
                    "</html>";
                string date = DateTime.Today.ToString("MM-dd-yyyy");


                // IF sending after 12am remember it is now tomorrow!! so need to use AddDays(-1) to make sure it sends the correct file
                String sSource2 = @"C:\\Users\\Public\\Test\\DataCollection\\" + DateTime.Today.AddDays(-1).ToString("yyyyMMdd_2") + ".xlsx"; // find file on pc remember its now yesterday!!
                String sDisplayName2 = "MAchine Production Second Shift"; //name of attachment
                int iPosition2 = (int)oMsg2.Body.Length + 1;
                int iAttachType2 = (int)Outlook.OlAttachmentType.olByValue;
                Outlook.Attachment oAttach = oMsg2.Attachments.Add(sSource2, iAttachType2, iPosition2, sDisplayName2);
                // If you want to, display the message.
                // oMsg.Display(true);  //modal

                //Send the message.
                oMsg2.Save();
                oMsg2.Send();

                //Explicitly release objects.
                oTORecip2 = null;
                oCCRecip2 = null;
                oAttach = null;
                oMsg2 = null;
                oApp2 = null;
                shift2EmailReady = 0;
                GC.Collect();//garbage collect
            }

        }

        catch (Exception)
        {
            TimedMessageBox.Show("Cannot connect to email or no sheet found", "ERROR", 5000);
            return;

        }   
    }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            SendMail();
        }
    }
}














