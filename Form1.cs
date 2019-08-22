using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using UartToFcb32.Properties;

namespace UartToFcb32
{
    public partial class UartToFCB : Form
    {
        public UartToFCB()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = Convert.ToInt32(Settings.Default["BaudRate"]);
            addressBox.Text = Settings.Default["Address"].ToString();
            dataBox.Text = Settings.Default["Data"].ToString();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            comboBox1.SelectedIndex = Convert.ToInt32(Settings.Default["ComPortNum"]);
            timer1.Start();

        }

        String LastName;
        static SerialPort Serial;

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = comboBox1.SelectedIndex; ;
            Settings.Default["ComPortNum"] = indx;
            Settings.Default.Save();
            String Name = ((string)comboBox1.SelectedItem);


            if (LastName == null)
            {
                LastName = Name;
                Serial = new SerialPort(Name, 115200, System.IO.Ports.Parity.None, 8, StopBits.One);
                if (Serial.IsOpen)
                {
                    LablePortOpen.Text = ("Порт недоступен");
                }
                else
                {
                    Serial.Open();
                    LablePortOpen.Text = ("Порт открыт");
                    //Serial.DataReceived += SerialPort_DataReceived;
                }
            }
            else
            {
                if (!String.Equals(LastName, Name))
                {
                    Serial.Close();
                    Serial = new SerialPort(Name, Convert.ToInt32((string)comboBox2.SelectedItem), System.IO.Ports.Parity.None, 8, StopBits.One);
                    if (Serial.IsOpen)
                    {
                        LablePortOpen.Text = ("Порт недоступен");
                    }
                    else
                    {
                        Serial.Open();
                        LablePortOpen.Text = ("Порт открыт");
                        // Serial.DataReceived += SerialPort_DataReceived;
                    }

                }
            }



        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = comboBox2.SelectedIndex; ;
            Settings.Default["BaudRate"] = indx;
            Settings.Default.Save();

            if (!(Serial == null))
            {
                Serial.BaudRate = Convert.ToInt32((string)comboBox2.SelectedItem);
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'x', 'a', 'b', 'c', 'd', 'e', 'f' };
            string s = addressBox.Text;
            char[] sn = new char[10];
            sn[0] = '0';
            sn[1] = 'x';

            if (s.Length > 10)
            {
                if (s.Length == 11)
                {
                    for (int i = 2; i < 10; i++)
                    {
                        sn[i] = s[i + 1];
                    }
                    addressBox.Text = new string(sn.Where(x => symbols.Contains(x)).ToArray());

                }
                else

                {
                    addressBox.Text = "0x00000000";
                }


            }
            if (s.Length < 10)
            {
                if (s.Length == 9)
                {
                    sn[2] = '0';
                    for (int i = 2; i < 9; i++)
                    {
                        sn[i + 1] = s[i];
                    }
                    addressBox.Text = new string(sn.Where(x => symbols.Contains(x)).ToArray());
                }
                else
                {
                    addressBox.Text = "0x00000000";
                }
            }
            addressBox.Select(10, 10);
            Settings.Default["Address"] = addressBox.Text;
            Settings.Default.Save();
        }

        private void DataBox_TextChanged(object sender, EventArgs e)
        {
            char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'x', 'a', 'b', 'c', 'd', 'e', 'f' };
            string s = dataBox.Text;
            char[] sn = new char[10];
            sn[0] = '0';
            sn[1] = 'x';
            if (s.Length > 10)
            {
                if (s.Length == 11)
                {
                    for (int i = 2; i < 10; i++)
                    {
                        sn[i] = s[i + 1];
                    }
                    dataBox.Text = new string(sn.Where(x => symbols.Contains(x)).ToArray());
                }
                else
                {
                    dataBox.Text = "0x00000000";
                }
            }
            if (s.Length < 10)
            {
                if (s.Length == 9)
                {
                    sn[2] = '0';
                    for (int i = 2; i < 9; i++)
                    {
                        sn[i + 1] = s[i];
                    }
                    dataBox.Text = new string(sn.Where(x => symbols.Contains(x)).ToArray());
                }
                else
                {
                    dataBox.Text = "0x00000000";
                }
            }
            dataBox.Select(10, 10);
            Settings.Default["Data"] = dataBox.Text;
            Settings.Default.Save();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
        }

        public void Write32(SerialPort Port, UInt32 Address, UInt32 Data)
        {
            byte comm = 2;

            byte[] AddrByteArray = BitConverter.GetBytes(Address);
            byte[] DataByteArray = BitConverter.GetBytes(Data);
            byte[] LenByteArray = BitConverter.GetBytes(0x00000001);
            byte[] ToPushByteArray = new byte[1 + AddrByteArray.Length + LenByteArray.Length + DataByteArray.Length];

            ToPushByteArray[0] = comm;
            AddrByteArray.CopyTo(ToPushByteArray, 1);
            LenByteArray.CopyTo(ToPushByteArray, 1 + AddrByteArray.Length);
            DataByteArray.CopyTo(ToPushByteArray, 1 + AddrByteArray.Length + LenByteArray.Length);

            Serial.Write(ToPushByteArray, 0, ToPushByteArray.Length);

            int buferSize = Port.BytesToRead;
            while (buferSize < 1)
            {
                buferSize = Port.BytesToRead;
            }

            byte RdData = Convert.ToByte(Serial.ReadByte());


        }
        public void Write32(SerialPort Port, UInt32 Address, UInt32[] Data, bool inc)
        {
            byte comm;
            if (inc)
                comm = 3;
            else
                comm = 2;

            byte[] AddrByteArray = BitConverter.GetBytes(Address);
            byte[] DataByteArray = new byte[4 * Data.Length];
            for (int i = 0; i < DataByteArray.Length / 4; i++)
            {
                BitConverter.GetBytes(Data[i]).CopyTo(DataByteArray, i * 4);
            }

            byte[] LenByteArray = BitConverter.GetBytes(Data.Length);
            byte[] ToPushByteArray = new byte[1 + AddrByteArray.Length + LenByteArray.Length + DataByteArray.Length];

            ToPushByteArray[0] = comm;
            AddrByteArray.CopyTo(ToPushByteArray, 1);
            LenByteArray.CopyTo(ToPushByteArray, 1 + AddrByteArray.Length);
            DataByteArray.CopyTo(ToPushByteArray, 1 + AddrByteArray.Length + LenByteArray.Length);

            Serial.Write(ToPushByteArray, 0, ToPushByteArray.Length);

            int buferSize = Port.BytesToRead;
            while (buferSize < 1)
            {
                buferSize = Port.BytesToRead;
            }

            byte RdData = Convert.ToByte(Serial.ReadByte());

        }
        public static UInt32 Read32(SerialPort Port, UInt32 Address)
        {
            byte comm = 0;
            byte[] AddrByteArray = BitConverter.GetBytes(Address);
            byte[] LenByteArray = BitConverter.GetBytes(0x00000001);
            byte[] ToPushByteArray = new byte[1 + AddrByteArray.Length + LenByteArray.Length];
            ToPushByteArray[0] = comm;
            AddrByteArray.CopyTo(ToPushByteArray, 1);
            LenByteArray.CopyTo(ToPushByteArray, 1 + AddrByteArray.Length);
            Serial.Write(ToPushByteArray, 0, ToPushByteArray.Length);


            int buferSize = Port.BytesToRead;
            while (buferSize < 4)
            {
                buferSize = Port.BytesToRead;
            }

            byte[] RdData = new byte[4];
            for (int i = 0; i < RdData.Length; i++)
            {
                RdData[i] = Convert.ToByte(Serial.ReadByte());
            }

            return BitConverter.ToUInt32(RdData, 0);


        }
        public static UInt32[] Read32(SerialPort Port, UInt32 Address, UInt32 DataLen, bool inc)
        {
            byte comm;
            if (inc)
                comm = 1;
            else
                comm = 0;
      
            byte[] AddrByteArray = BitConverter.GetBytes(Address);
            byte[] LenByteArray = BitConverter.GetBytes(DataLen);
            byte[] ToPushByteArray = new byte[1 + AddrByteArray.Length + LenByteArray.Length];
            ToPushByteArray[0] = comm;
            AddrByteArray.CopyTo(ToPushByteArray, 1);
            LenByteArray.CopyTo(ToPushByteArray, 1 + AddrByteArray.Length);
            Serial.Write(ToPushByteArray, 0, ToPushByteArray.Length);
      
            byte[] RdData = new byte[4];
            UInt32[] RdBuffer = new UInt32[DataLen];
            int buferSize = Port.BytesToRead;
            for (int i = 0; i < DataLen; i++)
            {
                while (buferSize < 4)
                {
                    buferSize = Port.BytesToRead;
                }
                for ( int j = 0; j < 4; j++)
                {
                    RdData[j] = Convert.ToByte(Serial.ReadByte());
                }
                RdBuffer[i] = BitConverter.ToUInt32(RdData, 0);
      
            }
       
            return RdBuffer;
      
      
        }

        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            uint AddrUint = uint.Parse(addressBox.Text.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier);
            uint DataUint = uint.Parse(dataBox.Text.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier);
            Write32(Serial, AddrUint, DataUint);
        }

        private void ButtonRead_Click(object sender, EventArgs e)
        {
            uint AddrUint = uint.Parse(addressBox.Text.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier);
            UInt32 RdData = Read32(Serial, AddrUint);
            byte[] RdDataByteArray = BitConverter.GetBytes(RdData);
            byte[] RdDataByteArrayC = new byte[RdDataByteArray.Length];
            for (int i = 0; i < RdDataByteArray.Length; i++ )
            {
                RdDataByteArrayC[i] = RdDataByteArray[RdDataByteArray.Length - 1 - i];
            }

            string str = BitConverter.ToString(RdDataByteArrayC);
            dataBox.Text = "0x" + str.Replace("-", ""); ;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            UInt32 AddrUint = uint.Parse(addressBox.Text.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier);
            UInt32[] DataArray = new UInt32[8];
            for (int i = 0; i < DataArray.Length; i++)
            {
                DataArray[i] = Convert.ToUInt32(i * 4);
            }
            Write32(Serial, AddrUint, DataArray, true);
        
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            uint AddrUint = uint.Parse(addressBox.Text.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier);
            UInt32[] RdData = Read32(Serial, AddrUint, 8, true);
        }

    }
}
