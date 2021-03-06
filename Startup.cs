﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QAware.OSS.Admin;
using Steeltoe.Management.Endpoint.Health;
using Steeltoe.Management.Endpoint.Health.Contributor;
using Steeltoe.Management.Endpoint.Info;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration;

namespace QAware.OSS
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()

                // add the Spring Cloud Config server
                .AddConfigServer(env);
            
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add custom health check contributor
            services.AddSingleton<IHealthContributor, DiskSpaceContributor>();
			services.AddSingleton<IHealthContributor, ReadinessContributor>();
            services.AddHealthActuator(Configuration);

            // Add custom info contributor
            services.AddSingleton<IInfoContributor, InfoContributor>();
			services.AddInfoActuator(Configuration);

            // ddd Steeltoe Discovery Client service to DI
			services.AddDiscoveryClient(Configuration); 

            // add the config server service to DI
            services.AddConfigServer(Configuration);
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddOptions();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // activate /health and /info endpoints
            app.UseHealthActuator();
            app.UseInfoActuator();

            app.UseDeveloperExceptionPage();

            app.UseMvc();

			// Use the Steeltoe Discovery Client service
			app.UseDiscoveryClient();
        }
    }
}
