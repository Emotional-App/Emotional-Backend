using Diaryal.Api.Domain.Services;
using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Services;
using Emotional.Api.Utils;
using Emotional.Common.Auth;
using Emotional.Common.Contracts;
using Emotional.Common.Security;
using Emotional.Common.Services;
using Emotional.Data.EF;
using Emotional.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Principal;

namespace EmotionalBackend
{
    public class Startup
    {
        private readonly string origins = "http://localhost:3000";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string corsPolicy = "AllowOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

            services.AddDbContext<EmotionalDbContext>(options => 
                options.UseSqlServer(Configuration[Constants.SqlConnectionString]));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddJwt(Configuration);

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmotionService, EmotionService>();
            services.AddScoped<IDiaryService, DiaryService>();
            services.AddScoped<IMusicService, MusicService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            Func<IServiceProvider, IPrincipal> getPrincipal =
                (sp) => sp.GetService<IHttpContextAccessor>().HttpContext.User;

            services.AddScoped(typeof(Func<IPrincipal>), sp =>
            {
                Func<IPrincipal> func = () => getPrincipal(sp);
                return func;
            });

            services.AddScoped<IUserAppContext, UserAppContext>();
            services.AddSingleton<IPasswordStorage, PasswordStorage>();

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseCors(corsPolicy);

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Could not find anything");
            });
        }
    }
}
