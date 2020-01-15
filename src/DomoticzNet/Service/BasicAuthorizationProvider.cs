using System;
using System.Net;
using System.Text;

namespace DomoticzNet.Service
{
    public class BasicAuthorizationProvider : IDomoticzAuthorizationProvider
    {
        #region IDomoticzAuthorizationProvider

        public virtual void AuthorizeUri(UriBuilder uriBuilder)
        {
            if (uriBuilder is null)
                throw new ArgumentNullException(nameof(uriBuilder));

            uriBuilder.Scheme = UseHttps ? "https" : "http";
        }

        public virtual void AuthorizeRequest(HttpWebRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var authorizationString = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_UserName}:{_Password}"));
            request.Headers[HttpRequestHeader.Authorization] = $"Basic {authorizationString}";
        }

        #endregion IDomoticzAuthorizationProvider

        #region Properties

        public virtual bool UseHttps { get; set; }

        #endregion Properties

        #region Fields

        private readonly string _UserName = null, _Password = null;

        #endregion Fields

        #region Constructors

        public BasicAuthorizationProvider(string userName, string password)
        {
            _UserName = userName;
            _Password = password;
        }

        #endregion Constructors
    }
}
