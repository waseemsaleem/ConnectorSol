using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConnectorSol
{
    public class APIEndpoints
    {
        public string BaseUrl { get; set; }
        public string APIKey { get; set; }
        public string SecretKey { get; set; }
        public List<APIEndPoints> Endpoints { get; set; }
    }

    public class Main
    {
        public APIEndpoints Root { get; set; }
    }
    public class APIEndPoints
    {
        public string Url { get; set; }
    }

}