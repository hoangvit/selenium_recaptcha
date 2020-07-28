using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using GuerrillaSharp.Models;
using GuerrillaSharp;
using System.Threading;
using System.IO;
using KAutoHelper;
using System.Net;
using System.Collections.Specialized;

namespace url
{



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void hma()
        {
            Process.Start(@textBox2.Text);
            Thread.Sleep(1000);
            AutoControl.MouseClick(int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        public string NgauNhienName()
        {
            string[] id = new string[] { "Jennifer", "Austin", "Rosie", "Crawford", "Rolando", "Harris", "Jennie", "Lambert", "Kay", "Jefferson", "Sam", "Williams", "Tricia", "Dennis", "Kelly", "Harmon", "Raquel", "Norris", "Mario", "Morris", "Melinda", "Russell", "Guillermo", "Hale", "Catherine", "Roy", "Julius", "Wagner", "Myron", "Casey", "Leona", "Lynch", "Gladys", "Mcgee", "Becky", "Parks", "Essie", "Drake", "Winston", "Wallace", "Cathy", "Benson", "Hannah", "Hoffman", "Nick", "Mann", "Leigh", "Sims", "Lisa", "Miles", "Wilfred", "Hopkins", "Elias", "Walsh", "Sarah", "Steele", "Sherman", "Green", "Wendy", "Robertson", "Jeremiah", "Barker", "Gordon", "Williamson", "Robert", "Santos", "Kim", "Washington", "Fredrick", "Webster", "Seth", "Snyder", "Kerry", "Robinson", "Javier", "Schwartz", "Elisa", "Stewart", "Marcia", "Jacobs", "Angela", "Fisher", "Rick", "Carroll", "Rosa", "Rios", "Erick", "King", "Terri", "Grant", "Penny", "Lucas", "Kayla", "Dixon", "Angelina", "Palmer", "Marta", "Bridges", "Garrett", "Mclaughlin" };
            Random ID = new Random();

            string name2 = id[ID.Next(0, id.Length)];
            return (name2);
        }

        public string NgauNhienName2()
        {
            string[] id = new string[] { "Jose", "Rocco", "Sibley", "Marlyn", "Vogt", "Sharilyn", "Daily", "Ione", "Meeks", "Ines", "Taber", "Rhiannon", "Langdon", "Lina", "Fish", "Rafaela", "Oliphant", "Valene", "Doss", "Abbey", "Seaman", "Colene", "Castellanos", "Chantel", "Fuentes", "Tommie", "Raymond", "Reynolds", "Roosevelt", "Harvey", "Ronnie", "Martinez", "Erik", "Carson", "Leslie", "Arnold", "Doreen", "Chavez", "Jaime", "Garcia", "Celia", "Alexander", "Winston", "Peters", "Richard", "Parks", "Veronica", "Nunez", "Kristy", "Ray", "Terry", "Thompson", "Frank", "Patrick", "Marcia", "Richards", "Aubrey", "Olson", "Joanna", "Johnston", "Darnell", "Santos", "Rochelle", "Harmon", "Nicholas", "Cross", "Steve", "Lee", "Beatrice", "Vega", "Edith", "Wagner", "Amelia", "Miller", "Essie", "Powell", "Martin", "Chandler", "Nick", "Malone", "Tamara", "Rodriquez", "Everett", "Phillips", "Abraham", "Hayes", "Lamar", "Brewer", "Pablo", "Luna", "Jaime", "Adams", "Carmen", "Pierce", "Kay", "Zimmerman", "Bobbie", "Glover", "Casey", "Little" };

            Random ID = new Random();
            string name2 = id[ID.Next(0, id.Length)];
            return (name2);

        }

        string Reslove2CaptchaCaptcha(string captchaKey, string ggKey, string url)
        {
            string capt = "";

            Recaptcha_2Captcha reCapt = new Recaptcha_2Captcha(captchaKey);

            bool isSuccess = reCapt.SolveRecaptchaV2(ggKey, url, out capt);

            while (!isSuccess)
            {
                isSuccess = reCapt.SolveRecaptchaV2(ggKey, url, out capt);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            return capt;
        }


        public void chrome(int ii)
        {
            GuerrillaMail guerrilla = new GuerrillaMail();
            guerrilla.GetEmailAddress();



            Random number = new Random();
            string sdt = "09" + number.Next(10000000, 99999999);
            string passrandom = NgauNhienName().ToLower() + number.Next(10000, 99999) + "@";
            string mail = guerrilla.EmailAddress;
            string ggkey = "6LdKwvcUAAAAAOWHayxQNHnDrDVL6GWC-lx1EP0R";
            string CaptchaURL = "https://neebanker.neebank.com/auth/signup?ref=bootm4v";
            var usename = NgauNhienName() + number.Next(0, 999999) + ii;
            var email = guerrilla.EmailAddress;

            



            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            //var options = new ChromeOptions();
            //options.AddArgument("--start - maximized");

            var chromeDriver = new ChromeDriver(service);

            chromeDriver.Url = textBox1.Text;
            chromeDriver.Navigate();
            try
            {
                Thread.Sleep(10000);
                chromeDriver.FindElementByCssSelector("#id_username").SendKeys(usename);
            }
            catch
            {
                chromeDriver.Navigate().Refresh();
                chromeDriver.FindElementByCssSelector("#id_username").SendKeys(usename); ;
            }
            string captchaOut = Reslove2CaptchaCaptcha(textBox5.Text, ggkey, CaptchaURL);
            chromeDriver.FindElementByCssSelector("#CountryCode > option:nth-child(233)").Click();
            chromeDriver.FindElementByCssSelector("#userPhone").SendKeys(sdt);
            chromeDriver.FindElementByCssSelector("#id_email").SendKeys(email);
            chromeDriver.FindElementByCssSelector("#id_password1").SendKeys(passrandom);
            chromeDriver.FindElementByCssSelector("#id_password2").SendKeys(passrandom);
            chromeDriver.FindElementByCssSelector("#signupform > div.form-group > div.custom-control.custom-checkbox.d-flex.justify-content-start.text-white > label").Click();
            
            chromeDriver.ExecuteScript("document.getElementById(\"g-recaptcha-response\").innerHTML=\""+captchaOut+"\"");
            chromeDriver.FindElementByCssSelector("#signup-btn > span").Click();
            Thread.Sleep(15000);
            chromeDriver.ExecuteScript("document.getElementsByClassName('confirm btn btn-lg btn-success')[0].click();");

            //chromeDriver.FindElementByCssSelector("body > div.sweet-alert.showSweetAlert.visible > div.sa-button-container > div > button").Click();
      







            guerrilla.CheckEmail();



            if (guerrilla.EmailCount == 0)
            {
                Thread.Sleep(15000);
                guerrilla.CheckEmail();
                if (guerrilla.EmailCount == 0)
                {
                    guerrilla.CheckEmail();
                    Thread.Sleep(15000);
                    guerrilla.CheckEmail();
                }
            }
            if (guerrilla.EmailCount > 0)
            {

                Email emails = guerrilla.FetchEmail(guerrilla.Emails[0].MailId);

                string url = emails.MailBody;
                var aaaa2 = url.Substring(url.IndexOf("bold"), 13);
                Thread.Sleep(3000);
                var code = aaaa2.Split('>')[1];
                chromeDriver.FindElementByCssSelector("#TwoFaCode").SendKeys(code);
                chromeDriver.FindElementByCssSelector("#otp-activation-btn").Click();
                Thread.Sleep(3000);
                

            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Thread> threads = new List<Thread>();
            for (var j = 0; j < numericUpDown2.Value; j++)
            {
                for (var i = 0; i < numericUpDown1.Value; i++)
                {
                    label1.Text = (i + 1).ToString();
                    var val = i;
                    Thread t1 = new Thread(() => { chrome(val); });
                    t1.Start();
                    t1.Join(3000);
                    threads.Add(t1);
                    Thread.Sleep(2000);

                }
                for (var i = 0; i < threads.Count; i++)
                {
                    if (threads[i].IsAlive == false)
                    {
                        threads.Remove(threads[i]);
                    }

                }

            }
        }


        private void xuatDuLieu(string use)
        {

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("v8.txt", true))
                {
                    file.WriteLine(use);
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("lost :", ex);
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    public class Recaptcha_2Captcha
    {
        public string APIKey { get; private set; }
        public Recaptcha_2Captcha(string apiKey)
        {
            APIKey = apiKey;
        }

        /// <summary>
        /// Sends a solve request and waits for a response
        /// </summary>
        /// <param name="googleKey">The "sitekey" value from site your captcha is located on</param>
        /// <param name="pageUrl">The page the captcha is located on</param>
        /// <param name="proxy">The proxy used, format: "username:password@ip:port</param>
        /// <param name="proxyType">The type of proxy used</param>
        /// <param name="result">If solving was successful this contains the answer</param>
        /// <returns>Returns true if solving was successful, otherwise false</returns>
        public bool SolveRecaptchaV2(string googleKey, string pageUrl, out string result)
        {
            string requestUrl = "http://2captcha.com/in.php?key=" + APIKey + "&method=userrecaptcha&googlekey=" + googleKey + "&pageurl=" + pageUrl;
            try
            {
                WebRequest req = WebRequest.Create(requestUrl);

                using (WebResponse resp = req.GetResponse())
                using (StreamReader read = new StreamReader(resp.GetResponseStream()))
                {
                    string response = read.ReadToEnd();

                    if (response.Length < 3)
                    {
                        result = response;
                        return false;
                    }
                    else
                    {
                        if (response.Substring(0, 3) == "OK|")
                        {
                            string captchaID = response.Remove(0, 3);

                            for (int i = 0; i < 24; i++)
                            {
                                WebRequest getAnswer = WebRequest.Create("http://2captcha.com/res.php?key=" + APIKey + "&action=get&id=" + captchaID);

                                using (WebResponse answerResp = getAnswer.GetResponse())
                                using (StreamReader answerStream = new StreamReader(answerResp.GetResponseStream()))
                                {
                                    string answerResponse = answerStream.ReadToEnd();

                                    if (answerResponse.Length < 3)
                                    {
                                        result = answerResponse;
                                        return false;
                                    }
                                    else
                                    {
                                        if (answerResponse.Substring(0, 3) == "OK|")
                                        {
                                            result = answerResponse.Remove(0, 3);
                                            return true;
                                        }
                                        else if (answerResponse != "CAPCHA_NOT_READY")
                                        {
                                            result = answerResponse;
                                            return false;
                                        }
                                    }
                                }

                                Thread.Sleep(5000);
                            }

                            result = "Timeout";
                            return false;
                        }
                        else
                        {
                            result = response;
                            return false;
                        }
                    }
                }
            }
            catch { }

            result = "Unknown error";
            return false;
        }

        /// <summary>
        /// Slove normal capcha wroted by K9 from Kteam
        /// You have to get the capcha image from the website then convert to base64
        /// </summary>
        /// <param name="base64Image"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool SolveNormalCapcha(string base64Image, out string result)
        {
            string response = "";
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["method"] = "base64";
                values["key"] = APIKey;
                values["body"] = base64Image;
                var res = client.UploadValues("http://2captcha.com/in.php", values);
                response = Encoding.Default.GetString(res);
            }

            Thread.Sleep(TimeSpan.FromSeconds(5));
            if (response.Substring(0, 3) == "OK|")
            {
                string captchaID = response.Remove(0, 3);

                for (int i = 0; i < 24; i++)
                {
                    WebRequest getAnswer = WebRequest.Create("http://2captcha.com/res.php?key=" + APIKey + "&action=get&id=" + captchaID);

                    using (WebResponse answerResp = getAnswer.GetResponse())
                    using (StreamReader answerStream = new StreamReader(answerResp.GetResponseStream()))
                    {
                        string answerResponse = answerStream.ReadToEnd();

                        if (answerResponse.Length < 3)
                        {
                            result = answerResponse;
                            return false;
                        }
                        else
                        {
                            if (answerResponse.Substring(0, 3) == "OK|")
                            {
                                result = answerResponse.Remove(0, 3);
                                return true;
                            }
                            else if (answerResponse != "CAPCHA_NOT_READY")
                            {
                                result = answerResponse;
                                return false;
                            }
                        }
                    }

                    Thread.Sleep(5000);
                }

                result = "Timeout";
                return false;
            }
            else
            {
                result = response;
                return false;
            }
        }
    }
}

