using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Collections;
using System.Reflection;

namespace BuildingFeedCon
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            int error = 0;

            string picPath = Directory.GetCurrentDirectory() + @"\" + "pic" + @"\";
            string rawData;

            while (true) {

                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                try {

                    var timeSpan = TimeSpan.FromSeconds(unixTimestamp);
                    var localDateTime = new DateTime(timeSpan.Ticks).ToLocalTime();
                    var curHour = localDateTime.ToString("H:mm");

                    DateTime morning = DateTime.Parse("6:00",
                                  System.Globalization.CultureInfo.InvariantCulture);

                    DateTime night = DateTime.Parse("20:00",
                                  System.Globalization.CultureInfo.InvariantCulture);

                    //Only saves Images from 6:00 am to 8:00pm local time
                    if ((DateTime.Parse(curHour,
                                  System.Globalization.CultureInfo.InvariantCulture)
                                  >
                        (DateTime.Parse(morning.ToString("H:mm"),
                                  System.Globalization.CultureInfo.InvariantCulture)))
                                  &&
                                  (DateTime.Parse(curHour,
                                  System.Globalization.CultureInfo.InvariantCulture)
                                  <
                        (DateTime.Parse(night.ToString("H:mm"),
                                  System.Globalization.CultureInfo.InvariantCulture)))
                    )
                    {
                        Console.WriteLine("Good Hour: " + curHour + " Between " + morning.ToString("H:mm") + " and " + night.ToString("H:mm"));

                        CookieContainer cookies = new CookieContainer();

                        //Request login page to get a session cookie
                        p.GETHtml("http://remote.pvgdsmobile.com:11518/VideoInsight/Account/login.aspx", cookies);

                        //Now we can do login, need Username and Password
                        rawData = p.Login("username", "password", cookies);

                        error = 0;

                        System.Threading.Thread.Sleep(600000);
                    }                   
                }

                catch(Exception ex)
                {
                    

                    if (error < 3)
                    {
                        File.WriteAllText(picPath + unixTimestamp + "error.txt", ex.ToString());
                        error += 1;
                        System.Threading.Thread.Sleep(600000);

                    }
                    else
                    {
                        File.WriteAllText(picPath + unixTimestamp + "MajorError.txt", ex.ToString());

                        break;
                    }

                    
                }
            }
        }

        public class CookieAwareWebClient2 : WebClient//Second container for grabbing image
        {
            public CookieAwareWebClient2()
            {
                CookieContainer = new CookieContainer();
            }
            public CookieContainer CookieContainer { get; private set; }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = (HttpWebRequest)base.GetWebRequest(address);
                request.CookieContainer = CookieContainer;
                return request;
            }
        }

        public class CookieAwareWebClient : WebClient//First container for login site
        {
            public CookieContainer CookieContainer { get; set; }
            public Uri Uri { get; set; }

            public CookieAwareWebClient()
                : this(new CookieContainer())
            {
            }

            public CookieAwareWebClient(CookieContainer cookies)
            {
                this.CookieContainer = cookies;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).CookieContainer = this.CookieContainer;
                }
                HttpWebRequest httpRequest = (HttpWebRequest)request;
                httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                return httpRequest;
            }

            protected override WebResponse GetWebResponse(WebRequest request)
            {
                WebResponse response = base.GetWebResponse(request);
                String setCookieHeader = response.Headers[HttpResponseHeader.SetCookie];

                //do something if needed to parse out the cookie.
                if (setCookieHeader != null)
                {
                    Cookie cookie = new Cookie(); //create cookie
                    this.CookieContainer.Add(cookie);
                }

                return response;
            }
        }

        public String Login(string Username, string Password, CookieContainer cookies)//Used to login and get/set the needed cookie settings to assess protected site
        {
            //poststring constructed from login post, use fiddler for getting info on headers of request
            string poststring = string.Format("__VIEWSTATE=%2FwEPDwULLTIwNDUzNzkwOTIPZBYCAgMPZBYSAgEPDxYCHgRUZXh0BQpVc2VyIE5hbWU6ZGQCBQ8PFgIfAAUJUGFzc3dvcmQ6ZGQCCQ8PFgIfAAUHU2lnbiBJbmRkAg0PFgIeBXN0eWxlBQ1kaXNwbGF5Om5vbmU7FgQCAQ8WAh8AZWQCAw8PFgIfAAUSTmV0d29yayBDb25uZWN0aW9uZGQCDw8PFgIfAAUbUGxlYXNlIHNpZ24gaW4gdG8gY29udGludWUuZGQCEQ8PFgIfAGVkZAIVDw8WAh8ABT9XZWJDbGllbnQ8c3VwIGNsYXNzPSJ0ZXh0LTIiIHN0eWxlPSJ2ZXJ0aWNhbC1hbGlnbjp0b3AiPjU8L3N1cD5kZAIXDw8WAh8ABRdwb3dlcmVkIGJ5IFZpZGVvSW5zaWdodGRkAhsPFgIfAAV0PGRpdiBjbGFzcz0ncHJvZmlsZV9pdGVtJyBwcm9maWxlX2lkPScwJyBwcm9maWxlX25hbWU9J0ludHJhbmV0JyBvbmNsaWNrPSdvblByb2ZpbGVTZWxlY3RlZCh0aGlzKTsnPkludHJhbmV0PC9kaXY%2BDQpkZOvuS9gu8W40q43QYvijdbpO5XbG%2BzC6q7M7D4e63atR&__VIEWSTATEGENERATOR=0CB40D30&__EVENTVALIDATION=%2FwEdAAVyVc3YDn2xxkdoGBNjv%2BUlY3plgk0YBAefRz3MyBlTcHY2%2BMc6SrnAqio3oCKbxYainihG6d%2FXh3PZm3b5AoMQEc%2BsR7yTHd9RQDjA8uB%2BK7imm8lW1c4mOzgFT7JtedmGhbg8mD%2FsUiLnNr3qqT90&txtUserName={0}&txtPassword={1}&btnLogin=&inputProfile=0",
                                        Username, Password);
            byte[] postdata = Encoding.UTF8.GetBytes(poststring);

            string rawData;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://remote.pvgdsmobile.com:11518/VideoInsight/Account/login.aspx");
            webRequest.CookieContainer = cookies;
            webRequest.Method = "POST";
            webRequest.Referer = "http://remote.pvgdsmobile.com:11518/VideoInsight/Account/login.aspx";
            webRequest.KeepAlive = true;
            webRequest.Headers.Add("origin", "http://remote.pvgdsmobile.com:11518/VideoInsight/");
            webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; InfoPath.2; .NET CLR 3.5.21022;";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = postdata.Length;
            using (Stream writer = webRequest.GetRequestStream())
                writer.Write(postdata, 0, postdata.Length);

            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                //We need to add any response cookies to our cookie container
                cookies.Add(webResponse.Cookies);
                string WC55, UserName, VIMC60;


                Console.WriteLine("Start");


                Console.WriteLine(cookies.Count);


                //Hashable table to read returned cookies for access to protected site
                Hashtable k = (Hashtable)cookies.GetType().GetField("m_domainTable", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(cookies);
                foreach (DictionaryEntry element in k)
                {
                    SortedList l = (SortedList)element.Value.GetType().GetField("m_list", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(element.Value);
                    foreach (var e in l)
                    {
                        var cl = (CookieCollection)((DictionaryEntry)e).Value;

                        WC55 = cl[0].ToString().Replace("WC55=", "");
                        UserName = cl[1].ToString().Replace("UserName=", "");
                        VIMC60 = cl[2].ToString().Replace("VIWC60=", "");

                        getImg2(UserName, WC55, VIMC60);

                    }
                    l.Clear();
                }

                k.Clear();

                using (var stream = new StreamReader(webResponse.GetResponseStream()))
                {

                    rawData = stream.ReadToEnd();

                    CookieAwareWebClient client = new CookieAwareWebClient(cookies);
                    string picPath = Directory.GetCurrentDirectory() + @"\" + "pic" + @"\";
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                }

                return rawData;
            }
        }

        public string GETHtml(string url, CookieContainer cookies)//Loads page to wake camera for image capture
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.CookieContainer = cookies;
            webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; InfoPath.2; .NET CLR 3.5.21022;";
            webRequest.Referer = "http://remote.pvgdsmobile.com:11518/VideoInsight/Account/login.aspx";

            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                //We need to add any response cookies to our cookie container           
                cookies.Add(webResponse.Cookies);

                using (var stream = new StreamReader(webResponse.GetResponseStream()))
                    return stream.ReadToEnd();
            }
        }

        public void getImg2(String Username, String WC55, String VIMC60)//injects cookies to protected site to spoof logged in client
        {
            string picPath = Directory.GetCurrentDirectory() + @"\" + "pic" + @"\";

            try
            {
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                using (var client = new CookieAwareWebClient2())
                {

                    Console.WriteLine("Uploading: " + "UserName: " + Username + " WC55: " + WC55 + " VIWC60: " + VIMC60);

                    var values = new NameValueCollection
                   {
                        { "UserName",Username },
                        { "WC55", WC55 },
                        {"VIWC60", VIMC60 },
                    };
                    client.UploadValues("http://remote.pvgdsmobile.com:11518/VideoInsight/Account/login.aspx", values);

                    values.Clear();

                    client.OpenRead("http://remote.pvgdsmobile.com:11518/VideoInsight/c.cam?cid=1926364886");
                    //http://remote.pvgdsmobile.com:11518/VideoInsight/c.cam?cid=1926364886
                    //http://remote.pvgdsmobile.com:11518/VideoInsight/c.cam?cid=1398031189

                    client.DownloadFile("http://remote.pvgdsmobile.com:11518/VideoInsight/c.cam?cid=1926364886", picPath + unixTimestamp + ".jpg");

                    try
                    {
                        FileStream fs = new System.IO.FileStream(picPath + unixTimestamp + ".jpg", FileMode.Open, FileAccess.Read);

                        if (fs.Length < 100)//when camera is not loaded default image size is 70 so we keep trying till we get a good image or error out
                        {
                            fs.Dispose();
                            File.Delete(picPath + unixTimestamp + ".jpg");

                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("Waiting for real img");
                            getImg2(Username, WC55, VIMC60);
                        }

                        else
                        {
                            Console.WriteLine("Good Pic, waiting 10 mins");
                        }

                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error: " + ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
