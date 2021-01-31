using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace RESToran.PresentationLayer
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.backendHostname + "/Restaurant/login");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Method = "POST";

                string json = "{" +
                            "\"EmailAddress\" : \"" + EmailBox.Text + "\"," +
                            "\"Password\" : \"" + PasswordBox.Text + "\"}";
                httpWebRequest.ContentLength = Encoding.ASCII.GetBytes(json).Length;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {


                    streamWriter.Write(json);
                }
                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse.StatusCode.ToString() == "OK")
                    {
                        resultLabel.Text = "SUCCESS";
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.setAuthValue(httpResponse.GetResponseHeader("AuthValue"));
                        this.Parent.Hide();
                        mainWindow.Show();
                    }
                }
                catch (System.Net.WebException error)
                {
                    resultLabel.Text = "Wrong credentials!";
                }
            }
            catch (Exception except)
            {
                MessageBox.Show("Error occurred");
            }
        }
    }
}