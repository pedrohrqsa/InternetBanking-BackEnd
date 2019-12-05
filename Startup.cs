using System;
using System.Text;
using InternetBanking.Models;
using System.Threading.Tasks;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace InternetBanking
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
            services.AddDbContext<ClienteDB>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("ConnectionBD")));

           services.AddDbContext<ContaDB>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("ConnectionBD")));

            services.AddDbContext<TransacaoDB>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("ConnectionBD")));

            services.AddTransient<IClienteLoginRepositorio, ClienteLoginRepositorio>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IContatoRepositorio, ContatoRepositorio>();
            services.AddTransient<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddTransient<IFamiliaresRepositorio, FamiliaresRepositorio>();
            services.AddTransient<IContaRepositorio, ContaRepositorio>();
            services.AddTransient<ITransacaoRepositorio, TransacaoRepositorio>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "InternetBanking.net",
                    ValidAudience = "InternetBanking.net",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token Inválido..." + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token válido..." + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddMvc(opção => opção.EnableEndpointRouting = false);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
