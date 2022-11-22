using IGeekFan.AspNetCore.RapiDoc;
using LFF.API.Helpers;
using LFF.API.Helpers.Authorization.Middleware;
using LFF.API.Middleware;
using LFF.Core.Extensions;
using LFF.Infrastructure.EF.Extensions;
using LFF.Infrastructure.EF.Utils.PasswordUtils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LFF.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages().AddNewtonsoftJson();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddControllers();
            services.RegisterEFDatabase(this.Configuration);
            services.RegisterRepositories(this.Configuration);
            services.RegisterServices(this.Configuration);

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("admin-controller", new OpenApiInfo() { Title = "API Admin Controller", Version = "v1.0", Description = "Admin và Staff dùng chung" });
                config.SwaggerDoc("common-controller", new OpenApiInfo() { Title = "API Common", Version = "v1.0" });
                config.SwaggerDoc("teacher-controller", new OpenApiInfo() { Title = "API Teacher", Version = "v1.0" });
                config.SwaggerDoc("student-controller", new OpenApiInfo() { Title = "API Student", Version = "v1.0" });

                // Bearer token authentication
                OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                };
                config.AddSecurityDefinition("jwt_auth", securityDefinition);

                // Make sure swagger UI requires a Bearer token specified
                OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Id = "jwt_auth",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
                {
                    {
                        securityScheme,
                        new string[] { }
                    },
                };
                config.AddSecurityRequirement(securityRequirements);
            });

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));
            services.Configure<PasswordSettings>(options => Configuration.GetSection("StorePasswordSetting").Bind(options));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
            }

            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseCors(builder => builder 
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/admin-controller/swagger.json", "Admin API");
                c.SwaggerEndpoint("/swagger/teacher-controller/swagger.json", "Teacher API");
                c.SwaggerEndpoint("/swagger/student-controller/swagger.json", "Student API");
                c.SwaggerEndpoint("/swagger/common-controller/swagger.json", "Common API");
            });

            app.UseRapiDocUI(c =>
            {
                c.RoutePrefix = ""; // serve the UI at root
                c.SwaggerEndpoint("/swagger/admin-controller/swagger.json", "Admin controller");
                c.SwaggerEndpoint("/swagger/teacher-controller/swagger.json", "Teacher controller");
                c.SwaggerEndpoint("/swagger/student-controller/swagger.json", "Student controller");
                c.SwaggerEndpoint("/swagger/common-controller/swagger.json", "Common controller");
                c.GenericRapiConfig = new GenericRapiConfig()
                {
                    RenderStyle = "focused",
                    Theme = "light",//light,dark,focused   
                };
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
