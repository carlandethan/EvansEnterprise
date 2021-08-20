using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using EvansEnterprise.Data;
using Microsoft.OpenApi.Models;
using EvansEnterprise.Model;
using Microsoft.AspNetCore.Identity;
using EvansEnterprise.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

namespace EvansEnterprise
{
    public class Startup
    {
        readonly string ToDoPolicy = "_ToDoItemSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Evans Enterprise", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: ToDoPolicy,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();

                                  });
            });



            //Configuration from AppSettings
            services.Configure<Jwt>(Configuration.GetSection("JWT"));
            //User Manager Service
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IUserService, UserService>();

            //Adding Athentication - JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddDbContext<ToDoItemContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ToDoItemContext")));

            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Evans Enterprise v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(ToDoPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers().RequireCors(ToDoPolicy);
            });
        }
    }
}
