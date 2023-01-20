
namespace DataCollectionTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.tbCameraPartNo = new System.Windows.Forms.TextBox();
            this.tbPalletNo = new System.Windows.Forms.TextBox();
            this.tbCameraType = new System.Windows.Forms.TextBox();
            this.tbBackupCamResult = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.lblCF = new System.Windows.Forms.Label();
            this.lblPartBC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPType = new System.Windows.Forms.Label();
            this.lblCType = new System.Windows.Forms.Label();
            this.lblCResult = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.lblCTime = new System.Windows.Forms.Label();
            this.SecTimer = new System.Windows.Forms.Timer(this.components);
            this.tbOEE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbComponentCheckResult = new System.Windows.Forms.TextBox();
            this.lblOcr = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCamFailReason = new System.Windows.Forms.TextBox();
            this.lblCamFailure = new System.Windows.Forms.Label();
            this.cbEmail = new System.Windows.Forms.CheckBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalDT = new System.Windows.Forms.Label();
            this.tbTotalDT = new System.Windows.Forms.TextBox();
            this.lblTextMinutes = new System.Windows.Forms.Label();
            this.lblSt6DT = new System.Windows.Forms.Label();
            this.lblSt5DT = new System.Windows.Forms.Label();
            this.lblSt4DT = new System.Windows.Forms.Label();
            this.lblSt3DT = new System.Windows.Forms.Label();
            this.lblst2DT = new System.Windows.Forms.Label();
            this.tbSt6Downtime = new System.Windows.Forms.TextBox();
            this.tbSt5Downtime = new System.Windows.Forms.TextBox();
            this.tbSt4Downtime = new System.Windows.Forms.TextBox();
            this.tbSt3Downtime = new System.Windows.Forms.TextBox();
            this.tbSt2Downtime = new System.Windows.Forms.TextBox();
            this.tbShift = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPMS = new System.Windows.Forms.TextBox();
            this.tbPMF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Ivory;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(326, 438);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1335, 370);
            this.dataGridView1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1461, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.Location = new System.Drawing.Point(368, 412);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(137, 20);
            this.tbPartNumber.TabIndex = 2;
            this.tbPartNumber.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // tbCameraPartNo
            // 
            this.tbCameraPartNo.Location = new System.Drawing.Point(517, 412);
            this.tbCameraPartNo.Name = "tbCameraPartNo";
            this.tbCameraPartNo.Size = new System.Drawing.Size(172, 20);
            this.tbCameraPartNo.TabIndex = 3;
            this.tbCameraPartNo.TextChanged += new System.EventHandler(this.cbc_TextChanged);
            // 
            // tbPalletNo
            // 
            this.tbPalletNo.Location = new System.Drawing.Point(705, 412);
            this.tbPalletNo.Name = "tbPalletNo";
            this.tbPalletNo.Size = new System.Drawing.Size(78, 20);
            this.tbPalletNo.TabIndex = 4;
            // 
            // tbCameraType
            // 
            this.tbCameraType.Location = new System.Drawing.Point(787, 412);
            this.tbCameraType.Name = "tbCameraType";
            this.tbCameraType.Size = new System.Drawing.Size(93, 20);
            this.tbCameraType.TabIndex = 5;
            // 
            // tbBackupCamResult
            // 
            this.tbBackupCamResult.Location = new System.Drawing.Point(898, 412);
            this.tbBackupCamResult.Name = "tbBackupCamResult";
            this.tbBackupCamResult.Size = new System.Drawing.Size(85, 20);
            this.tbBackupCamResult.TabIndex = 6;
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(1112, 412);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(175, 20);
            this.tbDate.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbInterval
            // 
            this.tbInterval.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbInterval.Location = new System.Drawing.Point(183, 11);
            this.tbInterval.Margin = new System.Windows.Forms.Padding(2);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(120, 20);
            this.tbInterval.TabIndex = 9;
            this.tbInterval.Text = "5700";
            // 
            // lblCF
            // 
            this.lblCF.AutoSize = true;
            this.lblCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCF.Location = new System.Drawing.Point(9, 11);
            this.lblCF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCF.Name = "lblCF";
            this.lblCF.Size = new System.Drawing.Size(170, 15);
            this.lblCF.TabIndex = 10;
            this.lblCF.Text = "Collection Frequency(ms)";
            // 
            // lblPartBC
            // 
            this.lblPartBC.AutoSize = true;
            this.lblPartBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartBC.Location = new System.Drawing.Point(398, 394);
            this.lblPartBC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPartBC.Name = "lblPartBC";
            this.lblPartBC.Size = new System.Drawing.Size(81, 13);
            this.lblPartBC.TabIndex = 13;
            this.lblPartBC.Text = "Part Barcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(546, 395);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Camera Barcode";
            // 
            // lblPType
            // 
            this.lblPType.AutoSize = true;
            this.lblPType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPType.Location = new System.Drawing.Point(709, 395);
            this.lblPType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPType.Name = "lblPType";
            this.lblPType.Size = new System.Drawing.Size(68, 13);
            this.lblPType.TabIndex = 15;
            this.lblPType.Text = "Pallet Num";
            // 
            // lblCType
            // 
            this.lblCType.AutoSize = true;
            this.lblCType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCType.Location = new System.Drawing.Point(795, 395);
            this.lblCType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCType.Name = "lblCType";
            this.lblCType.Size = new System.Drawing.Size(81, 13);
            this.lblCType.TabIndex = 16;
            this.lblCType.Text = "Camera Type";
            // 
            // lblCResult
            // 
            this.lblCResult.AutoSize = true;
            this.lblCResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCResult.Location = new System.Drawing.Point(896, 381);
            this.lblCResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCResult.Name = "lblCResult";
            this.lblCResult.Size = new System.Drawing.Size(89, 26);
            this.lblCResult.TabIndex = 17;
            this.lblCResult.Text = "Sherlock\r\nCamera Result";
            this.lblCResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(1180, 395);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 18;
            this.lblDate.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1004, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "( Good parts * 36 / Planned production time * 60 )";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(408, 8);
            this.tbTime.Margin = new System.Windows.Forms.Padding(2);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(138, 20);
            this.tbTime.TabIndex = 20;
            // 
            // lblCTime
            // 
            this.lblCTime.AutoSize = true;
            this.lblCTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCTime.Location = new System.Drawing.Point(323, 13);
            this.lblCTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCTime.Name = "lblCTime";
            this.lblCTime.Size = new System.Drawing.Size(79, 13);
            this.lblCTime.TabIndex = 21;
            this.lblCTime.Text = "Current Time";
            // 
            // SecTimer
            // 
            this.SecTimer.Enabled = true;
            this.SecTimer.Interval = 1000;
            this.SecTimer.Tick += new System.EventHandler(this.SecTimer_Tick);
            // 
            // tbOEE
            // 
            this.tbOEE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOEE.Location = new System.Drawing.Point(1135, 56);
            this.tbOEE.Margin = new System.Windows.Forms.Padding(2);
            this.tbOEE.Multiline = true;
            this.tbOEE.Name = "tbOEE";
            this.tbOEE.Size = new System.Drawing.Size(94, 31);
            this.tbOEE.TabIndex = 22;
            this.tbOEE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1001, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Last Hour OEE";
            // 
            // tbComponentCheckResult
            // 
            this.tbComponentCheckResult.Location = new System.Drawing.Point(997, 412);
            this.tbComponentCheckResult.Name = "tbComponentCheckResult";
            this.tbComponentCheckResult.Size = new System.Drawing.Size(95, 20);
            this.tbComponentCheckResult.TabIndex = 24;
            // 
            // lblOcr
            // 
            this.lblOcr.AutoSize = true;
            this.lblOcr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcr.Location = new System.Drawing.Point(995, 395);
            this.lblOcr.Name = "lblOcr";
            this.lblOcr.Size = new System.Drawing.Size(110, 13);
            this.lblOcr.TabIndex = 25;
            this.lblOcr.Text = "Component Check";
            this.lblOcr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(570, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Cumulative Downtime";
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(183, 33);
            this.tbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(120, 20);
            this.tbStatus.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Connection Status";
            // 
            // tbCamFailReason
            // 
            this.tbCamFailReason.Location = new System.Drawing.Point(1309, 412);
            this.tbCamFailReason.Margin = new System.Windows.Forms.Padding(2);
            this.tbCamFailReason.Name = "tbCamFailReason";
            this.tbCamFailReason.Size = new System.Drawing.Size(246, 20);
            this.tbCamFailReason.TabIndex = 30;
            // 
            // lblCamFailure
            // 
            this.lblCamFailure.AutoSize = true;
            this.lblCamFailure.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamFailure.Location = new System.Drawing.Point(1351, 394);
            this.lblCamFailure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCamFailure.Name = "lblCamFailure";
            this.lblCamFailure.Size = new System.Drawing.Size(187, 13);
            this.lblCamFailure.TabIndex = 31;
            this.lblCamFailure.Text = "Component Cam Failure Reason";
            // 
            // cbEmail
            // 
            this.cbEmail.AutoSize = true;
            this.cbEmail.Checked = true;
            this.cbEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmail.Location = new System.Drawing.Point(408, 42);
            this.cbEmail.Margin = new System.Windows.Forms.Padding(2);
            this.cbEmail.Name = "cbEmail";
            this.cbEmail.Size = new System.Drawing.Size(116, 21);
            this.cbEmail.TabIndex = 34;
            this.cbEmail.Text = "Send Emails";
            this.cbEmail.UseVisualStyleBackColor = true;
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(1142, 6);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(89, 38);
            this.btnEmail.TabIndex = 35;
            this.btnEmail.Text = "Test Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(183, 59);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 36;
            this.tbIP.Text = "192.168.1.116";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(102, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 37;
            this.label6.Text = "IPAddress:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.lblTotalDT);
            this.panel1.Controls.Add(this.tbTotalDT);
            this.panel1.Controls.Add(this.lblTextMinutes);
            this.panel1.Controls.Add(this.lblSt6DT);
            this.panel1.Controls.Add(this.lblSt5DT);
            this.panel1.Controls.Add(this.lblSt4DT);
            this.panel1.Controls.Add(this.lblSt3DT);
            this.panel1.Controls.Add(this.lblst2DT);
            this.panel1.Controls.Add(this.tbSt6Downtime);
            this.panel1.Controls.Add(this.tbSt5Downtime);
            this.panel1.Controls.Add(this.tbSt4Downtime);
            this.panel1.Controls.Add(this.tbSt3Downtime);
            this.panel1.Controls.Add(this.tbSt2Downtime);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbOEE);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(326, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1335, 133);
            this.panel1.TabIndex = 38;
            // 
            // lblTotalDT
            // 
            this.lblTotalDT.AutoSize = true;
            this.lblTotalDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDT.Location = new System.Drawing.Point(20, 62);
            this.lblTotalDT.Name = "lblTotalDT";
            this.lblTotalDT.Size = new System.Drawing.Size(133, 20);
            this.lblTotalDT.TabIndex = 39;
            this.lblTotalDT.Text = "Total Downtime";
            // 
            // tbTotalDT
            // 
            this.tbTotalDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalDT.Location = new System.Drawing.Point(162, 59);
            this.tbTotalDT.Margin = new System.Windows.Forms.Padding(2);
            this.tbTotalDT.Multiline = true;
            this.tbTotalDT.Name = "tbTotalDT";
            this.tbTotalDT.Size = new System.Drawing.Size(94, 31);
            this.tbTotalDT.TabIndex = 38;
            this.tbTotalDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTextMinutes
            // 
            this.lblTextMinutes.AutoSize = true;
            this.lblTextMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextMinutes.Location = new System.Drawing.Point(619, 29);
            this.lblTextMinutes.Name = "lblTextMinutes";
            this.lblTextMinutes.Size = new System.Drawing.Size(59, 13);
            this.lblTextMinutes.TabIndex = 37;
            this.lblTextMinutes.Text = "(Minutes)";
            // 
            // lblSt6DT
            // 
            this.lblSt6DT.AutoSize = true;
            this.lblSt6DT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt6DT.Location = new System.Drawing.Point(815, 72);
            this.lblSt6DT.Name = "lblSt6DT";
            this.lblSt6DT.Size = new System.Drawing.Size(96, 15);
            this.lblSt6DT.TabIndex = 36;
            this.lblSt6DT.Text = "St6 Downtime";
            // 
            // lblSt5DT
            // 
            this.lblSt5DT.AutoSize = true;
            this.lblSt5DT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt5DT.Location = new System.Drawing.Point(691, 72);
            this.lblSt5DT.Name = "lblSt5DT";
            this.lblSt5DT.Size = new System.Drawing.Size(96, 15);
            this.lblSt5DT.TabIndex = 35;
            this.lblSt5DT.Text = "St5 Downtime";
            // 
            // lblSt4DT
            // 
            this.lblSt4DT.AutoSize = true;
            this.lblSt4DT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt4DT.Location = new System.Drawing.Point(567, 72);
            this.lblSt4DT.Name = "lblSt4DT";
            this.lblSt4DT.Size = new System.Drawing.Size(96, 15);
            this.lblSt4DT.TabIndex = 34;
            this.lblSt4DT.Text = "St4 Downtime";
            // 
            // lblSt3DT
            // 
            this.lblSt3DT.AutoSize = true;
            this.lblSt3DT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSt3DT.Location = new System.Drawing.Point(442, 72);
            this.lblSt3DT.Name = "lblSt3DT";
            this.lblSt3DT.Size = new System.Drawing.Size(96, 15);
            this.lblSt3DT.TabIndex = 33;
            this.lblSt3DT.Text = "St3 Downtime";
            // 
            // lblst2DT
            // 
            this.lblst2DT.AutoSize = true;
            this.lblst2DT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblst2DT.Location = new System.Drawing.Point(316, 72);
            this.lblst2DT.Name = "lblst2DT";
            this.lblst2DT.Size = new System.Drawing.Size(96, 15);
            this.lblst2DT.TabIndex = 32;
            this.lblst2DT.Text = "St2 Downtime";
            // 
            // tbSt6Downtime
            // 
            this.tbSt6Downtime.Location = new System.Drawing.Point(816, 90);
            this.tbSt6Downtime.Name = "tbSt6Downtime";
            this.tbSt6Downtime.Size = new System.Drawing.Size(100, 20);
            this.tbSt6Downtime.TabIndex = 31;
            // 
            // tbSt5Downtime
            // 
            this.tbSt5Downtime.Location = new System.Drawing.Point(691, 90);
            this.tbSt5Downtime.Name = "tbSt5Downtime";
            this.tbSt5Downtime.Size = new System.Drawing.Size(100, 20);
            this.tbSt5Downtime.TabIndex = 30;
            // 
            // tbSt4Downtime
            // 
            this.tbSt4Downtime.Location = new System.Drawing.Point(566, 90);
            this.tbSt4Downtime.Name = "tbSt4Downtime";
            this.tbSt4Downtime.Size = new System.Drawing.Size(100, 20);
            this.tbSt4Downtime.TabIndex = 29;
            // 
            // tbSt3Downtime
            // 
            this.tbSt3Downtime.Location = new System.Drawing.Point(441, 90);
            this.tbSt3Downtime.Name = "tbSt3Downtime";
            this.tbSt3Downtime.Size = new System.Drawing.Size(100, 20);
            this.tbSt3Downtime.TabIndex = 28;
            // 
            // tbSt2Downtime
            // 
            this.tbSt2Downtime.Location = new System.Drawing.Point(316, 90);
            this.tbSt2Downtime.Name = "tbSt2Downtime";
            this.tbSt2Downtime.Size = new System.Drawing.Size(100, 20);
            this.tbSt2Downtime.TabIndex = 27;
            // 
            // tbShift
            // 
            this.tbShift.Location = new System.Drawing.Point(616, 8);
            this.tbShift.Name = "tbShift";
            this.tbShift.Size = new System.Drawing.Size(54, 20);
            this.tbShift.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(576, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 40;
            this.label7.Text = "Shift";
            // 
            // tbPMS
            // 
            this.tbPMS.Location = new System.Drawing.Point(1130, 171);
            this.tbPMS.Margin = new System.Windows.Forms.Padding(2);
            this.tbPMS.Name = "tbPMS";
            this.tbPMS.Size = new System.Drawing.Size(82, 20);
            this.tbPMS.TabIndex = 41;
            // 
            // tbPMF
            // 
            this.tbPMF.Location = new System.Drawing.Point(666, 171);
            this.tbPMF.Margin = new System.Windows.Forms.Padding(2);
            this.tbPMF.Name = "tbPMF";
            this.tbPMF.Size = new System.Drawing.Size(76, 20);
            this.tbPMF.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(561, 176);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Parts Made First";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1009, 176);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Parts Made Second";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(652, 155);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Updates at 3:35pm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1118, 155);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Updates at 2:10am";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1443, 821);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbPMF);
            this.Controls.Add(this.tbPMS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbShift);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.cbEmail);
            this.Controls.Add(this.lblCamFailure);
            this.Controls.Add(this.tbCamFailReason);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.lblOcr);
            this.Controls.Add(this.tbComponentCheckResult);
            this.Controls.Add(this.lblCTime);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCResult);
            this.Controls.Add(this.lblCType);
            this.Controls.Add(this.lblPType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPartBC);
            this.Controls.Add(this.lblCF);
            this.Controls.Add(this.tbInterval);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tbBackupCamResult);
            this.Controls.Add(this.tbCameraType);
            this.Controls.Add(this.tbPalletNo);
            this.Controls.Add(this.tbCameraPartNo);
            this.Controls.Add(this.tbPartNumber);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.Label lblCF;
        private System.Windows.Forms.Label lblPartBC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPType;
        private System.Windows.Forms.Label lblCType;
        private System.Windows.Forms.Label lblCResult;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label lblCTime;
        private System.Windows.Forms.Timer SecTimer;
        public System.Windows.Forms.TextBox tbPartNumber;
        public System.Windows.Forms.TextBox tbCameraPartNo;
        public System.Windows.Forms.TextBox tbPalletNo;
        public System.Windows.Forms.TextBox tbCameraType;
        public System.Windows.Forms.TextBox tbBackupCamResult;
        public System.Windows.Forms.TextBox tbDate;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbOEE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbComponentCheckResult;
        private System.Windows.Forms.Label lblOcr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCamFailReason;
        private System.Windows.Forms.Label lblCamFailure;
        private System.Windows.Forms.CheckBox cbEmail;
        public System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalDT;
        private System.Windows.Forms.TextBox tbTotalDT;
        private System.Windows.Forms.Label lblTextMinutes;
        private System.Windows.Forms.Label lblSt6DT;
        private System.Windows.Forms.Label lblSt5DT;
        private System.Windows.Forms.Label lblSt4DT;
        private System.Windows.Forms.Label lblSt3DT;
        private System.Windows.Forms.Label lblst2DT;
        private System.Windows.Forms.TextBox tbSt6Downtime;
        private System.Windows.Forms.TextBox tbSt5Downtime;
        private System.Windows.Forms.TextBox tbSt4Downtime;
        private System.Windows.Forms.TextBox tbSt3Downtime;
        private System.Windows.Forms.TextBox tbSt2Downtime;
        private System.Windows.Forms.TextBox tbShift;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPMS;
        private System.Windows.Forms.TextBox tbPMF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

