using Bolao.Api.Core.Compression;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.Interfaces.UnitOfWork;
using Bolao.Domain.Services;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Bolao.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Compression
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            });
            #endregion

            //#region Sql Conection
            //services.AddDbContext<BolaoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            //#endregion

            #region Mysql Connection
            var connection = Configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<BolaoContext>(o => o.UseMySql(connection));
            #endregion

            #region Injections
            services.AddScoped<BolaoContext, BolaoContext>();
			//services.AddScoped<IResponseBase, ResponseBase>();

			// Services
			services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<ILotteryService, LotteryService>();
			services.AddTransient<ITicketService, TicketService>();
			services.AddTransient<IEmailService, EmailService>();
			services.AddTransient<IContactService, ContactService>();
            #endregion

            #region Identity
            //services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
            //    .AddEntityFrameworkStores<BolaoContext>()
            //   .AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options => 
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8; // default: 6
            //    options.Password.RequiredUniqueChars = 6; // default: 1
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //});

            //services.ConfigureApplicationCookie(options => 
            //{
            //    options.CookieHttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            //    options.LoginPath = "/Account/Login";
            //    options.LogoutPath = "/Account/Logout";
            //    options.AccessDeniedPath = "/Account/AccessDenied";
            //    options.SlidingExpiration = true; // quando passar da metade do tempo de expiração do cookie, renova!
            //});
            #endregion

            services.AddCors();
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options =>
                    {
                  //      options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                    });
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            ConfigureSwaggerService(services);
        }

        void ConfigureSwaggerService(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Bolão API", Version = "v1" });

                //var security = new Dictionary<string, IEnumerable<string>>
                //{
                //    {"Bearer", new string[] { }},
                //};

                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = "header",
                //    Type = "apiKey"
                //});

                //c.AddSecurityRequirement(security);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

           // app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            //#region Identity
            //app.UseAuthentication();
            //#endregion

            #region Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = "Growups API Documentation";
                c.DocExpansion(DocExpansion.None);
            });
            #endregion

            app.UseMvc();
        }
    }
}