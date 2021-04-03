using System;
using System.Net;

namespace AuroraWeb.Libs
{
    public class TimeoutWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = 1800000;
            return request;
        }
    }
}