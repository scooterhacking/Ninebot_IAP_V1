using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace IAP
{
    public partial class Form1 : Form
    {
        Form About = new Form();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consoleOutput.AppendText("Console started.");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            // disable user closing the form, but no one else
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String pre = "5AA5";
            String input = textBox1.Text;
            int payloadLen;
            String origin = input.Substring(0, 2);
            String dest = input.Substring(2, 2);
            String cmd = input.Substring(4, 2);
            String arg = input.Substring(6, 2);
            int lenInput = input.Length;
            String payload = input.Substring(8, lenInput-8);
            payloadLen = payload.Length/2;
            String pass = payloadLen.ToString("X2") + "";
            String data = pass + origin + dest + cmd + arg + payload;
            byte[] dataButInByte = StringToByteArray(data);
            int payloadInt = CheckSum1ByteIn2ByteOut(dataButInByte, dataButInByte.Length);
            String checksumString = payloadInt.ToString("X2");
            checksumString = checksumString.Substring(2, 2) + checksumString.Substring(0, 2);
            String toSend = pre + pass + origin + dest + cmd + arg + payload + checksumString;
            IAP_Form form = new IAP_Form();
            consoleOutput.AppendText(Environment.NewLine + "Sent by user: " + toSend);
            form.sendUserCommand(StringToByteArray(toSend), 0, StringToByteArray(toSend).Length);
        }
        private ushort CheckSum1ByteIn2ByteOut(byte[] data, int len)
        {
            ushort checksum = 0;
            Debug.Assert(null != data);
            for (int i = 0; i < len; i++)
            {
                checksum += data[i];
            }
            checksum = (ushort)(~checksum);
            return checksum;
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            About.Show();
        }
    }
}
