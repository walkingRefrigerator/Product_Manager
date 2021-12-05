using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Product_Manager.Domain.Repositories.Abstract;
using Product_Manager.Domain.Repositories.EntityFramework;
using Product_Manager.AppStart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Manager
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
            //��������� � ������ ������ Config ������ ����������� � ��
            Configuration.Bind("ConnectionStrings", new Config());

            //���������� ������ ���������� ���������� � �������� ��������
            services.AddTransient<IProductRepositories, EFProductRepositories>();


            //���������� �������� ��
            services.AddDbContext<TestDbContext>(x => x.UseSqlServer(Config.DefaultConnection));

            services.AddMvc();
            services.AddControllersWithViews();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //���������� ��������� ��������� ������ � ���������� (css, js � �.�.)
            app.UseStaticFiles();

            //���������� ������� �������������
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
