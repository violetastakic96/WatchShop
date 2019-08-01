using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Business.Commands.Basket;
using Business.Commands.Brand;
using Business.Commands.Gender;
using Business.Commands.Mechanism;
using Business.Commands.Product;
using Business.Commands.ProductPhoto;
using Business.Commands.Role;
using Business.Commands.User;
using Business.Helpers;
using Business.Interfaces;
using EfCommands.Basket;
using EfCommands.Brand;
using EfCommands.Gender;
using EfCommands.Mechanism;
using EfCommands.Product;
using EfCommands.ProductPhoto;
using EfCommands.Role;
using EfCommands.User;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Helpers;

namespace WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ShopContext>();

            services.AddTransient<IGetRoleCommand, EfGetRoleCommand>();
            services.AddTransient<IGetRolesCommand, EfGetRolesCommand>();
            services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IEditRoleCommand, EfEditRoleCommand>();
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();
            services.AddTransient<IGetUserCommand, EfGetUserCommand>();
            services.AddTransient<IAddUserCommand, EfAddUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IGetBrandCommand, EfGetBrandCommand>();
            services.AddTransient<IGetBrandsCommand, EfGetBrandsCommand>();
            services.AddTransient<IAddBrandCommand, EfAddBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IEditBrandCommand, EfEditBrandCommand>();
            services.AddTransient<IGetGenderCommand, EfGetGenderCommand>();
            services.AddTransient<IGetGendersCommand, EfGetGendersCommand>();
            services.AddTransient<IAddGenderCommand, EfAddGenderCommand>();
            services.AddTransient<IDeleteGenderCommand, EfDeleteGenderCommand>();
            services.AddTransient<IEditGenderCommand, EfEditGenderCommand>();
            services.AddTransient<IGetMechanismCommand, EfGetMechanismCommand>();
            services.AddTransient<IGetMechanismsCommand, EfGetMechanismsCommand>();
            services.AddTransient<IAddMechanismCommand, EfAddMechanismCommand>();
            services.AddTransient<IDeleteMechanismCommand, EfDeleteMechanismCommand>();
            services.AddTransient<IEditMechanismCommand, EfEditMechanismCommand>();
            services.AddTransient<IGetProductCommand, EfGetProductCommand>();
            services.AddTransient<IGetProductsCommand, EfGetProductsCommand>();
            services.AddTransient<IAddProductCommand, EfAddProductCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
            services.AddTransient<IEditProductCommand, EfEditProductCommand>();
            services.AddTransient<IGetProductPhotoCommand, EfGetProductPhotoCommand>();
            services.AddTransient<IGetProductPhotosCommand, EfGetProductPhotosCommand>();
            services.AddTransient<IAddProductPhotoCommand, EfAddProductPhotoCommand>();
            services.AddTransient<IDeleteProductPhotoCommand, EfDeleteProductPhotoCommand>();
            services.AddTransient<IEditProductPhotoCommand, EfEditProductPhotoCommand>();
            services.AddTransient<IAddToBasketCommand, EfAddToBasketCommand>();
            services.AddTransient<IRemoveFromBasketCommand, EfRemoveFromBasketCommand>();
            services.AddTransient<IBuyCommand, EfBuyCommand>();
            services.AddTransient<IGetAllBasketsCommand, EfGetAllBasketsCommand>();
            services.AddTransient<IGetUserBasketCommand, EfGetUserBasketCommand>();
            services.AddTransient<ILoginUserCommand, EfLoginUserCommand>();



            var section = Configuration.GetSection("Email");

            var sender =
                new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);


            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            var key = Configuration.GetSection("Encryption")["key"];

            var enc = new Encryption(key);
            services.AddSingleton(enc);


            services.AddTransient(s => {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encryption>();

                try
                {
                    var decodedString = encryption.DecryptString(value);
                    decodedString = decodedString.Replace("\f", "");
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception)
                {
                    return new LoggedUser
                    {
                        IsLogged = false
                    };
                }
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WatchShop", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

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

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
