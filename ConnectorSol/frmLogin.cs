using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Newtonsoft.Json;

namespace ConnectorSol
{
    public partial class frmLogin : Form
    {
        readonly string _strCon;
        public frmLogin()
        {
            InitializeComponent();
            _strCon =  ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
            string disclaimer = "----- For XML File Format is -----";
            disclaimer += "\r\n";
            disclaimer += "<?xml version='1.0'?>";
            disclaimer += "\r\n";
            disclaimer += "<Root>";
            disclaimer += "\r\n";
            disclaimer += "<BaseUrl>shopifystoreurl</BaseUrl>";
            disclaimer += "\r\n";
            disclaimer += "<APIKey>shopifyapikey</APIKey>";
            disclaimer += "\r\n";
            disclaimer += "<SecretKey>shopifysecretkey</SecretKey>";
            disclaimer += "\r\n";
            disclaimer += "<Endpoints>";
            disclaimer += "\r\n";
            disclaimer += "<Url>customers</Url>";
            disclaimer += "\r\n";
            disclaimer += "</Endpoints>";
            disclaimer += "\r\n";
            disclaimer += "</Root>";
            disclaimer += "\r\n";
            disclaimer += "--------------------------";
            disclaimer += "\r\n";
            disclaimer += "----- For Json File Format is -----";
            disclaimer += "\r\n";
            disclaimer += "{";
            disclaimer += "\r\n";
            disclaimer += "BaseUrl:shopifystoreurl";
            disclaimer += "APIKey:shopifyapikey,";
            disclaimer += "SecretKey:shopifysecrectkey,";
            disclaimer += "Endpoints:[";
            disclaimer += "{";
            disclaimer += "Url:customers";
            disclaimer += "}";
            disclaimer += "\r\n";
            disclaimer += "]";
            disclaimer += "\r\n";
            disclaimer += "}";
            disclaimer += "\r\n";
            disclaimer += "--------------------------";
            textBox1.Text = disclaimer;
        }

        private void btnConvertToSQL_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtJsonFilePath.Text) && txtJsonFilePath.Text.ToLower().Contains("json"))
                {
                    using (StreamReader r = new StreamReader(txtJsonFilePath.Text))
                    {

                        string json = r.ReadToEnd();
                        var jsonCred = JsonConvert.DeserializeObject<APIEndpoints>(json);
                        if (!string.IsNullOrWhiteSpace(jsonCred.APIKey) && !string.IsNullOrWhiteSpace(jsonCred.SecretKey)
                           && !string.IsNullOrWhiteSpace(jsonCred.BaseUrl) && jsonCred.Endpoints.Count > 0)
                        {
                            var clientHandler = new HttpClientHandler
                            {
                                Credentials = new NetworkCredential(jsonCred.APIKey, jsonCred.SecretKey),
                                PreAuthenticate = true,
                                UseCookies = false
                            };
                            if (jsonCred.Endpoints.Count > 0)
                            {
                                string filesPath = "";
                                foreach (var endPoint in jsonCred.Endpoints)
                                {
                                    var httpClient = new HttpClient(clientHandler);
                                    var responseMessage = httpClient
                                        .GetStringAsync($"{jsonCred.BaseUrl}{endPoint.Url}.json?limit=250").Result;
                                    var pCcount = httpClient
                                        .GetStringAsync($"{jsonCred.BaseUrl}{endPoint.Url}/count.json").Result;
                                    //XNode node = JsonConvert.DeserializeXNode(responseMessage, "Root");
                                    var count = JsonConvert.DeserializeObject<ProductCount>(pCcount);
                                    if (count.count > 0)
                                    {
                                        JsonToSQL.JsonConvert jsonConvert = new JsonToSQL.JsonConvert();
                                        var folderDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL";
                                        bool exists = System.IO.Directory.Exists(folderDir);
                                        if (!exists)
                                            System.IO.Directory.CreateDirectory(folderDir);
                                        var sqlStr = jsonConvert.ToSQL(responseMessage, JsonToSQL.Constants.DefaultDbName + "_" + endPoint.Url);

                                        var sqlPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL/sql_{endPoint.Url}_{DateTime.Now.Ticks}.sql";
                                        using (StreamWriter streamWriter = new StreamWriter(sqlPath, true))
                                        {
                                            streamWriter.WriteLine(sqlStr);
                                        }
                                        filesPath += $"File is created:{sqlPath}\r\n";
                                    }

                                }
                                label1.Text = filesPath;
                            }
                        }


                    }
                }
                else
                {
                    label1.Text = "Incorrect File Format! Only JSON File Supported";
                }
            }
            catch (Exception)
            {

                label1.Text = "Incorrect File Format!";
                return;
            }

        }


        private void btnXmlToSql_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                txtXmlFilePath.Text = openFileDialog.FileName;
            else
                return;
        }

        private void btnConvertXmlToSql_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtXmlFilePath.Text) && txtXmlFilePath.Text.ToLower().Contains("xml"))
                {
                    using (StreamReader r = new StreamReader(txtXmlFilePath.Text))
                    {

                        XmlDocument doc = new XmlDocument();
                        string xml = r.ReadToEnd();
                        doc.LoadXml(xml);
                        string jsonText = JsonConvert.SerializeXmlNode(doc);

                        var jsonCred = JsonConvert.DeserializeObject<Main>(jsonText);
                        if (!string.IsNullOrWhiteSpace(jsonCred.Root.APIKey) && !string.IsNullOrWhiteSpace(jsonCred.Root.SecretKey)
                            && !string.IsNullOrWhiteSpace(jsonCred.Root.BaseUrl) && jsonCred.Root.Endpoints.Count > 0)
                        {
                            var clientHandler = new HttpClientHandler
                            {
                                Credentials = new NetworkCredential(jsonCred.Root.APIKey, jsonCred.Root.SecretKey),
                                PreAuthenticate = true,
                                UseCookies = false
                            };
                            if (jsonCred.Root.Endpoints.Count > 0)
                            {
                                string filesPath = "";
                                foreach (var endPoint in jsonCred.Root.Endpoints)
                                {
                                    var httpClient = new HttpClient(clientHandler);
                                    var responseMessage = httpClient
                                        .GetStringAsync($"{jsonCred.Root.BaseUrl}{endPoint.Url}.json?limit=250").Result;
                                    var pCcount = httpClient
                                        .GetStringAsync($"{jsonCred.Root.BaseUrl}{endPoint.Url}/count.json").Result;
                                    var count = JsonConvert.DeserializeObject<ProductCount>(pCcount);
                                    var folderDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL";
                                    bool exists = System.IO.Directory.Exists(folderDir);
                                    if (!exists)
                                        System.IO.Directory.CreateDirectory(folderDir);
                                    if (count.count > 0)
                                    {
                                        JsonToSQL.JsonConvert jsonConvert = new JsonToSQL.JsonConvert();
                                        var sqlStr = jsonConvert.ToSQL(responseMessage, JsonToSQL.Constants.DefaultDbName + "_" + endPoint.Url);
                                        var sqlPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL/sql_{endPoint.Url}_{DateTime.Now.Ticks}.sql";
                                        using (StreamWriter streamWriter = new StreamWriter(sqlPath, true))
                                        {
                                            streamWriter.WriteLine(sqlStr);
                                        }
                                        filesPath += $"File is created:{sqlPath}\r\n";

                                    }

                                }
                                label1.Text = filesPath;
                            }
                        }

                    }
                }
                else
                {
                    label1.Text = "Incorrect File Format! Only XML File Supported";
                }
            }
            catch (Exception)
            {

                label1.Text = "Incorrect File Format";
                return;
            }

        }


        private void btnJsonToSql_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                txtJsonFilePath.Text = openFileDialog.FileName;
            else
                return;
        }

        private void btnBrowseJsonOrXmlFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            if (!string.IsNullOrWhiteSpace(openFileDialog.FileName) && openFileDialog.FileName.ToLower().Contains("json"))
            {
                using (StreamReader r = new StreamReader(openFileDialog.FileName))
                {

                    string json = r.ReadToEnd();
                    JsonToSQL.JsonConvert jsonConvert = new JsonToSQL.JsonConvert();
                    var sqlStr = jsonConvert.ToSQL(json, JsonToSQL.Constants.DefaultDbName + "_" + openFileDialog.FileName.Split('.')[0]);
                    var folderDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL";
                    bool exists = System.IO.Directory.Exists(folderDir);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(folderDir);
                    var sqlPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL/sql_{DateTime.Now.Ticks}.sql";
                    using (StreamWriter streamWriter = new StreamWriter(sqlPath, true))
                    {
                        streamWriter.WriteLine(sqlStr);
                    }
                    label1.Text += $"File is created:{sqlPath}\r\n";
                }
            }
            else if (!string.IsNullOrWhiteSpace(openFileDialog.FileName) && openFileDialog.FileName.ToLower().Contains("xml"))
            {
                using (StreamReader r = new StreamReader(openFileDialog.FileName))
                {

                    XmlDocument doc = new XmlDocument();
                    string xml = r.ReadToEnd();
                    doc.LoadXml(xml);
                    string json = JsonConvert.SerializeXmlNode(doc);
                    JsonToSQL.JsonConvert jsonConvert = new JsonToSQL.JsonConvert();
                    var sqlStr = jsonConvert.ToSQL(json, JsonToSQL.Constants.DefaultDbName + "_" + openFileDialog.FileName.Split('.')[0]);
                    var folderDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL";
                    bool exists = System.IO.Directory.Exists(folderDir);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(folderDir);
                    var sqlPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL/sql_{DateTime.Now.Ticks}.sql";
                    using (StreamWriter streamWriter = new StreamWriter(sqlPath, true))
                    {
                        streamWriter.WriteLine(sqlStr);
                    }
                    label1.Text += $"File is created:{sqlPath}\r\n";
                }
            }
            else
            {
                label1.Text = "Incorrect File Format! Only Json/XML File Supported";
            }
        }

        private void btnViewQuery_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBaseUrl.Text) && !string.IsNullOrWhiteSpace(txtAPIKey.Text)
                && !string.IsNullOrWhiteSpace(txtSecretKey.Text) && !string.IsNullOrWhiteSpace(txtQuery.Text))
            {
                var clientHandler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(txtAPIKey.Text, txtSecretKey.Text),
                    PreAuthenticate = true,
                    UseCookies = false
                };
                string apiEndPoint = "";
                var apiArray = txtQuery.Text.ToString().Split('*');
                if (apiArray.Length > 0)
                {
                    for (int i = 0; i < apiArray.Length; i++)
                    {
                        if (apiArray[i].ToLower().Contains("from"))
                        {
                            apiEndPoint = apiArray[i].Split(' ')[2].ToLower();
                            break;
                        }
                    }
                }
                var httpClient = new HttpClient(clientHandler);
                var responseMessage = httpClient
                                          .GetStringAsync($"{txtBaseUrl.Text}{apiEndPoint}.json?limit=250").Result;
                var pCcount = httpClient
                    .GetStringAsync($"{txtBaseUrl.Text}{apiEndPoint}/count.json").Result;
                var count = JsonConvert.DeserializeObject<ProductCount>(pCcount);
                var folderDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL";
                bool exists = System.IO.Directory.Exists(folderDir);
                if (!exists)
                    System.IO.Directory.CreateDirectory(folderDir);
                if (count.count > 0)
                {
                    JsonToSQL.JsonConvert jsonConvert = new JsonToSQL.JsonConvert();
                    var sqlStr = jsonConvert.ToSQL(responseMessage, JsonToSQL.Constants.DefaultDbName + "_" + apiEndPoint);
                    var sqlPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/SQL/sql_{apiEndPoint}_{DateTime.Now.Ticks}.sql";
                    using (StreamWriter streamWriter = new StreamWriter(sqlPath, true))
                    {
                        streamWriter.WriteLine(sqlStr);
                    }
                    //creating database

                    DataTable table = new DataTable();
                    var dbarray = _strCon.Split(';');
                    string dbConnections = "";
                    string dbName = "";
                    for (int j = 0; j < dbarray.Length; j++)
                    {

                        if (dbarray[j].ToLower().Contains("initial catalog"))
                        {
                            dbName = JsonToSQL.Constants.DefaultDbName + "_" + apiEndPoint;
                            dbConnections += dbarray[j].Split('=')[0] + "=" + dbName + ";";
                        }
                        else
                            dbConnections += dbarray[j] + ";";
                    }

                    Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(_strCon);

                    Server server = new Server(new ServerConnection(conn));

                    server.ConnectionContext.ExecuteNonQuery(sqlStr);
                    var con1 = new SqlConnection(dbConnections);
                    con1.Open();
                    var cmd1 = new SqlCommand(txtQuery.Text, con1);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                    con1.Close();

                }
            }



        }
    }
}
