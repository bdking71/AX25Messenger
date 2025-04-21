namespace AX25Messenger
{
    partial class frmConnection
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBoxConnection = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBoxStopBits = new ComboBox();
            comboBoxParity = new ComboBox();
            comboBoxDataBits = new ComboBox();
            labelBaudRate = new Label();
            labelSerialPort = new Label();
            comboBoxBaudRates = new ComboBox();
            comboBoxSerialPorts = new ComboBox();
            buttonConnect = new Button();
            buttonDisconnect = new Button();
            labelStatus = new Label();
            buttonSendTest = new Button();
            groupBoxConnection.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxConnection
            // 
            groupBoxConnection.Controls.Add(buttonSendTest);
            groupBoxConnection.Controls.Add(label3);
            groupBoxConnection.Controls.Add(label2);
            groupBoxConnection.Controls.Add(label1);
            groupBoxConnection.Controls.Add(comboBoxStopBits);
            groupBoxConnection.Controls.Add(comboBoxParity);
            groupBoxConnection.Controls.Add(comboBoxDataBits);
            groupBoxConnection.Controls.Add(labelBaudRate);
            groupBoxConnection.Controls.Add(labelSerialPort);
            groupBoxConnection.Controls.Add(comboBoxBaudRates);
            groupBoxConnection.Controls.Add(comboBoxSerialPorts);
            groupBoxConnection.Controls.Add(buttonConnect);
            groupBoxConnection.Controls.Add(buttonDisconnect);
            groupBoxConnection.Controls.Add(labelStatus);
            groupBoxConnection.Font = new Font("Verdana", 12F);
            groupBoxConnection.Location = new Point(12, 12);
            groupBoxConnection.Name = "groupBoxConnection";
            groupBoxConnection.Size = new Size(567, 379);
            groupBoxConnection.TabIndex = 0;
            groupBoxConnection.TabStop = false;
            groupBoxConnection.Text = "TNC Connection Settings";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 223);
            label3.Name = "label3";
            label3.Size = new Size(131, 29);
            label3.TabIndex = 12;
            label3.Text = "Stop Bits:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 185);
            label2.Name = "label2";
            label2.Size = new Size(90, 29);
            label2.TabIndex = 11;
            label2.Text = "Parity:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 142);
            label1.Name = "label1";
            label1.Size = new Size(132, 29);
            label1.TabIndex = 10;
            label1.Text = "Data Bits:";
            // 
            // comboBoxStopBits
            // 
            comboBoxStopBits.FormattingEnabled = true;
            comboBoxStopBits.Location = new Point(178, 220);
            comboBoxStopBits.Name = "comboBoxStopBits";
            comboBoxStopBits.Size = new Size(191, 37);
            comboBoxStopBits.TabIndex = 9;
            // 
            // comboBoxParity
            // 
            comboBoxParity.FormattingEnabled = true;
            comboBoxParity.Location = new Point(177, 177);
            comboBoxParity.Name = "comboBoxParity";
            comboBoxParity.Size = new Size(191, 37);
            comboBoxParity.TabIndex = 8;
            // 
            // comboBoxDataBits
            // 
            comboBoxDataBits.FormattingEnabled = true;
            comboBoxDataBits.Location = new Point(177, 134);
            comboBoxDataBits.Name = "comboBoxDataBits";
            comboBoxDataBits.Size = new Size(191, 37);
            comboBoxDataBits.TabIndex = 7;
            // 
            // labelBaudRate
            // 
            labelBaudRate.AutoSize = true;
            labelBaudRate.Location = new Point(26, 94);
            labelBaudRate.Name = "labelBaudRate";
            labelBaudRate.Size = new Size(146, 29);
            labelBaudRate.TabIndex = 6;
            labelBaudRate.Text = "Baud Rate:";
            // 
            // labelSerialPort
            // 
            labelSerialPort.AutoSize = true;
            labelSerialPort.Location = new Point(26, 47);
            labelSerialPort.Name = "labelSerialPort";
            labelSerialPort.Size = new Size(145, 29);
            labelSerialPort.TabIndex = 5;
            labelSerialPort.Text = "Serial Port:";
            // 
            // comboBoxBaudRates
            // 
            comboBoxBaudRates.FormattingEnabled = true;
            comboBoxBaudRates.Location = new Point(178, 91);
            comboBoxBaudRates.Name = "comboBoxBaudRates";
            comboBoxBaudRates.Size = new Size(191, 37);
            comboBoxBaudRates.TabIndex = 1;
            // 
            // comboBoxSerialPorts
            // 
            comboBoxSerialPorts.FormattingEnabled = true;
            comboBoxSerialPorts.Location = new Point(177, 44);
            comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            comboBoxSerialPorts.Size = new Size(192, 37);
            comboBoxSerialPorts.TabIndex = 0;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(49, 275);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(149, 39);
            buttonConnect.TabIndex = 2;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonDisconnect
            // 
            buttonDisconnect.Enabled = false;
            buttonDisconnect.Location = new Point(204, 275);
            buttonDisconnect.Name = "buttonDisconnect";
            buttonDisconnect.Size = new Size(164, 39);
            buttonDisconnect.TabIndex = 3;
            buttonDisconnect.Text = "Disconnect";
            buttonDisconnect.UseVisualStyleBackColor = true;
            buttonDisconnect.Click += buttonDisconnect_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.ForeColor = Color.Red;
            labelStatus.Location = new Point(0, 331);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(213, 29);
            labelStatus.TabIndex = 4;
            labelStatus.Text = "Not connected...";
            // 
            // buttonSendTest
            // 
            buttonSendTest.Enabled = false;
            buttonSendTest.Location = new Point(386, 275);
            buttonSendTest.Name = "buttonSendTest";
            buttonSendTest.Size = new Size(164, 39);
            buttonSendTest.TabIndex = 13;
            buttonSendTest.Text = "Send Test Packet";
            buttonSendTest.UseVisualStyleBackColor = true;
            buttonSendTest.Click += buttonSendTest_Click;
            // 
            // frmConnection
            // 
            ClientSize = new Size(697, 384);
            Controls.Add(groupBoxConnection);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmConnection";
            Text = "AX.25 Messenger - Connection Settings";
            Load += frmConnection_Load;
            groupBoxConnection.ResumeLayout(false);
            groupBoxConnection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.ComboBox comboBoxSerialPorts;
        private System.Windows.Forms.ComboBox comboBoxBaudRates;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.Label labelBaudRate;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxStopBits;
        private ComboBox comboBoxParity;
        private ComboBox comboBoxDataBits;
        private Button buttonSendTest;
    }
}
