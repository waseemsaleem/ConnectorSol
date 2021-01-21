using System.Collections.Generic;

namespace ConnectorSol
{
    public class APIEndpoints
    {
        public string BaseUrl { get; set; }
        public string APIKey { get; set; }
        public string SecretKey { get; set; }
        public List<string> Endpoints { get; set; }
    }
}