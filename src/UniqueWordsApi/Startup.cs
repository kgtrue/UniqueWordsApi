using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using UniqueWordsApi.WordServices;
using UniqueWordsApi.DatabaseSeeding;
namespace UniqueWordsApi
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
            var server = Configuration["SqlServerName"] ?? "192.168.1.137";
            var port = Configuration["SqlServerPort"] ?? "1433";
            var catalog = Configuration["SqlServerCatalog"] ?? "UniqueWordsApiDB";
            //SA users should not be used it is here for testing purposes.
            var user = Configuration["SqlServerUser"] ?? "SA";
            var password = Configuration["SqlServerPassword"] ?? "KgtPass001";

            //register dbcontent with connection pool.
            var context = services.AddDbContextPool<WordStoreDBContext>(options =>
            {
                options.UseSqlServer(string.Format(Configuration["ConnectionStringFormats:UniqueWordsApiConnectionFormat"], server, port, catalog, user, password));

            });

            services.AddTransient(typeof(IWordStoreService), typeof(WordStoreService));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Unique words Api",
                    Version = "v1",
                    Description = "A api for returning the number of unique words in a sentance and the coresponding watchlistWords.",
                    Contact = new OpenApiContact
                    {
                        Name = "Kristian Greve True",
                        Email = String.Empty,
                    },
                }); ;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            PrepDB.PrepTestData(app.ApplicationServices);
           
            app.UseRequestLocalization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unique words Api V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
