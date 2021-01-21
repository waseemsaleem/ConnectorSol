using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;

namespace ConnectorSol
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            var fullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (StreamReader r = new StreamReader($"{fullPath}/Files/credentials.json"))
            {
                string json = r.ReadToEnd();
                var jsonCred = JsonConvert.DeserializeObject<APIEndpoints>(json);
                var clientHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(jsonCred.APIKey, jsonCred.SecretKey),
                    PreAuthenticate = true,
                    UseCookies = false
                };
                var httpClient = new HttpClient(clientHandler);
                var responseMessage = httpClient.GetStringAsync($"{jsonCred.BaseUrl}customers.json?status=any&limit=250").Result;

                JsonToSQL.JsonConvert jsonConvert = new JsonToSQL.JsonConvert();
                var sqlStr = jsonConvert.ToSQL(responseMessage);
                label1.Text = sqlStr;
            }
        }
    }
}
