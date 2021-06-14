using Microsoft.Build.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {

          private string UDPrequest = "searchServer__v1.0";
          private TimeSpan timeToWait = TimeSpan.FromSeconds(5);
          private string ipAddress = null;
          private int broadcastPort = 50050;

        
        public static  int HEADS_UP = 11;
        public static  int UPLOAD_ACK = 41;


        public Form1()
        {
            InitializeComponent();       
            FindServer(); // FIND SERVER BY UDP          
      }

       

        private void FindServer()
        {
            var Client = new UdpClient();
            var RequestData = Encoding.ASCII.GetBytes(UDPrequest);
            var ServerEp = new IPEndPoint(IPAddress.Any, 0);

             Client.EnableBroadcast = true;
             Client.Send(RequestData, RequestData.Length, new IPEndPoint(IPAddress.Broadcast,this.broadcastPort));

            var asyncResult = Client.BeginReceive(null, null);
            asyncResult.AsyncWaitHandle.WaitOne(timeToWait);

            if (asyncResult.IsCompleted)
            {
                try
                {
                    IPEndPoint remoteEP = null;
                    byte[] receivedData = Client.EndReceive(asyncResult, ref remoteEP);
                    Console.WriteLine(Encoding.ASCII.GetString(receivedData));
                    Console.WriteLine(remoteEP.Address);
                    this.ip_list_component.Items.Clear();
                    this.ip_list_component.Items.Add(remoteEP.Address);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:"+ex.Message);

                }
            }
            else
            {

            }

            Client.Close();
        }

       

   

        //Upload Test
        public void uploadTest()

        {
            csvFile csvData = new csvFile("Upload_test");

            progressBar.Value = 0;
            var ip = ip_list_component.SelectedItem.ToString();
            long lengthPacket = long.Parse(upload_packet_size.Text);


            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(ip, 53405);
            NetworkStream stream = client.GetStream();
            client.ReceiveTimeout = 600000;

            string textToSend = "upload="+upload_packet_size.Text;
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
          
            stream.Write(bytesToSend, 0, bytesToSend.Length);


            
            byte[] packet = new byte[lengthPacket];
            stream.Write(packet, 0, packet.Length);
            

            // Begining of the loop

            int offset = 0;
            int totalLenght = 0;

  
            int totalReadBytes = 0;

        
            int speed = 0;
            byte[] buffer;
            int index = 1;
            int numberTotal = 1;
            while (true)
            {
                bool breakWhile = false;

                try
                {


                    buffer = new byte[client.ReceiveBufferSize];
                    //---read incoming stream---
                    int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);

                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    // byte[] ack = new byte[UPLOAD_ACK];

                   

                    // Console.WriteLine(dataReceived);
                    if (dataReceived.Length > 3 && dataReceived.Substring(0,3) == "ACK")                       
                    {
                        int bytesReading = 0;
                         speed = 0;
                        
                      
                          string[] array = dataReceived.Split(new string[] { "ACK=" }, StringSplitOptions.None);
                        foreach (string t in array)
                        {

                            if (t == "END") { breakWhile = true; progressBar.Value = 100; }
                            string[] arrayData = t.Split(',');
                            if (arrayData.Length == 2)
                            {
                                int.TryParse(arrayData[0], out bytesReading);
                                int.TryParse(arrayData[1], out speed);
                            }
                            if (bytesReading != 0)
                            {
                                
                                double val = (numberTotal / (double)lengthPacket) * 100;
                                if((int)val <=100)progressBar.Value = (int)val;
                              
                                    listView1.Items.Add("Upload log | Actual Length=" + totalReadBytes.ToString() + " | Speed=" + speed);
                                    csvData.addToData(totalReadBytes, speed);
                                    totalReadBytes += bytesReading;


                                if (speed != 0) { numberTotal += speed; index++; }
                             
                            }
                            
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
   


                if (breakWhile) break;
              
            }
            packet_size.Text = lengthPacket.ToString();
            avg_speed.Text = (numberTotal / index).ToString();

            csvData.saveToCSV();

            Console.WriteLine("AVG="+numberTotal / index);
            stream.Close();
            Console.WriteLine("TOTAL" + totalLenght);
            client.Close();


        }



        // Download Test
        public void downloadTest() 
        {
            
            progressBar.Value = 0;
            csvFile csvData = new csvFile("Download_test");

            // SendMessage();
            int lengthPacket = int.Parse(download_packet_size.Text);
            var ip = ip_list_component.SelectedItem.ToString();

              //---create a TCPClient object at the IP and port no.---
              TcpClient client = new TcpClient(ip, 53405);
              NetworkStream stream = client.GetStream();
            client.ReceiveTimeout = 600000;
            Console.WriteLine("Downlod test");

            string textToSend = "length="+ download_packet_size.Text;
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            Console.WriteLine("Sending : " + textToSend);
            stream.Write(bytesToSend, 0, bytesToSend.Length);


   
    
            // Begining of the loop

            int offset = 0;
            int totalLenght = 0;

            // byte[] buffer = new byte[1024*1024*100]; 
            int actualReadBytes = 0;
                
            Stopwatch stopwatch = new Stopwatch();
            int speed = 0;
            byte[] buffer;
            int index = 1;
 
            int totalSpeed =0;
            
            while (true)
            {              
                    stopwatch.Reset();
                    stopwatch.Start();
                    try
                    {
                    byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                    actualReadBytes = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);

                    totalLenght += actualReadBytes;

                    }catch(Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    }
               // Console.WriteLine("total=" + totalLenght);
               
                    offset += actualReadBytes;
                double val = (totalLenght / (double)lengthPacket) * 100;
                progressBar.Value = (int)val;
               
                //Console.WriteLine(actualReadBytes);
                stopwatch.Stop();
                //Console.WriteLine(stopwatch.ElapsedMilliseconds);
                if (stopwatch.ElapsedMilliseconds != 0)
                {
                    speed = (actualReadBytes * 8) / (int)stopwatch.ElapsedMilliseconds; // kbps
                    totalSpeed += speed;
                    index++;
                  //  Console.WriteLine(speed);
                    listView1.Items.Add("Download log | Actual Length=" +totalLenght.ToString() + " | Speed="+speed);
                    csvData.addToData(totalLenght, speed);

                    //Console.WriteLine(offset + "=offset");
                }
                if (totalLenght == lengthPacket) break;

            }

          //  Console.WriteLine("TOTAL"+totalLenght);

            packet_size.Text = lengthPacket.ToString();
            avg_speed.Text = (totalSpeed / index).ToString();
           // Console.WriteLine("AVG" + (totalSpeed/index));

            csvData.saveToCSV();
           

            stream.Close();
              client.Close();
            
        }

       




private void button1_Click(object sender, EventArgs e)
        {       
          downloadTest();

    }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            FindServer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uploadTest();
        }

        private void download_packet_size_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
