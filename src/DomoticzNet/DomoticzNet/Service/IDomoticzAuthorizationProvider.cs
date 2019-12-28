using System;
using System.Net;

namespace DomoticzNet.Service
{
    public interface IDomoticzAuthorizationProvider
    {
        void AuthorizeUri(UriBuilder uriBuilder);
        void AuthorizeRequest(HttpWebRequest request);
    }
}
