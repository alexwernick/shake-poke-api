using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShakePokeAPI.Clients.Clients;
using ShakePokeAPI.Clients.Interfaces;
using ShakePokeAPI.Data.Interfaces;
using ShakePokeAPI.Data.Repositories;
using ShakePokeAPI.Interfaces.Services;
using ShakePokeAPI.Services;

namespace ShakePokeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpClient<IPokeAPIClient, PokeAPIClient>(client => {
                client.BaseAddress = new Uri(Configuration.GetSection("AppSettings").GetValue<string>("PokeAPISrc"));
            });

            services.AddHttpClient<IFunTranslationsClient, FunTranslationsClient>(client => {
                client.BaseAddress = new Uri(Configuration.GetSection("AppSettings").GetValue<string>("FunTranslationsSrc"));
            });

            services.AddSingleton<IShakePokeService, ShakePokeService>();
            services.AddSingleton<IPokemonRepository, PokemonRepository>();
            services.AddSingleton<IShakespeareanRepository, ShakespeareanRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()
                && Configuration.GetSection("AppSettings").GetValue<bool>("bShowErrors"))
            {
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
