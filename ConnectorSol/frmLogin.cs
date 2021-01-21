using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        private void button1_Click(object sender, EventArgs e)
        {

            //var fullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //using (StreamReader r = new StreamReader($"{fullPath}/Files/credentials.json"))
            var openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            using (StreamReader r = new StreamReader(openFileDialog.FileName))
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
                var responseMessage = httpClient
                    .GetStringAsync($"{jsonCred.BaseUrl}customers.json?status=any&limit=250").Result;

                JsonToSQL.JsonConvert jsonConvert = new JsonToSQL.JsonConvert();
                var sqlStr = jsonConvert.ToSQL(responseMessage);
                // TODO: write sql file
                var sqlPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL/sql_{DateTime.Now.Ticks}.sql";
                using (StreamWriter streamWriter = new StreamWriter(sqlPath, true))
                {
                    streamWriter.WriteLine(sqlStr);
                }
                label1.Text = $"File is created:{sqlPath}";
            }
        }
    }
}
