using PGTPublic.Gateway.PGTData;
using PGTPublic.Gateway.PGTData.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace PGTPublic
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "PGTPublic",
                    Version = "1.0",
                });
                string urlAuthServer = Configuration["AuthServer"];

            });

            AppSetting appSetting = Configuration.Get<AppSetting>();
            services.AddSingleton(instance => appSetting);

            services.AddTransient<IGroupClient, GroupClient>();
            services.AddTransient<IUserClient, UserClient>();
            services.AddTransient<IReviewClient, ReviewClient>();
            services.AddTransient<IStudentClient, StudentClient>();
            services.AddTransient<ICampusClient, CampusClient>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PGTPublic");

            });
        }
    }
}
