using CoreWebApi.Data;
using CoreWebApi.DTOMapping;
using CoreWebApi.Repository;
using CoreWebApi.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApi
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
            
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cn")));
            services.AddScoped<INationalParkRepository, NationalParkRepository>();
            services.AddScoped<ITrailRepository, TrailRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreWebApi", Version = "v1" });
            //});
            services.AddSwaggerGen(options =>
            {
                //Doc For National Park
                options.SwaggerDoc("NPDoc", new OpenApiInfo()
                {
                    Title = "National Park API",
                    Version = "1.0",
                    Description = "This is NP API",
                    Contact = new OpenApiContact()
                    {
                        Name = "Karamjit Singh",
                        Email = "test@gmail.com",
                        Url = new Uri("https://abc.com")
                    }
                });
                //Doc For Trail
                options.SwaggerDoc("TrailDoc", new OpenApiInfo()
                {
                    Title = "Trail API",
                    Version = "1.0",
                    Description = "This is Trail API",
                    Contact = new OpenApiContact()
                    {
                        Name = "Karma",
                        Email = "test@gmail.com",
                        Url = new Uri("https://abc.com")
                    }
                });
                //User Doc
                options.SwaggerDoc("UserDoc", new OpenApiInfo()
                {
                    Title = "User API",
                    Version = "1.0",
                    Description = "This is User API",
                    Contact = new OpenApiContact()
                    {
                        Name = "Vikas Kumar",
                        Email = "test1@gmail.com",
                        Url = new Uri("https://abc.com")
                    }
                });
                //XML Comments
                var XmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var XmlCommentFileFullPath = Path.Combine(AppContext.BaseDirectory, XmlCommentFile);
                options.IncludeXmlComments(XmlCommentFileFullPath);
            });
            //JWT Authentication
            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);
            var appSetting = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //    app.UseSwagger();
                //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebApi v1"));

                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/NPDoc/swagger.json", "National Park API");
                    options.SwaggerEndpoint("/swagger/TrailDoc/swagger.json", "Trail API");
                    options.SwaggerEndpoint("/swagger/UserDoc/swagger.json", "User API");
                    options.RoutePrefix = "";
                });
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
