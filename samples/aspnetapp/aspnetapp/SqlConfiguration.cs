// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetapp
{
    public class SqlConfiguration
    {
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string InitialCatalog { get; set; }
    }
}
