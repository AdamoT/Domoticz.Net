using System;
using System.Collections.Generic;
using System.Text;

namespace DomoticzNet.Service
{
    public interface IDomoticzAuthorizationProvider
    {
        bool UseHttps { get; }
    }
}
