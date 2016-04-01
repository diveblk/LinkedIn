using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;

using KBCsv;
using OfficeOpenXml;


namespace EquibrandFeed
{
    class Program
    {
        static string log = string.Empty;
        static void Main(string[] args)
        {
            String[] emails = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Emails.csv").Split(',');
            String[] emailsExcel = File.ReadAllText(Directory.GetCurrentDirectory() + @"\EmailsExcel.csv").Split(',');
            String[] ftpFile = File.ReadAllText(Directory.GetCurrentDirectory() + @"\FTP.csv").Split(',');

            Program p = new Program();
            p.CreateCSVFeed();
            p.CreateExcelFeed();

            if(emails.Length > 0)
            {
                foreach (String email in emails)
                {
                    log += "Emailed CSV: " + email + Environment.NewLine;
                    p.email(email, Directory.GetCurrentDirectory() + @"\" + "Feed.csv");
                }
            }

            if(emailsExcel.Length > 0)
            {
                foreach (String email in emailsExcel)
                {
                    log += "Emailed Excel: " + email + Environment.NewLine;
                    p.email(email, Directory.GetCurrentDirectory() + @"\" + "Feed.xlsx");
                }
            }

            if(ftpFile.Length > 0)
            {
                string filePath = Directory.GetCurrentDirectory() + @"\FTP.csv";
                StreamReader sr = new StreamReader(filePath);
                var lines = new List<string[]>();
                int Row = 0;
                while (!sr.EndOfStream)
                {
                    string[] Line = sr.ReadLine().Split(',');
                    lines.Add(Line);
                    Row++;
                }

                var data = lines.ToArray();

                int i = 0;
                foreach (String[] ftp in data)
                {

                    p.FTPUpload(data[i][0].ToString(), data[i][1].ToString(), data[i][2].ToString());

                    i++;
                }
            }

            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\log\" + DateTime.Now.ToString("yyy-MM-dd-HH-mm") + ".txt", log);
        }

        public void CreateCSVFeed()
        {
            String fileData = string.Empty;

            SqlConnection conn = new SqlConnection("user id=User;data source=db;persist security info=True;initial catalog=db;password=password");
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetInventoryFeed", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataAdapter sqlDA2 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                sqlDA2.Fill(dt2);

                String SerNum = dt2.Rows[0]["result"].ToString();

                fileData += "No_,Quantity on Hand,Status" + Environment.NewLine;

                foreach (DataRow dr in dt2.Rows)
                {
                    fileData += dr[0].ToString() + Environment.NewLine;
                }

                File.WriteAllText(Directory.GetCurrentDirectory() + @"\" + "Feed.csv", fileData);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                log += "SQL error: " + ex.ToString() + Environment.NewLine;
            }
            finally
            {
                conn.Close();
            }
        }

        public void email(String emailAddress, String Attachment)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                Attachment feedCSV = new Attachment(Attachment);

                string body = String.Format(@"Attached you will find a file with our inventory feed.");

                mailMsg.To.Add(new MailAddress(emailAddress));
                mailMsg.From = new MailAddress("ITHelpdesk@equibrand.com");
                mailMsg.IsBodyHtml = true;

                mailMsg.Body = body;
                mailMsg.Subject = "Equibrand Feed";
                mailMsg.Attachments.Add(feedCSV);

                SmtpClient smtpClient = new SmtpClient("exchange.hub");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("username", "password");

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.Send(mailMsg);

                log += "Email sent: " + emailAddress + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                log += "Email not sent: " + emailAddress + Environment.NewLine + " Error: " + ex.ToString() + Environment.NewLine;

            }
        }

        public void CreateExcelFeed()
        {
            try
            {
                var table = new DataTable();

                using (var streamReader = new StreamReader(Directory.GetCurrentDirectory() + @"\" + "Feed.csv"))
                using (var reader = new CsvReader(streamReader))
                {
                    reader.ReadHeaderRecord();
                    table.Fill(reader);
                }

                GenerateExcel(table, "sheet1");
            }
            catch(Exception e)
            {
                log += "Excel error: " + e.ToString() + Environment.NewLine;
            }            
        }

        private void GenerateExcel(DataTable dataToExcel, string excelSheetName)
        {
            string fileName = "Feed";
            string currentDirectorypath = Environment.CurrentDirectory;
            string finalFileNameWithPath = string.Empty;

            finalFileNameWithPath = string.Format("{0}\\{1}.xlsx", currentDirectorypath, fileName);

            if (File.Exists(finalFileNameWithPath))
                File.Delete(finalFileNameWithPath);

            var newFile = new FileInfo(finalFileNameWithPath);

            using (var package = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(excelSheetName);
                worksheet.Cells["A1"].LoadFromDataTable(dataToExcel, true);
                package.Save();
            }
        }

        public void FTPUpload(String ftp, String Username, String Password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(Username, Password);

                StreamReader sourceStream = new StreamReader(Directory.GetCurrentDirectory() + @"\" + "Feed.csv");
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                log += "Upload File Complete" + response.StatusDescription + Environment.NewLine;

                response.Close();
            }

            catch (Exception e)
            {
                log += "FTP Error : " + ftp + Environment.NewLine + " Error: " + e.ToString() + Environment.NewLine;
            }
        }
    }
}
