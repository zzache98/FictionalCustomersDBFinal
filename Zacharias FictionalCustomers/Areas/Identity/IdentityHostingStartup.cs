using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zacharias_FictionalCustomers.Data;

[assembly: HostingStartup(typeof(Zacharias_FictionalCustomers.Areas.Identity.IdentityHostingStartup))]
namespace Zacharias_FictionalCustomers.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
            
        }
    }
}