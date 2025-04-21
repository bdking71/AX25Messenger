using AX25Messenger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace AX25_Messenger
{
    public partial class frmAX25Messenger : Form
    {
        private SerialPort? _connectedPort;

        public frmAX25Messenger()
        {
            InitializeComponent();
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var connectionForm = new frmConnection())
            {
                connectionForm.ShowDialog();

                if (connectionForm.ConnectedSerialPort != null)
                {
                    _connectedPort = connectionForm.ConnectedSerialPort;
                    _connectedPort.Handshake = Handshake.None;
                    connectionToolStripMenuItem.Enabled = false;
                    disconnectToolStripMenuItem.Enabled = true;

                    labelStatus.Text = $"Connected to {_connectedPort.PortName} @ {_connectedPort.BaudRate} baud";
                    SetupSerialPort();
                }
                else
                {
                    labelStatus.Text = "No connection established.";
                }
            }
        }

        private void SetupSerialPort()
        {
            if (_connectedPort != null && _connectedPort.IsOpen)
            {
                _connectedPort.DataReceived += DataReceivedHandler;
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (_connectedPort != null)
            {
                int bytesToRead = _connectedPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                _connectedPort.Read(buffer, 0, bytesToRead);
                ProcessAx25Data(buffer);
            }
        }

        private void ProcessAx25Data(byte[] data)
        {
            byte[] unescapedData = UnescapeKissFrame(data);
            if (unescapedData.Length < 14) // AX.25 frame is at least 14 bytes
            {
                return; // Invalid frame length
            }

            // Decode the AX.25 frame
            string destinationCall = DecodeCallsign(unescapedData, 0);
            string sourceCall = DecodeCallsign(unescapedData, 7);
            byte control = unescapedData[14];
            byte pid = unescapedData[15];
            string message = Encoding.ASCII.GetString(unescapedData, 16, unescapedData.Length - 16);

            // Display decoded data
            string decodedMessage = $"Destination: {destinationCall}\nSource: {sourceCall}\nControl: {control}\nPID: {pid}\nMessage: {message}";
            if (InvokeRequired)
            {
                Invoke(new Action(() => textBoxReceivedData.AppendText(decodedMessage + Environment.NewLine)));
            }
            else
            {
                textBoxReceivedData.AppendText(decodedMessage + Environment.NewLine);
            }
        }

        private byte[] UnescapeKissFrame(byte[] data)
        {
            List<byte> unescapedData = new List<byte>();
            bool isEscaping = false;

            foreach (byte b in data)
            {
                if (isEscaping)
                {
                    if (b == 0xDC) // 0xDB followed by 0xDC
                    {
                        unescapedData.Add(0xC0); // Revert to 0xC0
                    }
                    else if (b == 0xDD) // 0xDB followed by 0xDD
                    {
                        unescapedData.Add(0xDB); // Revert to 0xDB
                    }
                    isEscaping = false;
                }
                else
                {
                    if (b == 0xDB) // Escape byte
                    {
                        isEscaping = true;
                    }
                    else
                    {
                        unescapedData.Add(b);
                    }
                }
            }

            return unescapedData.ToArray();
        }

        private string DecodeCallsign(byte[] data, int offset)
        {
            string callsign = "";
            for (int i = 0; i < 6; i++) // First 6 bytes are the callsign
            {
                char c = (char)(data[offset + i] >> 1); // Right shift to get the actual character
                callsign += c;
            }

            byte ssidByte = data[offset + 6]; // The last byte has the SSID info
            int ssid = (ssidByte >> 1) & 0x0F; // Extract SSID from the byte
            return callsign + (ssid != 0 ? "-" + ssid : "");
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_connectedPort != null && _connectedPort.IsOpen)
                {
                    _connectedPort.DataReceived -= DataReceivedHandler;
                    _connectedPort.Close();
                    labelStatus.Text = "Disconnected";
                    connectionToolStripMenuItem.Enabled = true;
                    disconnectToolStripMenuItem.Enabled = false;
                    _connectedPort = null;
                    MessageBox.Show("Disconnected from AX.25 network.", "Disconnect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No active connection to disconnect.", "Disconnect Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while disconnecting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            string sourceCallsign = tbCallsign.Text.ToUpper().Trim();
            string destCallsign = tbDestCallsign.Text.ToUpper().Trim();

            if (string.IsNullOrWhiteSpace(message) || string.IsNullOrWhiteSpace(sourceCallsign) || string.IsNullOrWhiteSpace(destCallsign))
            {
                MessageBox.Show("Please provide a message, source, and destination callsign.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedMessage = $"{timestamp} - {destCallsign} - {message} - From: {sourceCallsign}";
            textBoxReceivedData.AppendText(formattedMessage + Environment.NewLine);

            try
            {
                if (_connectedPort != null && _connectedPort.IsOpen)
                {
                    byte[] frame = BuildAX25Frame(destCallsign, sourceCallsign, message);
                    Debug.WriteLine("Sending KISS Frame (Hex): " + BitConverter.ToString(frame).Replace("-", " "));
                    _connectedPort.Write(frame, 0, frame.Length);
                }
                else
                {
                    MessageBox.Show("Serial port is not open or connected. Please connect to a serial port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] BuildAX25Frame(string destCallsign, string sourceCallsign, string message)
        {
            using (MemoryStream ax25 = new MemoryStream())
            {
                ax25.Write(EncodeCallsign(destCallsign, false), 0, 7);
                ax25.Write(EncodeCallsign(sourceCallsign, true), 0, 7);
                ax25.WriteByte(0x03); // Control field: UI Frame
                ax25.WriteByte(0xF0); // PID: No layer 3
                byte[] info = Encoding.ASCII.GetBytes(message);
                ax25.Write(info, 0, info.Length);

                byte[] rawFrame = ax25.ToArray();
                return BuildKissFrame(rawFrame);
            }
        }

        private byte[] BuildKissFrame(byte[] ax25Data)
        {
            using (MemoryStream kiss = new MemoryStream())
            {
                kiss.WriteByte(0xC0); // Start of KISS frame
                kiss.WriteByte(0x00); // KISS command: TX

                foreach (byte b in ax25Data)
                {
                    if (b == 0xC0)
                    {
                        kiss.WriteByte(0xDB);
                        kiss.WriteByte(0xDC);
                    }
                    else if (b == 0xDB)
                    {
                        kiss.WriteByte(0xDB);
                        kiss.WriteByte(0xDD);
                    }
                    else
                    {
                        kiss.WriteByte(b);
                    }
                }

                kiss.WriteByte(0xC0); // End of KISS frame
                return kiss.ToArray();
            }
        }

        private byte[] EncodeCallsign(string callsign, bool last)
        {
            byte[] encoded = new byte[7];
            string[] parts = callsign.Split('-');
            string baseCall = parts[0].ToUpper();
            int ssid = parts.Length > 1 ? int.Parse(parts[1]) : 0;

            // Pad with null bytes if the base callsign is shorter than 6 characters
            for (int i = 0; i < 6; i++)
            {
                if (i < baseCall.Length)
                {
                    encoded[i] = (byte)(baseCall[i] << 1);
                }
                else
                {
                    encoded[i] = 0x00; // Pad with null byte
                }
            }

            byte ssidByte = (byte)(((ssid & 0x0F) << 1) | 0x60);
            if (last)
                ssidByte |= 0x01;

            encoded[6] = ssidByte;
            return encoded;
        }

        private void ReceiveMessage(string receivedMessage)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string messageWithTimestamp = $"{timestamp} - Received: {receivedMessage}";
            textBoxReceivedData.AppendText(messageWithTimestamp + Environment.NewLine);
        }

        private void frmAX25Messenger_Load(object sender, EventArgs e)
        {
            // Any setup required during form load
        }
    }
}
