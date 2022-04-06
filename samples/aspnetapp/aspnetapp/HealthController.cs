// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace aspnetapp
{
    
    public class HealthController : Controller
    {
        private IConfigurationRoot _configRoot;
        private ILogger<HealthController> _logger;
        public HealthController(IConfiguration configuration, ILogger<HealthController> logger)
        {
            _configRoot = (IConfigurationRoot)configuration;
            _logger = logger;
        }

        public IActionResult Liveness()
        {
            return Ok();
        }

        public async Task<IActionResult> Readiness()
        {
            var sqlConfig = _configRoot.GetSection(nameof(SqlConfiguration)).Get<SqlConfiguration>();


            var connString = new SqlConnectionStringBuilder()
            {
                DataSource = sqlConfig.Server,
                InitialCatalog = "master",
                UserID = "sa",
                Password = sqlConfig.Password
            };

            var conn = new SqlConnection(connString.ToString());

            await conn.OpenAsync();

            var command = conn.CreateCommand();
            command.CommandText = "SELECT 1";

            var result = (int) await command.ExecuteScalarAsync();

            if(result == 1)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
