using Microsoft.Extensions.DependencyInjection;
using POC_Services.Contracts;
using POC_Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC
{
    public partial class Startup
    {
        private void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<IToysService, ToysService>();
        }
    }
}
