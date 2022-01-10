using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace Proftaak
{
    class Port
    {
        private SerialPort mySerialPort;

        public Action<byte[]> DataReceived;

        public void openPort()
        {
            mySerialPort = new SerialPort("COM5");
            mySerialPort.DataReceived += mySerialPort_DataReceived;
            mySerialPort.Open();
        }
        public void closePort()
        {
            mySerialPort.Close();
        }
        public void WriteBack(string data)
        {
            mySerialPort.WriteLine(data);
        }

        public void mySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //no. of data at the port
                int ByteToRead = mySerialPort.BytesToRead;

                //create array to store buffer data
                byte[] inputData = new byte[ByteToRead];

                //read the data and store
                mySerialPort.Read(inputData, 0, ByteToRead);

                var copy = DataReceived;
                if (copy != null) copy(inputData);

            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Data Received Event");
            }
        }
    }
}
