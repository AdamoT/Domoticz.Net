using System;
using System.Collections.Generic;
using System.Text;

namespace DomoticzNet.Service
{
    public class BasicAuthorizationService : IDomoticzAuthorizationProvider
    {
        #region IDomoticzAuthorizationProvider

        public bool UseHttps { get; }

        #endregion IDomoticzAuthorizationProvider

        #region Fields

        private readonly string _UserName = null, _Password = null;

        #endregion Fields

        #region Constructors

        public BasicAuthorizationService(string userName, string password, bool useHttps = false)
        {
            UseHttps = useHttps;
            _UserName = userName;
            _Password = password;
        }
       
        #endregion Constructors
    }
}
