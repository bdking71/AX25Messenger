namespace AX25_Messenger
{
    partial class frmAX25Messenger
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            SLTncStatus = new ToolStripStatusLabel();
            labelStatus = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            connectionToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            txtMessage = new TextBox();
            lblMessage = new Label();
            btnSend = new Button();
            textBoxReceivedData = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            tbDestCallsign = new TextBox();
            lblCallSign = new Label();
            tbCallsign = new TextBox();
            panel2 = new Panel();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { SLTncStatus, labelStatus });
            statusStrip1.Location = new Point(0, 652);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(2, 0, 21, 0);
            statusStrip1.Size = new Size(1172, 32);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // SLTncStatus
            // 
            SLTncStatus.Name = "SLTncStatus";
            SLTncStatus.Size = new Size(0, 25);
            // 
            // labelStatus
            // 
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(20, 25);
            labelStatus.Text = "s";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 2, 0, 2);
            menuStrip1.Size = new Size(1172, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectionToolStripMenuItem, disconnectToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(92, 29);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // connectionToolStripMenuItem
            // 
            connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            connectionToolStripMenuItem.Size = new Size(201, 34);
            connectionToolStripMenuItem.Text = "Connect";
            connectionToolStripMenuItem.Click += connectionToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(201, 34);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.Location = new Point(19, 224);
            txtMessage.Margin = new Padding(4, 3, 4, 3);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(266, 109);
            txtMessage.TabIndex = 2;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(13, 192);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(116, 29);
            lblMessage.TabIndex = 3;
            lblMessage.Text = "Message";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(173, 350);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(112, 34);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // textBoxReceivedData
            // 
            textBoxReceivedData.Dock = DockStyle.Fill;
            textBoxReceivedData.Location = new Point(0, 0);
            textBoxReceivedData.Margin = new Padding(4, 3, 4, 3);
            textBoxReceivedData.Multiline = true;
            textBoxReceivedData.Name = "textBoxReceivedData";
            textBoxReceivedData.ReadOnly = true;
            textBoxReceivedData.ScrollBars = ScrollBars.Both;
            textBoxReceivedData.Size = new Size(868, 619);
            textBoxReceivedData.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tbDestCallsign);
            panel1.Controls.Add(lblCallSign);
            panel1.Controls.Add(tbCallsign);
            panel1.Controls.Add(lblMessage);
            panel1.Controls.Add(txtMessage);
            panel1.Controls.Add(btnSend);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(304, 619);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 29);
            label1.TabIndex = 8;
            label1.Text = "To";
            // 
            // tbDestCallsign
            // 
            tbDestCallsign.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDestCallsign.Location = new Point(13, 59);
            tbDestCallsign.Margin = new Padding(4, 3, 4, 3);
            tbDestCallsign.Multiline = true;
            tbDestCallsign.Name = "tbDestCallsign";
            tbDestCallsign.Size = new Size(272, 30);
            tbDestCallsign.TabIndex = 7;
            tbDestCallsign.Text = "N0CALL";
            // 
            // lblCallSign
            // 
            lblCallSign.AutoSize = true;
            lblCallSign.Location = new Point(13, 104);
            lblCallSign.Margin = new Padding(4, 0, 4, 0);
            lblCallSign.Name = "lblCallSign";
            lblCallSign.Size = new Size(75, 29);
            lblCallSign.TabIndex = 6;
            lblCallSign.Text = "From";
            lblCallSign.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbCallsign
            // 
            tbCallsign.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbCallsign.Location = new Point(13, 145);
            tbCallsign.Margin = new Padding(4, 3, 4, 3);
            tbCallsign.Multiline = true;
            tbCallsign.Name = "tbCallsign";
            tbCallsign.Size = new Size(272, 30);
            tbCallsign.TabIndex = 5;
            tbCallsign.Text = "W8DBK";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBoxReceivedData);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(304, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(868, 619);
            panel2.TabIndex = 7;
            // 
            // frmAX25Messenger
            // 
            AutoScaleDimensions = new SizeF(15F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 684);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmAX25Messenger";
            Text = "AX25 Messenger";
            Load += frmAX25Messenger_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel SLTncStatus;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem connectionToolStripMenuItem;
        private ToolStripStatusLabel labelStatus;
        private TextBox txtMessage;
        private Label lblMessage;
        private Button btnSend;
        private TextBox textBoxReceivedData;
        private Panel panel1;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Panel panel2;
        private Label lblCallSign;
        private TextBox tbCallsign;
        private Label label1;
        private TextBox tbDestCallsign;
    }
}
