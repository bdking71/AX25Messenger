using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace AX25Messenger
{
    public partial class frmConnection : Form
    {
        private SerialPort? _serialPort; // Changed to nullable to address CS8618  
        private bool isConnected = false;
        public SerialPort? ConnectedSerialPort => isConnected ? _serialPort : null;

        public frmConnection()
        {
            InitializeComponent();
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
            comboBoxSerialPorts.Items.AddRange(SerialPort.GetPortNames());
            comboBoxBaudRates.Items.Add("1200");
            comboBoxBaudRates.Items.Add("2400");
            comboBoxBaudRates.Items.Add("4800");
            comboBoxBaudRates.Items.Add("9600");
            comboBoxBaudRates.Items.Add("19200");
            comboBoxBaudRates.Items.Add("38400");
            comboBoxBaudRates.Items.Add("57600");
            comboBoxBaudRates.Items.Add("115200");

            if (comboBoxBaudRates.Items.Contains("1200"))
                comboBoxBaudRates.SelectedItem = "1200";

            if (comboBoxSerialPorts.Items.Count > 0)
                comboBoxSerialPorts.SelectedIndex = 0;

            if (comboBoxBaudRates.Items.Count > 0)
                comboBoxBaudRates.SelectedIndex = 0;

            // Populate Data Bits
            comboBoxDataBits.Items.AddRange(new string[] { "7", "8" });
            if (comboBoxDataBits.Items.Contains("8"))
                comboBoxDataBits.SelectedItem = "8";

            // Populate Parity
            comboBoxParity.Items.AddRange(new string[] { "None", "Odd", "Even" });
            if (comboBoxParity.Items.Contains("None"))
                comboBoxParity.SelectedItem = "None";

            // Populate Stop Bits
            comboBoxStopBits.Items.AddRange(new string[] { "One", "OnePointFive", "Two" });
            if (comboBoxStopBits.Items.Contains("One"))
                comboBoxStopBits.SelectedItem = "One";

            labelStatus.Text = "Not connected";
            labelStatus.ForeColor = System.Drawing.Color.Red;

            buttonDisconnect.Enabled = false;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;
            labelStatus.Text = "Connecting...";
            labelStatus.ForeColor = System.Drawing.Color.Black;

            if (isConnected)
            {
                labelStatus.Text = "Disconnecting...";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                Disconnect();
                return;
            }

            string? selectedPort = comboBoxSerialPorts.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedPort))
            {
                labelStatus.Text = "No serial port selected.";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                buttonConnect.Enabled = true;
                return;
            }

            if (!int.TryParse(comboBoxBaudRates.SelectedItem?.ToString(), out int baudRate))
            {
                labelStatus.Text = "Invalid baud rate.";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                buttonConnect.Enabled = true;
                return;
            }

            int dataBits = 8; // Default value
            if (comboBoxDataBits.SelectedItem != null && int.TryParse(comboBoxDataBits.SelectedItem.ToString(), out int parsedDataBits))
            {
                dataBits = parsedDataBits;
            }

            Parity parity = Parity.None; // Default value
            if (comboBoxParity.SelectedItem != null && Enum.TryParse<Parity>(comboBoxParity.SelectedItem.ToString(), out Parity parsedParity))
            {
                parity = parsedParity;
            }

            StopBits stopBits = StopBits.One; // Default value
            if (comboBoxStopBits.SelectedItem != null && Enum.TryParse<StopBits>(comboBoxStopBits.SelectedItem.ToString(), out StopBits parsedStopBits))
            {
                stopBits = parsedStopBits;
            }

            try
            {
                _serialPort = new SerialPort(selectedPort, baudRate, parity, dataBits, stopBits);
                _serialPort.Handshake = Handshake.None;
                _serialPort.Open();

                isConnected = true;
                labelStatus.Text = $"Connected to {selectedPort} @ {baudRate} baud, {dataBits} data bits, {parity}, {stopBits}";
                labelStatus.ForeColor = System.Drawing.Color.Green;
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                buttonSendTest.Enabled = true;
            }
            catch (Exception ex)
            {
                labelStatus.Text = $"Error: {ex.Message}";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                buttonConnect.Enabled = true;
                buttonSendTest.Enabled = false;
            }
        }


        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                }

                isConnected = false;
                labelStatus.Text = "Disconnected";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                buttonSendTest.Enabled = false;
            }
            catch (Exception ex)
            {
                labelStatus.Text = $"Error: {ex.Message}";
                labelStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void buttonSendTest_Click(object sender, EventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                MessageBox.Show("Not connected to a serial port.");
                return;
            }

            // Example AX.25 frame: from NOCALL to APRS, no digipeaters, text: "Hello"
            byte[] ax25Frame = CreateAX25Frame("NOCALL", "APRS", "Hello from TNC");

            // Wrap it in a KISS frame
            byte[] kissFrame = CreateKISSFrame(ax25Frame);

            try
            {
                _serialPort.Write(kissFrame, 0, kissFrame.Length);
                MessageBox.Show("Test packet sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending packet: {ex.Message}");
            }
        }

        private byte[] CreateKISSFrame(byte[] ax25Frame)
        {
            List<byte> kiss = new List<byte>();
            kiss.Add(0xC0);         // KISS start delimiter
            kiss.Add(0x00);         // TNC port 0, data frame
            kiss.AddRange(ax25Frame);
            kiss.Add(0xC0);         // KISS end delimiter
            return kiss.ToArray();
        }

        private byte[] CreateAX25Frame(string fromCall, string toCall, string message)
        {
            List<byte> frame = new List<byte>();

            frame.AddRange(EncodeCallsign(toCall, 0));      // Destination SSID 0
            frame.AddRange(EncodeCallsign(fromCall, 0x61)); // Source SSID 0 + end bit
            frame.Add(0x03);                                // Control field (UI frame)
            frame.Add(0xF0);                                // PID (No L3 protocol)
            frame.AddRange(System.Text.Encoding.ASCII.GetBytes(message));

            return frame.ToArray();
        }

        private byte[] EncodeCallsign(string callsign, int ssidByte)
        {
            byte[] addr = new byte[7];
            string call = (callsign + "      ").Substring(0, 6).ToUpper();
            for (int i = 0; i < 6; i++)
            {
                addr[i] = (byte)(call[i] << 1);
            }
            addr[6] = (byte)(0x60 | (ssidByte & 0x1F)); // 0x60 sets bit 6, bit 0 = end of address
            return addr;
        }

    }
}
