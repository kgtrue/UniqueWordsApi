using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using UniqueWordsApi.Services;
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
            //register dbcontent with connection pool.
            var context = services.AddDbContextPool<WordStoreDBContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:UniqueWordsApiConnection"]);

            });


            services.AddTransient(typeof(IWordStoreService), typeof( WordStoreService));



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
