//SaddleCam is used to capture images of saddles and save them locally as well as to a folder on the
//network. Currently the network folder can be found at \\gra-fs1\CustServ_cls-app1\SaddleCam
//and the local folder can be found at CurrentDirectory\pic Besides saving
//it also logs locally images and errors resulting from the program. The planned set up includes a 
//barcode scanner, a webcam, and a button. The scanner is used to read in a RW number (RW128359), the button 
//is programmed to input a '`' and after the RW number + the ` is inputted or OR followed by two '`'
//the webcam captures the current frame and saves it. Also programs RDIF tags with a returned serial 
//or if one is not found a 99 followed by the numeric values of a given OR or RW.
//
//If you have moved this from one computer to another or if the file dir has changed type reseat and
//press the clear button in app. If you need to troubleshoot a problem such as if a webcam is connected
//type dev and press clear, this will open in a web browser the dev view, also accessable as local.
//
//Author - Blayne Kennedy
//Last updated - 02/18/16
//Contact - diveblk@gmail.com
//
//Used in conjunction with Microsoft Robotics Developer Studio 4: Sample webcam - for webcam services
//Download can be found here: https://www.microsoft.com/en-us/download/details.aspx?id=29081
//Using OpenCV and the C# wrapper EMGU
//Emgucv x64 ver 2.4.10.1: https://www.nuget.org/packages/VDK.EmguCV.x64/
//Emgucv 2.2.1 x64 ver 1.5: https://www.nuget.org/packages/EmguCV.221.x64/
//Opencv 2.2.0 x 64 ver 1.0.2: https://www.nuget.org/packages/OpenCV.220.x64/
//Opencv.net ver 3.3.0: https://www.nuget.org/packages/OpenCV.Net/
//AlienRFID2 ver 2.3.2.0 can be found here ftp://ftp.alientechnology.com//pub/readers/software/sdk/net/Alien_dotNET_SDK_2.3.2_2013-02.zip

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Globalization;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;

using Emgu;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

using nsAlienRFID2;

namespace SaddleWebCam
{
    public partial class Form1 : Form
    {
        enum eReaderType
        {
            x780,
            x800,
            x900
        }
        eReaderType meReaderType = eReaderType.x900;
        private ComInterface meReaderInterface = ComInterface.enumTCPIP;
        private clsReader mReader;
        private ReaderInfo mReaderInfo;
        private String msTags;

        public Form1()
        {
            InitializeComponent();
        }
        static string log = string.Empty;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string objTextBox = textBox1.Text;
            string picPath = Directory.GetCurrentDirectory() + @"\" + "pic" + @"\";//file dirs paths
            string picDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\";
            string logDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\" + "log.txt";
            
            if (objTextBox.Length.Equals(10))
            {
                int good = 0;
                label1.Text = "";
                pictureBox1.Image = null;

                if ((objTextBox.Substring(0, 2).Equals("RW")) & (objTextBox.Substring(9, 1).Equals("`")))
                {
                    good = 1;
                    createDir();

                    try//first try to capture a frame
                    {
                        label1.Text = "Trying to Save Image: Please Wait...";
                        label1.ForeColor = System.Drawing.Color.Black;
                        log += Environment.NewLine;
                        log += DateTime.Now.ToString("yyyyMMddhhmmss") + Environment.NewLine;

                        saveImg();
                    }

                    catch (Exception y)//second try to capture frame, hits this if the webcame service is not running and starts it
                    {
                        String env = @"Start C:\Windows\SysWOW64\cmd.exe /K """ + Directory.GetCurrentDirectory() + @"\Man\env.cmd"" ";

                        Console.WriteLine("Trying to start webcam service");
                        label1.Text = "Trying to start webcam service: Please Wait...";
                        label1.ForeColor = System.Drawing.Color.Black;
                        System.Diagnostics.Process.Start("CMD.exe", env);
                        System.Threading.Thread.Sleep(1000);

                        SendKeys.SendWait("dsshost32 /p:50000 /t:50001 /m:WebCam.manifest.xml");
                        SendKeys.SendWait("{ENTER}");
                        this.Activate();
                        System.Threading.Thread.Sleep(10000);

                        log += "Had to start webcam service" + Environment.NewLine;

                        try
                        {
                            saveImg();
                        }

                        catch (Exception yy)//last chance to capture frame
                        {
                            log += "Webcam service is not starting correctly: " + yy + Environment.NewLine + Environment.NewLine;
                            label1.ForeColor = System.Drawing.Color.Red;
                            label1.Text = "Unable to save image";
                        }
                    }
                    textBox1.Clear();
                    try//writes the log file
                    {
                        File.AppendAllText(logDatePath, log);
                        log = string.Empty;
                    }
                    catch
                    {

                    }
                }

                if ((objTextBox.Substring(0, 2).Equals("OR")) & (objTextBox.Substring(9, 1).Equals("`")))
                {
                    good = 1;

                    createDir();

                    try//first try to capture a frame
                    {
                        label1.Text = "Trying to Save Image: Please Wait...";
                        label1.ForeColor = System.Drawing.Color.Black;
                        log += Environment.NewLine;
                        log += DateTime.Now.ToString("yyyyMMddhhmmss") + Environment.NewLine;

                        saveImg();
                    }

                    catch (Exception y)//second try to capture frame, hits this if the webcame service is not running and starts it
                    {
                        String env = @"Start C:\Windows\SysWOW64\cmd.exe /K """ + Directory.GetCurrentDirectory() + @"\Man\env.cmd"" ";

                        Console.WriteLine("Trying to start webcam service");
                        label1.Text = "Trying to start webcam service: Please Wait...";
                        label1.ForeColor = System.Drawing.Color.Black;
                        System.Diagnostics.Process.Start("CMD.exe", env);
                        System.Threading.Thread.Sleep(1000);

                        SendKeys.SendWait("dsshost32 /p:50000 /t:50001 /m:WebCam.manifest.xml");
                        SendKeys.SendWait("{ENTER}");
                        this.Activate();
                        System.Threading.Thread.Sleep(10000);

                        log += "Had to start webcam service" + Environment.NewLine;

                        try
                        {
                            saveImg();
                        }

                        catch (Exception yy)//last chance to capture frame, this will kill the webcam process and try to recompile the process. Such as if dirs of the app have changed.
                        {
                            log += "Webcam service is not starting correctly: " + yy + Environment.NewLine + Environment.NewLine;
                            label1.ForeColor = System.Drawing.Color.Red;
                            label1.Text = "Unable to save image";
                        }
                    }
                    textBox1.Clear();
                    try//writes the log file
                    {
                        File.AppendAllText(logDatePath, log);
                        log = string.Empty;
                    }
                    catch
                    {

                    }
                }
                if (good == 0)
                {
                    label1.Text = "Invalid entry, Image not saved.";
                    label1.ForeColor = System.Drawing.Color.Red;
                    pictureBox1.Image = null;
                    textBox1.Clear();
                } 
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RFIDConnect()
        {
            string value = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @"\Values.txt");
            string[] values = value.Split('"');
            String result;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (meReaderInterface == ComInterface.enumTCPIP)
                    mReader.InitOnNetwork(values[1], Int32.Parse(values[3]));
                else
                    mReader.InitOnCom();

                label1.Text = "Connecting to the reader...";
                this.Cursor = Cursors.WaitCursor;

                result = mReader.Connect();
                if (mReader.IsConnected)
                {
                    if (meReaderInterface == ComInterface.enumTCPIP)
                    {
                        label1.Text = "Logging in...";
                        this.Cursor = Cursors.WaitCursor;
                        if (!mReader.Login(values[5], values[7]))
                        {
                            label1.Text = "Login failed!";
                            mReader.Disconnect();
                            return;             
                        }
                    }
                    mReader.AutoMode = "On";
                }
                label1.Text = result;
            }
            catch (Exception ex)
            {
                label1.Text = "Exception in Starting RFID Service" + ex.Message;
                log += "Exception in Starting RFID Service: " + ex.Message + Environment.NewLine;
            }
            this.Cursor = Cursors.Default;
        }

        private void RFIDSave(String Serial)
        {
            String temp;
            try
            {
                temp = Serial;
                if (temp.Length % 2 != 0)
                {
                    temp = temp + "0";
                }
                if (temp.Length % 4 != 0)
                {
                    temp = temp + "00";
                }
                log += "Set RFID: " + temp + Environment.NewLine;
                mReader.ProgramUser(Regex.Replace(temp, @"(.{2})", "$1 "));
            }

            catch (Exception ex)
            {
                log += "Error with RFID: " + Serial + ex + Environment.NewLine + Environment.NewLine;
            }
        }

        private void RFIDLock()
        {
            try
            {
                mReader.Lock(eLockTarget.User, "Blayne");   
            }
            catch (Exception ex)
            {
                log += "Error with Locking RFID: " + ex + Environment.NewLine + Environment.NewLine;
            }
        }

        private String SaddleSerial(String RW)
        {
            SqlConnection conn = new SqlConnection("user id=PackUser;data source=;persist security info=True;initial catalog=;password=");

            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetSaddleSer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RWID", RW));
                conn.Open();
                SqlDataAdapter sqlDA2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                sqlDA2.Fill(dt2);

                String SerNum = dt2.Rows[0]["Serial No_"].ToString();

                return SerNum;
            }
            catch (Exception ex)
            {
                log += "Error with getting Serial: " + ex + Environment.NewLine + Environment.NewLine;
            }
            return RW;
        }

        public string ASCIITOHex(string ascii)
        {
            StringBuilder sb = new StringBuilder();
            byte[] inputBytes = Encoding.UTF8.GetBytes(ascii);

            foreach (byte b in inputBytes)
            {
                sb.Append(string.Format("{0:x2}", b) + " ");
            }
            return sb.ToString();
        }

        private void saveImg()
        {
            string objTextBox = textBox1.Text;
            string serial;
            string picPath = Directory.GetCurrentDirectory() + @"\" + "pic" + @"\";//dirs paths
            string picPathNetwork = @"\\gra-fs1\CustServ_cls-app1\SaddleCam" + @"\";
            string picDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\";
            string logDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\" + "log.txt";

            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;

            serial = SaddleSerial(objTextBox.Replace("`", ""));

            if (serial.Length > 5)
            {
                webClient.DownloadFile("http://localhost:50000/webcam/jpg", picDatePath + serial + ".jpg");
            }
            else
            {
                webClient.DownloadFile("http://localhost:50000/webcam/jpg", picDatePath + objTextBox.Replace("`", "") + ".jpg");
            }

            try
            {
                if (serial.Length > 5)
                {
                    webClient.DownloadFile("http://localhost:50000/webcam/jpg", picPathNetwork + serial + ".jpg");
                }
                else
                {
                    webClient.DownloadFile("http://localhost:50000/webcam/jpg", picPathNetwork + objTextBox.Replace("`", "") + ".jpg");
                }
            }
            catch (Exception zz)
            {
                log += "Could not access network drive. Error: " + zz + Environment.NewLine;
            }

            try
            {
                if (serial.Length > 5)
                {
                        RFIDSave(serial);
                }
                else
                {
                        RFIDSave("99" + objTextBox.Replace("`", "").Substring(2));
                }
            }
            catch (Exception ex)
            {
                log += "Could not save RFID serial. Error: " + ex + Environment.NewLine;
            }

           

            try
            {
                if (serial.Length > 5)
                {
                    FileStream fs = new System.IO.FileStream(picDatePath + serial + ".jpg", FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = Image.FromStream(fs);

                    fs.Close();
                }
                else
                {
                    FileStream fs = new System.IO.FileStream(picDatePath + objTextBox.Replace("`", "") + ".jpg", FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = Image.FromStream(fs);

                    fs.Close();
                }
            }

            catch (Exception ex)
            {
                log += "Could not access picture in dir: " + ex + Environment.NewLine;
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label1.Text = "Image Saved: " + objTextBox.Replace("`", "");
            label1.ForeColor = System.Drawing.Color.Green;
            log += "Image Saved: " + objTextBox.Replace("`", "") + Environment.NewLine;
        }

        private void createDir()
        {
            string objTextBox = textBox1.Text;
            string picPath = Directory.GetCurrentDirectory() + @"\" + "pic" + @"\";//file dirs paths
            string picDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\";
            string logDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\" + "log.txt";

            try//creates local dirs for logging and backup pics ordered by dated folders
            {
                if (!Directory.Exists(picPath))
                {
                    try
                    {
                        Directory.CreateDirectory(picPath);
                    }
                    catch (Exception yz)
                    {
                        Console.WriteLine("Error creating pic dir: " + yz);
                        log += "Error creating pic dir: " + yz + Environment.NewLine;
                    }
                }
                if (!Directory.Exists(picDatePath))
                {
                    try
                    {
                        Directory.CreateDirectory(picDatePath);
                    }
                    catch (Exception yz)
                    {
                        Console.WriteLine("Error creating pic date dir: " + yz);
                        log += "Error creating pic date dir: " + yz + Environment.NewLine;
                    }
                }
                if (!File.Exists(logDatePath))
                {
                    StreamWriter sw = File.CreateText(logDatePath);
                    sw.Close();
                }
            }
            catch (Exception yx)
            {
                Console.WriteLine("Could not create dir. Error: " + yx);
            }
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
        }

        private void reseat()//This will kill the webcam process and try to recompile the process. Such as if dirs of the app have changed.
        {
            string picPath = Directory.GetCurrentDirectory() + @"\" + "pic" + @"\";//file dirs paths
            string picDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\";
            string logDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\" + "log.txt";
            string objTextBox = textBox1.Text;

            String env = @"Start C:\Windows\SysWOW64\cmd.exe /K """ + Directory.GetCurrentDirectory() + @"\Man\env.cmd"" ";

            log += "Starting reseating process." + Environment.NewLine;

            try
            {
                foreach (var process in Process.GetProcessesByName("DssHost32"))
                {
                    process.Kill();
                }
                foreach (var process in Process.GetProcessesByName("cmd"))
                {
                    process.Kill();
                }

                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Man\store"))
                {
                    Directory.Delete(Directory.GetCurrentDirectory() + @"\Man\store", true);
                }

                Console.WriteLine("Trying to remove cache and start webcam services");
                System.Diagnostics.Process.Start("CMD.exe", env);
                System.Threading.Thread.Sleep(1000);

                SendKeys.SendWait("dsshost32 /p:50000 /t:50001 /m:WebCam.manifest.xml");
                SendKeys.SendWait("{ENTER}");
                System.Threading.Thread.Sleep(10000);
                log += "Had to remove cache and start webcam service" + Environment.NewLine;    
            }

            catch (Exception y)
            {
                log += "Unable to start webcam service: " + y + Environment.NewLine;
                label1.Text = "Unable to save image";
                label1.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                File.AppendAllText(logDatePath, log);
                log = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("dev"))//opens the webcam service
            {
                System.Diagnostics.Process.Start("http://localhost:50000/");
            }
            if (textBox1.Text.Equals("test"))
            {
                string path = Directory.GetCurrentDirectory();
                Console.WriteLine("The current directory is {0}", path);
            }
            if (textBox1.Text.Equals("cat"))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Man\bin\nyan-cat.gif");
                }
                catch
                {

                }
            }
            if (textBox1.Text.Equals("joe"))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Man\bin\joe.jpg");
                }
                catch
                {

                }
            }
            if (textBox1.Text.Equals("reseat"))
            {
                reseat();
            }
            textBox1.Clear();
            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                mReader = new clsReader(true);
                ComInterface meReaderInterface = ComInterface.enumTCPIP;
                mReaderInfo = mReader.ReaderSettings;

                RFIDConnect();
            }
            catch (Exception y)
            {
                log += "Unable to start RFID service: " + y + Environment.NewLine;
                label1.Text = "Unable to start RFID Service";
                label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
