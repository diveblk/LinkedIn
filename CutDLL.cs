using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using Emgu;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;


    public class CutProgram : MarshalByRefObject
    {
        public string weight;
        public CutProgram()
    {
        
    }


        static string log = string.Empty;

        public double[] Run(int runs)
        {
            double sqInchs = 0;
            double sqInchsPrim = 0;
            double sqInchsTotal = 0;
            double sqInchsHoles = 0;
            double[] sqInchsCur;
            string color = "";
            string fmt = "000.##";
            string formatString = " {0,3:" + fmt + "}";
            string date = "";
            int colorNum = 0;
            int holes = 0;
            string[] fileValuesAr;
            int[] fileVal;
            double[] returnValues;

            returnValues = new double[10];

            string fileValues = Regex.Replace(System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @"\Values.txt"), "[^0-9.\\s]", "");
            fileValues = fileValues.Replace(System.Environment.NewLine, " ");
            string[] separators = { " " };
            fileValuesAr = fileValues.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            fileVal = Array.ConvertAll(fileValuesAr, s => int.Parse(s));

            CutProgram cut = new CutProgram();


            for (int x = 0; x < runs; x++)
            {
                if (x.Equals(0))
                {
                    date = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");

                    log += Environment.NewLine;

                    log += date + Environment.NewLine;
                    sqInchsCur = cut.GetSqInch(date, fileVal);
                    sqInchs = sqInchs + sqInchsCur[0];
                    sqInchsPrim = sqInchsPrim + sqInchsCur[1];
                    sqInchsTotal = sqInchsTotal + sqInchsCur[2];
                    sqInchsHoles = sqInchsHoles + sqInchsCur[3];
                    System.Threading.Thread.Sleep(300);
                }
                else
                {
                    date = "";
                    sqInchsCur = cut.GetSqInch(date, fileVal);
                    sqInchs = sqInchs + sqInchsCur[0];
                    sqInchsPrim = sqInchsPrim + sqInchsCur[1];
                    sqInchsTotal = sqInchsTotal + sqInchsCur[2];
                    sqInchsHoles = sqInchsHoles + sqInchsCur[3];
                    System.Threading.Thread.Sleep(300);
                }
            }

            if (cut.leatherColor(fileVal[12], fileVal[13], fileVal[14], fileVal[15], fileVal[16], fileVal[17], fileVal).Equals(true))//chestNut
            {
                color += "Chest Nut ";
                colorNum += 1;
            }

            if (cut.leatherColor(fileVal[18], fileVal[19], fileVal[20], fileVal[21], fileVal[22], fileVal[23], fileVal).Equals(true))//natural
            {
                color += "Natural ";
                colorNum += 10;
            }

            if (cut.leatherColor(fileVal[24], fileVal[25], fileVal[26], fileVal[27], fileVal[28], fileVal[29], fileVal).Equals(true))//black
            {
                color += "Black ";
                colorNum += 100;
            }

            if (colorNum.Equals(0))
            {
                color = "Unknown";
            }

            returnValues[0] = sqInchs / runs;
            returnValues[1] = sqInchsPrim / runs;
            returnValues[2] = sqInchsTotal / runs;
            returnValues[3] = colorNum;




            if (sqInchsHoles > 0)
            {
                //Console.WriteLine("Holes: True");
                holes = 1;
            }
            else
            {
                //Console.WriteLine("Holes: False");
            }

            returnValues[4] = holes;

            log += "Total Area Avg: " + (sqInchs / 4) + " Prim: " + (sqInchsPrim / 4) + " Total: " + (sqInchsTotal / 4) + " Colors: " + colorNum.ToString(fmt) + Environment.NewLine;
            log += "SQL " + (sqInchs / 4).ToString() + " " + (sqInchsPrim / 4).ToString() + " " + (sqInchsTotal / 4).ToString() + " " + colorNum.ToString(fmt) + " " + holes.ToString() + Environment.NewLine;
            File.AppendAllText(Directory.GetCurrentDirectory() + @"\" + "pic" + @"\" + DateTime.Today.ToString("d").Replace("/", "-") + @"\" + "log.txt", log);

            return returnValues;
        }

        public string getWeight(string command)
        {
            string weight = string.Empty;
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\ComPort.txt");

            string comPort = sr.ReadLine();
            SerialPort sp = new SerialPort();

            try
            {
                sp.ReadTimeout = 500;
                sp.WriteTimeout = 500;
                sp.BaudRate = 9600;
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.PortName = comPort;
                sp.StopBits = StopBits.One;
                sp.ReadTimeout = 9999;
                sp.Handshake = Handshake.None;
                sp.Open();
                sp.Write(command);
                Thread.Sleep(100);
                string message = sp.ReadExisting();
                weight = message.Split('+')[1].Trim().Replace("lb","");
            }
            finally
            {
                sp.Close();
            }
            return weight;
        }


        public double[] GetSqInch(String savePic, int[] fileVal)
        {
            double sizeMax = 0;
            double sizeMaxPrim = 0;
            double sizeMin = 0;
            double sizeCal = 0;
            double sizeCalPrim = 0;
            double totalCal = 4;
            double totalMax = 0;
            double holes = 0;
            double pxPerSqInch = 0;
            double pxPerInch = 0;
            double[] values;
            int pxCal = fileVal[30];//+ or - to adjust for total px per sq inch
            int areaSqInch = 0;
            string pxPerSqInchFilePath = Directory.GetCurrentDirectory() + @"\" + "int.txt";
            string picPath = Directory.GetCurrentDirectory() + @"\" + "pic" + @"\";
            string picDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\";
            string logDatePath = picPath + DateTime.Today.ToString("d").Replace("/", "-") + @"\" + "log.txt";
            Image<Bgr, Byte> Frame = null;
            Image<Bgr, Byte> FrameNormal = null;
            Image<Bgr, Byte> FrameCal = null;
            Image webImage = null;

            values = new double[5];

            try
            {
                WebRequest requestPic = WebRequest.Create("http://localhost:50000/webcam/jpg");
                requestPic.UseDefaultCredentials = true;
                WebResponse responsePic = requestPic.GetResponse();

                webImage = Image.FromStream(responsePic.GetResponseStream());

                //webImage = Image.FromFile(Directory.GetCurrentDirectory() + @"\lathers\natural.jpg");

                using (Graphics g = Graphics.FromImage(webImage))//Crops the image, note if aspect ratio changes too much then the equation for the calibration artifact must change when looking for a perfect sq
                {
                    g.DrawImage(webImage, new Rectangle(0, 0, webImage.Width, webImage.Height),
                        //new Rectangle(0, 0, webImage.Width, webImage.Height),//crop with values here
                        //new Rectangle(0 + fileVal[33], 0 + fileVal[35], webImage.Width - fileVal[34], webImage.Height - fileVal[36]),//crop with values here
                                     new Rectangle(fileVal[33], fileVal[35], webImage.Width - (fileVal[34] + fileVal[33]), webImage.Height - (fileVal[36] + fileVal[35])),
                                     GraphicsUnit.Pixel);
                }

                Frame = new Image<Bgr, Byte>((Bitmap)webImage);
                FrameCal = Frame;
                FrameNormal = new Image<Bgr, Byte>((Bitmap)webImage);
            }

            catch (Exception y)
            {
                String env = @"Start C:\Windows\SysWOW64\cmd.exe /K """ + Directory.GetCurrentDirectory() + @"\Man\env.cmd"" ";

                Console.WriteLine("Trying to start webcam service");
                System.Diagnostics.Process.Start("CMD.exe", env);
                System.Threading.Thread.Sleep(1000);

                SendKeys.SendWait("dsshost32 /p:50000 /t:50001 /m:WebCam.manifest.xml");
                SendKeys.SendWait("{ENTER}");
                System.Threading.Thread.Sleep(10000);

                log += "Had to start webcam service" + Environment.NewLine;

                try
                {
                    WebRequest requestPic2 = WebRequest.Create("http://localhost:50000/webcam/jpg");
                    requestPic2.UseDefaultCredentials = true;
                    WebResponse responsePic = requestPic2.GetResponse();

                    webImage = Image.FromStream(responsePic.GetResponseStream());

                    using (Graphics g = Graphics.FromImage(webImage))//Crops the image, note if aspect ratio changes too much then the equation for the calibration artifact must change when looking for a perfect sq
                    {
                        g.DrawImage(webImage, new Rectangle(0, 0, webImage.Width, webImage.Height),
                            //new Rectangle(0, 0, webImage.Width, webImage.Height),//crop with values here
                            //new Rectangle(0 + fileVal[33], 0 + fileVal[35], webImage.Width - fileVal[34], webImage.Height - fileVal[36]),
                                         new Rectangle(fileVal[33], fileVal[35], webImage.Width - (fileVal[34] + fileVal[33]), webImage.Height - (fileVal[36] + fileVal[35])),
                                         GraphicsUnit.Pixel);
                    }

                    Frame = new Image<Bgr, Byte>((Bitmap)webImage);
                    FrameCal = Frame;
                    FrameNormal = new Image<Bgr, Byte>((Bitmap)webImage);
                }

                catch (Exception yy)
                {
                    log += "Webcam service is not starting correctly: " + yy + Environment.NewLine + "Trying to delete service search path cache." + Environment.NewLine;

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
                        WebRequest requestPic2 = WebRequest.Create("http://localhost:50000/webcam/jpg");
                        requestPic2.UseDefaultCredentials = true;
                        WebResponse responsePic = requestPic2.GetResponse();

                        webImage = Image.FromStream(responsePic.GetResponseStream());

                        using (Graphics g = Graphics.FromImage(webImage))//Crops the image, note if aspect ratio changes too much then the equation for the calibration artifact must change when looking for a perfect sq
                        {
                            g.DrawImage(webImage, new Rectangle(0, 0, webImage.Width, webImage.Height),
                                //new Rectangle(0, 0, webImage.Width, webImage.Height),//crop with values here
                                //new Rectangle(0 + fileVal[33], 0 + fileVal[35], webImage.Width - fileVal[34], webImage.Height - fileVal[36]),
                                         new Rectangle(fileVal[33], fileVal[35], webImage.Width - (fileVal[34] + fileVal[33]), webImage.Height - (fileVal[36] + fileVal[35])),
                                             GraphicsUnit.Pixel);
                        }

                        Frame = new Image<Bgr, Byte>((Bitmap)webImage);
                        FrameCal = Frame;
                        FrameNormal = new Image<Bgr, Byte>((Bitmap)webImage);
                    }

                    catch (Exception yyy)
                    {
                        log += "Unable to start webcam service: " + yyy + Environment.NewLine;
                    }
                }
            }
            try
            {
                if (!File.Exists(pxPerSqInchFilePath))
                {
                    using (StreamWriter sw = File.CreateText(pxPerSqInchFilePath))
                    {
                        Console.WriteLine("File: " + pxPerSqInchFilePath + "Could not be found, file created with default 10000 px per sq inch");
                        sw.WriteLine("10000");
                    }
                }

                if (!Directory.Exists(picPath))
                {
                    try
                    {
                        Directory.CreateDirectory(picPath);
                    }
                    catch (Exception y)
                    {
                        Console.WriteLine("Error creating pic dir: " + y);
                        log += "Error creating pic dir: " + y + Environment.NewLine;
                    }
                }
                if (!Directory.Exists(picDatePath))
                {
                    try
                    {
                        Directory.CreateDirectory(picDatePath);
                    }
                    catch (Exception y)
                    {
                        Console.WriteLine("Error creating pic date dir: " + y);
                        log += "Error creating pic date dir: " + y + Environment.NewLine;
                    }
                }
                if (!File.Exists(logDatePath))
                {
                    File.CreateText(logDatePath);
                }

                foreach (string line in File.ReadLines(pxPerSqInchFilePath))
                {
                    pxPerSqInch = double.Parse(line);
                }

                foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + @"\" + "intPrim.txt"))
                {
                    pxPerInch = double.Parse(line);
                }
            }
            catch (Exception y)
            {
                Console.WriteLine("Error accessing image or file: " + y);
                log += "Error accessing image or file: " + y + Environment.NewLine;
            }

            try
            {

                Image<Hsv, Byte> hsvimgCal = FrameCal.Convert<Hsv, Byte>();

                Image<Gray, Byte>[] channelsCal = hsvimgCal.Split();  //split into components

                //Look for the color of the calibration here
                Image<Gray, Byte> imghueCal = channelsCal[0];   //hsv, so channels[0] is hue.
                Image<Gray, Byte> imgsatCal = channelsCal[1];   //hsv, so channels[1] is Saturation.
                Image<Gray, Byte> imgvalCal = channelsCal[2];   //hsv, so channels[2] is value.
                Image<Gray, byte> huefilterCal = imghueCal.InRange(new Gray(fileVal[0]), new Gray(fileVal[1]));
                //Image<Gray, byte> huefilterCal = imghueCal.InRange(new Gray(Int32.Parse(textBox1.Text)), new Gray(Int32.Parse(textBox2.Text)));
                Image<Gray, byte> satfilterCal = imgsatCal.InRange(new Gray(fileVal[2]), new Gray(fileVal[3]));
                //Image<Gray, byte> satfilterCal = imgsatCal.InRange(new Gray(Int32.Parse(textBox3.Text)), new Gray(Int32.Parse(textBox4.Text)));
                Image<Gray, byte> valfilterCal = imgvalCal.InRange(new Gray(fileVal[4]), new Gray(fileVal[5]));
                //Image<Gray, byte> valfilterCal = imgvalCal.InRange(new Gray(Int32.Parse(textBox5.Text)), new Gray(Int32.Parse(textBox6.Text)));

                //now and the two to get the parts of the imaged that are colored and above some brightness.
                Image<Gray, byte> colordetimgCal = satfilterCal.And(huefilterCal.And(valfilterCal));

                //Garbage collection, do not remove
                imghueCal.Dispose();
                imgsatCal.Dispose();
                imgvalCal.Dispose();

                using (MemStorage storage = new MemStorage())//Look for the calibration artifact here
                {
                    for (Contour<Point> contours = colordetimgCal.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, storage); contours != null; contours = contours.HNext)
                    {
                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);
                        if (currentContour.BoundingRectangle.Width > 20)
                        {
                            if (currentContour.Total.Equals(4))//checks if the calibration artifact is square
                            {
                                //if (((currentContour.Perimeter / Math.Sqrt(currentContour.Area)) % 4) < .002)
                                //{//checks if the artifact is a near perfect square

                                    areaSqInch = fileVal[31];//Need to set this equal the the total square inches of the calibration artifact
                                    int prim = fileVal[32];
                                    //totalCal = currentContour.Total;
                                    //Console.WriteLine((pxPerSqInch * areaSqInch + ((pxPerSqInch * areaSqInch) * .1)).ToString() + " > " + (currentContour.Area).ToString());
                                    //Console.WriteLine((pxPerSqInch * areaSqInch - ((pxPerSqInch * areaSqInch) * .1)).ToString() + " < " + (currentContour.Area).ToString());

                                    //if (((pxPerSqInch * areaSqInch + ((pxPerSqInch * areaSqInch) * .1)) > (currentContour.Area)) & ((pxPerSqInch * areaSqInch - ((pxPerSqInch * areaSqInch) * .1)) < (currentContour.Area)))//Ensures the new calibration artifact area is within +-10% of the old calibration artifact area
                                    //{
                                    pxPerSqInch = Math.Round(currentContour.Area / areaSqInch) + pxCal;
                                    pxPerInch = Math.Round(currentContour.Perimeter / prim);

                                    System.IO.File.WriteAllText(pxPerSqInchFilePath, pxPerSqInch.ToString());//if the calibration artifact is found and is a near perfect square updates pixels per sq inch
                                    System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\" + "intPrim.txt", pxPerInch.ToString());//if the calibration artifact is found and is a near perfect square updates pixels per sq inch
                                    //}

                                    //else
                                    //{
                                    //    label4.Text = "New sq not within 10%";
                                    //}
                                //}
                            }
                            else
                            {
                                //Console.WriteLine("Not SQ");
                            }
                            if (Math.Round((currentContour.Area / pxPerSqInch)) > 1)//gets the calibration artifact's size to subtract the area from the total area
                            {
                                sizeCal = sizeCal + Math.Round((currentContour.Area / pxPerSqInch), 2);
                                sizeCalPrim = sizeCalPrim + Math.Round((currentContour.Perimeter / pxPerInch), 2);
                            }
                            CvInvoke.cvDrawContours(Frame, contours, new MCvScalar(0), new MCvScalar(255), 1, -1, Emgu.CV.CvEnum.LINE_TYPE.CV_AA, new Point(0, 0));
                        }
                    }
                    storage.Clear();//Garbage collection, do not remove
                }

                Image<Hsv, Byte> hsvimg = Frame.Convert<Hsv, Byte>();

                Image<Gray, Byte>[] channels = hsvimg.Split();  //split into components
                Image<Gray, Byte> imghue = channels[0];         //hsv, so channels[0] is hue.
                Image<Gray, Byte> imgsat = channels[1];         //hsv, so channels[1] is Saturation.
                Image<Gray, Byte> imgval = channels[2];         //hsv, so channels[2] is value.

                //Look for the color of the background for solid images
                Image<Gray, byte> huefilter = imghue.InRange(new Gray(fileVal[6]), new Gray(fileVal[7]));
                Image<Gray, byte> satfilter = imgsat.InRange(new Gray(fileVal[8]), new Gray(fileVal[9]));
                //Image<Gray, byte> valfilter = imgval.InRange(new Gray(65), new Gray(220));
                Image<Gray, byte> valfilter = imgval.InRange(new Gray(fileVal[10]), new Gray(fileVal[11]));

                //now and the three to get the parts of the imaged that are colored and above some brightness.
                Image<Gray, byte> colordetimg = satfilter.And(huefilter.And(valfilter));

                //Garbage collection, do not remove
                imghue.Dispose();
                satfilter.Dispose();
                valfilter.Dispose();

                colordetimg = colordetimg.Not();

                using (MemStorage storage = new MemStorage())//Looks for the solid artifact(s) here
                {
                    for (Contour<Point> contours = colordetimg.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, storage); contours != null; contours = contours.HNext)
                    {
                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);
                        if (currentContour.BoundingRectangle.Width > 20)
                        {
                            if (Math.Round((currentContour.Area / pxPerSqInch)) > 2)
                            {
                                sizeMax = sizeMax + Math.Round((currentContour.Area / pxPerSqInch), 2);//Gets the total area for all solid artifact(s)
                                sizeMaxPrim = sizeMaxPrim + Math.Round((currentContour.Perimeter / pxPerInch), 2);
                                totalMax = totalMax + currentContour.Total;
                            }
                            CvInvoke.cvDrawContours(Frame, contours, new MCvScalar(0), new MCvScalar(255), 1, -1, Emgu.CV.CvEnum.LINE_TYPE.CV_AA, new Point(0, 0));
                        }
                    }
                    storage.Clear();//Garbage collection, do not remove
                }

                Image<Bgr, Byte> Frame2 = Frame;
                Image<Hsv, Byte> hsvimg2 = Frame2.Convert<Hsv, Byte>();

                //Look for the color of the background again for non solid images
                Image<Gray, Byte>[] channels2 = hsvimg2.Split();  //split into components
                Image<Gray, Byte> imghue2 = channels2[0];   //hsv, so channels[0] is hue.
                Image<Gray, Byte> imgsat2 = channels2[1];   //hsv, so channels[1] is Saturation.       
                Image<Gray, Byte> imgval2 = channels2[2];   //hsv, so channels[2] is value.

                //filter out all but "the color you want"...seems to be 0 to 128 ?
                Image<Gray, byte> huefilter2 = imghue2.InRange(new Gray(fileVal[6]), new Gray(fileVal[7]));

                //use the value channel to filter out all but brighter colors //30-200
                Image<Gray, byte> satfilter2 = imgsat2.InRange(new Gray(fileVal[8]), new Gray(fileVal[9]));

                //use the value channel to filter out all but brighter colors //90-225
                Image<Gray, byte> valfilter2 = imgval2.InRange(new Gray(fileVal[10]), new Gray(fileVal[11]));

                //now and the two to get the parts of the imaged that are colored and above some brightness.
                Image<Gray, byte> colordetimg2 = satfilter2.And(huefilter2.And(valfilter2));

                //Garbage collection, do not remove
                imghue2.Dispose();
                huefilter2.Dispose();
                satfilter2.Dispose();

                colordetimg2 = colordetimg2.AbsDiff(colordetimg);

                colordetimg2 = colordetimg2.Not();

                using (MemStorage storage = new MemStorage())//Looks for holes in artifact(s) here
                {
                    for (Contour<Point> contours = colordetimg2.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, storage); contours != null; contours = contours.HNext)
                    {

                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);
                        if (currentContour.BoundingRectangle.Width > 20)
                        {
                            if (Math.Round((currentContour.Area / pxPerSqInch)) > 2)
                            {
                                sizeMin = sizeMin + Math.Round((currentContour.Area / pxPerSqInch), 2);//Gets the area for all artifact hole(s)
                            }
                            CvInvoke.cvDrawContours(Frame, contours, new MCvScalar(0), new MCvScalar(255), 1, -1, Emgu.CV.CvEnum.LINE_TYPE.CV_AA, new Point(0, 0));
                        }
                    }
                    storage.Clear();//Garbage collection, do not remove
                }
                if (savePic.Length > 5)
                {
                    try
                    {
                        FrameNormal.Resize(120, 120, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, false).Save(picDatePath + savePic + ".jpg");
                    }
                    catch (Exception y)
                    {
                        Console.WriteLine("Image not Saved - Error: " + y);
                        log += "Image not Saved - Error: " + y + Environment.NewLine;
                    }
                    try
                    {
                        log += "Hole Area: " + sizeMin + Environment.NewLine;
                        log += "All Area: " + sizeMax + Environment.NewLine;
                        log += "Cal Area: " + sizeCal + Environment.NewLine;
                        log += "Total Area: " + (sizeMax - (sizeMin + sizeCal)) + Environment.NewLine;
                    }
                    catch (Exception y)
                    {
                        Console.WriteLine("Log not Saved - Error: " + y);
                        log += "Log not Saved - Error: " + y + Environment.NewLine;
                    }
                }

                if (sizeMin > 0)
                {
                    holes = 1;
                }


                //Garbage collection, do not remove
                colordetimg.Dispose();
                colordetimg2.Dispose();
                colordetimgCal.Dispose();
                Frame.Dispose();
                Frame2.Dispose();
                FrameCal.Dispose();
                FrameNormal.Dispose();

                values[0] = (sizeMax - (sizeMin + sizeCal));
                values[1] = sizeMaxPrim - sizeCalPrim;
                values[2] = totalMax - totalCal;
                values[3] = holes;
                return values;
            }
            catch (Exception y)
            {
                Console.WriteLine("Size not found: " + y);
                log += "Size not found: " + y + Environment.NewLine;
                return values;
            }
        }

        public Boolean leatherColor(int huemin, int huemax, int satmin, int satmax, int valmin, int valmax, int[] fileVal)
        {
            Image<Bgr, Byte> Frame = null;
            Image webImage = null;

            WebRequest requestPic = WebRequest.Create("http://localhost:50000/webcam/jpg");
            requestPic.UseDefaultCredentials = true;
            WebResponse responsePic = requestPic.GetResponse();

            webImage = Image.FromStream(responsePic.GetResponseStream());

            //webImage = Image.FromFile(Directory.GetCurrentDirectory() + @"\lathers\natural.jpg");

            using (Graphics g = Graphics.FromImage(webImage))//Crops the image, note if aspect ratio changes too much then the equation for the calibration artifact must change when looking for a perfect sq
            {
                g.DrawImage(webImage, new Rectangle(0, 0, webImage.Width, webImage.Height),
                    //new Rectangle(0, 0, webImage.Width, webImage.Height),//crop with values here
                    //new Rectangle(0, 0, webImage.Width, webImage.Height),//crop with values here
                    //new Rectangle(0 + fileVal[33], 0 + fileVal[35], webImage.Width - fileVal[34], webImage.Height - fileVal[36]),
                                         new Rectangle(fileVal[33], fileVal[35], webImage.Width - (fileVal[34] + fileVal[33]), webImage.Height - (fileVal[36] + fileVal[35])),
                                 GraphicsUnit.Pixel);
            }

            Frame = new Image<Bgr, Byte>((Bitmap)webImage);

            try
            {
                Image<Hsv, Byte> hsvimg = Frame.Convert<Hsv, Byte>();

                Image<Gray, Byte>[] channelsCal = hsvimg.Split();  //split into components

                //Look for the color of the calibration here
                Image<Gray, Byte> imghue = channelsCal[0];   //hsv, so channels[0] is hue.
                Image<Gray, Byte> imgsat = channelsCal[1];   //hsv, so channels[1] is Saturation.
                Image<Gray, Byte> imgval = channelsCal[2];   //hsv, so channels[2] is value.

                Image<Gray, byte> huefilterCal = imghue.InRange(new Gray(huemin), new Gray(huemax));
                Image<Gray, byte> satfilterCal = imgsat.InRange(new Gray(satmin), new Gray(satmax));
                Image<Gray, byte> valfilterCal = imgval.InRange(new Gray(valmin), new Gray(valmax));

                //now and the two to get the parts of the imaged that are colored and above some brightness.
                Image<Gray, byte> colordetimg = satfilterCal.And(huefilterCal.And(valfilterCal));

                //Garbage collection, do not remove
                imghue.Dispose();
                imgsat.Dispose();
                imgval.Dispose();

                using (MemStorage storage = new MemStorage())
                {
                    for (Contour<Point> contours = colordetimg.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, storage); contours != null; contours = contours.HNext)
                    {
                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);
                        if (currentContour.BoundingRectangle.Width > 1000)
                        {
                            storage.Clear();
                            return true;
                        }
                    }
                    storage.Clear();//Garbage collection, do not remove
                }
            }

            catch
            {

            }
            return false;
        }

    }
