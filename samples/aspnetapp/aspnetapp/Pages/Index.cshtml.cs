using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public SqlConfiguration SqlConfiguration;

        public IndexModel(IConfiguration config, ILogger<IndexModel> logger)
        {
            var configRoot = (IConfigurationRoot) config;
            SqlConfiguration = configRoot.GetSection(nameof(SqlConfiguration)).Get<SqlConfiguration>();
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
