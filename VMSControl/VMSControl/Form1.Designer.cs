
namespace VMSControl
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelSerialStatus = new System.Windows.Forms.Label();
            this.comboBoxCom1 = new System.Windows.Forms.ComboBox();
            this.buttonOpenSerial = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelVmsStatus = new System.Windows.Forms.Label();
            this.buttonConnectionServer = new System.Windows.Forms.Button();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.serialPortLora = new System.IO.Ports.SerialPort(this.components);
            this.textBoxLoraData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSago = new System.Windows.Forms.Button();
            this.buttonVelocity = new System.Windows.Forms.Button();
            this.trackBarVelocity = new System.Windows.Forms.TrackBar();
            this.labelSetVelocity = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDanger = new System.Windows.Forms.Label();
            this.buttonSoundPlay = new System.Windows.Forms.Button();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxSound = new System.Windows.Forms.CheckBox();
            this.numericUpDownTick = new System.Windows.Forms.NumericUpDown();
            this.buttonSetTick = new System.Windows.Forms.Button();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDataClear = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelVelocity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTick = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocity)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTick)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "게이트웨이";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelSerialStatus);
            this.groupBox3.Controls.Add(this.comboBoxCom1);
            this.groupBox3.Controls.Add(this.buttonOpenSerial);
            this.groupBox3.Location = new System.Drawing.Point(7, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 55);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "연결상태";
            // 
            // labelSerialStatus
            // 
            this.labelSerialStatus.BackColor = System.Drawing.Color.Red;
            this.labelSerialStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSerialStatus.ForeColor = System.Drawing.Color.White;
            this.labelSerialStatus.Location = new System.Drawing.Point(154, 20);
            this.labelSerialStatus.Name = "labelSerialStatus";
            this.labelSerialStatus.Size = new System.Drawing.Size(56, 23);
            this.labelSerialStatus.TabIndex = 15;
            this.labelSerialStatus.Text = "닫힘";
            this.labelSerialStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCom1
            // 
            this.comboBoxCom1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom1.FormattingEnabled = true;
            this.comboBoxCom1.Location = new System.Drawing.Point(10, 23);
            this.comboBoxCom1.Name = "comboBoxCom1";
            this.comboBoxCom1.Size = new System.Drawing.Size(77, 20);
            this.comboBoxCom1.TabIndex = 14;
            // 
            // buttonOpenSerial
            // 
            this.buttonOpenSerial.Location = new System.Drawing.Point(94, 20);
            this.buttonOpenSerial.Name = "buttonOpenSerial";
            this.buttonOpenSerial.Size = new System.Drawing.Size(56, 23);
            this.buttonOpenSerial.TabIndex = 1;
            this.buttonOpenSerial.Text = "열기";
            this.buttonOpenSerial.UseVisualStyleBackColor = true;
            this.buttonOpenSerial.Click += new System.EventHandler(this.buttonOpenSerial_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(268, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 87);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "전광판";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelVmsStatus);
            this.groupBox4.Controls.Add(this.buttonConnectionServer);
            this.groupBox4.Controls.Add(this.tbServerIP);
            this.groupBox4.Controls.Add(this.tbServerPort);
            this.groupBox4.Location = new System.Drawing.Point(6, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(297, 55);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "연결상태";
            // 
            // labelVmsStatus
            // 
            this.labelVmsStatus.BackColor = System.Drawing.Color.Red;
            this.labelVmsStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelVmsStatus.ForeColor = System.Drawing.Color.White;
            this.labelVmsStatus.Location = new System.Drawing.Point(232, 20);
            this.labelVmsStatus.Name = "labelVmsStatus";
            this.labelVmsStatus.Size = new System.Drawing.Size(56, 23);
            this.labelVmsStatus.TabIndex = 15;
            this.labelVmsStatus.Text = "끊김";
            this.labelVmsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConnectionServer
            // 
            this.buttonConnectionServer.Location = new System.Drawing.Point(172, 20);
            this.buttonConnectionServer.Name = "buttonConnectionServer";
            this.buttonConnectionServer.Size = new System.Drawing.Size(53, 23);
            this.buttonConnectionServer.TabIndex = 1;
            this.buttonConnectionServer.Text = "연결";
            this.buttonConnectionServer.UseVisualStyleBackColor = true;
            this.buttonConnectionServer.Click += new System.EventHandler(this.buttonConnectionServer_Click);
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(21, 20);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(92, 21);
            this.tbServerIP.TabIndex = 5;
            this.tbServerIP.Text = "192.168.0.201";
            this.tbServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(117, 20);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(50, 21);
            this.tbServerPort.TabIndex = 4;
            this.tbServerPort.Text = "5000";
            this.tbServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serialPortLora
            // 
            this.serialPortLora.BaudRate = 115200;
            this.serialPortLora.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortLora_DataReceived);
            // 
            // textBoxLoraData
            // 
            this.textBoxLoraData.Location = new System.Drawing.Point(12, 135);
            this.textBoxLoraData.Multiline = true;
            this.textBoxLoraData.Name = "textBoxLoraData";
            this.textBoxLoraData.ReadOnly = true;
            this.textBoxLoraData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLoraData.Size = new System.Drawing.Size(834, 380);
            this.textBoxLoraData.TabIndex = 3;
            this.textBoxLoraData.TextChanged += new System.EventHandler(this.textBoxLoraData_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "데이터";
            // 
            // buttonSago
            // 
            this.buttonSago.Location = new System.Drawing.Point(93, 39);
            this.buttonSago.Name = "buttonSago";
            this.buttonSago.Size = new System.Drawing.Size(75, 23);
            this.buttonSago.TabIndex = 5;
            this.buttonSago.Text = "사고";
            this.buttonSago.UseVisualStyleBackColor = true;
            this.buttonSago.Click += new System.EventHandler(this.buttonSago_Click);
            // 
            // buttonVelocity
            // 
            this.buttonVelocity.Location = new System.Drawing.Point(249, 13);
            this.buttonVelocity.Name = "buttonVelocity";
            this.buttonVelocity.Size = new System.Drawing.Size(124, 23);
            this.buttonVelocity.TabIndex = 5;
            this.buttonVelocity.Text = "속도 테스트";
            this.buttonVelocity.UseVisualStyleBackColor = true;
            this.buttonVelocity.Click += new System.EventHandler(this.buttonVelocity_Click);
            // 
            // trackBarVelocity
            // 
            this.trackBarVelocity.LargeChange = 1;
            this.trackBarVelocity.Location = new System.Drawing.Point(184, 39);
            this.trackBarVelocity.Maximum = 200;
            this.trackBarVelocity.Name = "trackBarVelocity";
            this.trackBarVelocity.Size = new System.Drawing.Size(190, 45);
            this.trackBarVelocity.TabIndex = 6;
            this.trackBarVelocity.TickFrequency = 10;
            this.trackBarVelocity.Value = 60;
            this.trackBarVelocity.ValueChanged += new System.EventHandler(this.trackBarVelocity_ValueChanged);
            // 
            // labelSetVelocity
            // 
            this.labelSetVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSetVelocity.Location = new System.Drawing.Point(184, 13);
            this.labelSetVelocity.Name = "labelSetVelocity";
            this.labelSetVelocity.Size = new System.Drawing.Size(59, 23);
            this.labelSetVelocity.TabIndex = 7;
            this.labelSetVelocity.Text = "60";
            this.labelSetVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDanger
            // 
            this.labelDanger.BackColor = System.Drawing.Color.Green;
            this.labelDanger.ForeColor = System.Drawing.Color.White;
            this.labelDanger.Location = new System.Drawing.Point(10, 17);
            this.labelDanger.Name = "labelDanger";
            this.labelDanger.Size = new System.Drawing.Size(128, 28);
            this.labelDanger.TabIndex = 9;
            this.labelDanger.Text = "위험해제";
            this.labelDanger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSoundPlay
            // 
            this.buttonSoundPlay.Location = new System.Drawing.Point(389, 51);
            this.buttonSoundPlay.Name = "buttonSoundPlay";
            this.buttonSoundPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonSoundPlay.TabIndex = 10;
            this.buttonSoundPlay.Text = "소리 재생";
            this.buttonSoundPlay.UseVisualStyleBackColor = true;
            this.buttonSoundPlay.Click += new System.EventHandler(this.buttonSoundPlay_Click);
            // 
            // textBoxType
            // 
            this.textBoxType.Location = new System.Drawing.Point(389, 24);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(39, 21);
            this.textBoxType.TabIndex = 11;
            this.textBoxType.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(477, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.buttonSago);
            this.groupBox5.Controls.Add(this.textBoxType);
            this.groupBox5.Controls.Add(this.buttonVelocity);
            this.groupBox5.Controls.Add(this.buttonSoundPlay);
            this.groupBox5.Controls.Add(this.trackBarVelocity);
            this.groupBox5.Controls.Add(this.labelSetVelocity);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(46, 538);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(681, 86);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // checkBoxSound
            // 
            this.checkBoxSound.AutoSize = true;
            this.checkBoxSound.Location = new System.Drawing.Point(590, 94);
            this.checkBoxSound.Name = "checkBoxSound";
            this.checkBoxSound.Size = new System.Drawing.Size(88, 16);
            this.checkBoxSound.TabIndex = 14;
            this.checkBoxSound.Text = "스피커 사용";
            this.checkBoxSound.UseVisualStyleBackColor = true;
            this.checkBoxSound.CheckedChanged += new System.EventHandler(this.checkBoxSound_CheckedChanged);
            // 
            // numericUpDownTick
            // 
            this.numericUpDownTick.Location = new System.Drawing.Point(8, 49);
            this.numericUpDownTick.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDownTick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTick.Name = "numericUpDownTick";
            this.numericUpDownTick.Size = new System.Drawing.Size(53, 21);
            this.numericUpDownTick.TabIndex = 15;
            this.numericUpDownTick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownTick.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // buttonSetTick
            // 
            this.buttonSetTick.Location = new System.Drawing.Point(85, 48);
            this.buttonSetTick.Name = "buttonSetTick";
            this.buttonSetTick.Size = new System.Drawing.Size(52, 23);
            this.buttonSetTick.TabIndex = 16;
            this.buttonSetTick.Text = "설정";
            this.buttonSetTick.UseVisualStyleBackColor = true;
            this.buttonSetTick.Click += new System.EventHandler(this.buttonSetTick_Click);
            // 
            // timerTick
            // 
            this.timerTick.Interval = 1000;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.labelDanger);
            this.groupBox6.Controls.Add(this.buttonSetTick);
            this.groupBox6.Controls.Add(this.numericUpDownTick);
            this.groupBox6.Location = new System.Drawing.Point(590, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(150, 76);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "위험";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "초";
            // 
            // buttonDataClear
            // 
            this.buttonDataClear.Location = new System.Drawing.Point(771, 106);
            this.buttonDataClear.Name = "buttonDataClear";
            this.buttonDataClear.Size = new System.Drawing.Size(75, 23);
            this.buttonDataClear.TabIndex = 18;
            this.buttonDataClear.Text = "지우기";
            this.buttonDataClear.UseVisualStyleBackColor = true;
            this.buttonDataClear.Click += new System.EventHandler(this.buttonDataClear_Click);
            // 
            // labelDate
            // 
            this.labelDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelDate.Location = new System.Drawing.Point(746, 19);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(109, 23);
            this.labelDate.TabIndex = 19;
            this.labelDate.Text = "2023-05-18";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTime
            // 
            this.labelTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTime.Location = new System.Drawing.Point(746, 43);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(109, 23);
            this.labelTime.TabIndex = 19;
            this.labelTime.Text = "00:00:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "속도";
            // 
            // labelVelocity
            // 
            this.labelVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelVelocity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVelocity.Location = new System.Drawing.Point(155, 111);
            this.labelVelocity.Name = "labelVelocity";
            this.labelVelocity.Size = new System.Drawing.Size(38, 18);
            this.labelVelocity.TabIndex = 20;
            this.labelVelocity.Text = "0";
            this.labelVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "위험 해제 카운터";
            // 
            // labelTick
            // 
            this.labelTick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTick.Location = new System.Drawing.Point(349, 111);
            this.labelTick.Name = "labelTick";
            this.labelTick.Size = new System.Drawing.Size(38, 18);
            this.labelTick.TabIndex = 20;
            this.labelTick.Text = "0";
            this.labelTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "km";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "초";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 772);
            this.Controls.Add(this.labelTick);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelVelocity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.buttonDataClear);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.checkBoxSound);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxLoraData);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "VMS Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocity)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTick)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonOpenSerial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonConnectionServer;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.IO.Ports.SerialPort serialPortLora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLoraData;
        private System.Windows.Forms.Button buttonSago;
        private System.Windows.Forms.Button buttonVelocity;
        private System.Windows.Forms.TrackBar trackBarVelocity;
        private System.Windows.Forms.Label labelSetVelocity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDanger;
        private System.Windows.Forms.Button buttonSoundPlay;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxCom1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelSerialStatus;
        private System.Windows.Forms.Label labelVmsStatus;
        private System.Windows.Forms.CheckBox checkBoxSound;
        private System.Windows.Forms.NumericUpDown numericUpDownTick;
        private System.Windows.Forms.Button buttonSetTick;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDataClear;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelVelocity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTick;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

