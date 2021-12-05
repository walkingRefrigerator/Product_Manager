using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product_Manager.Domain.Repositories.Abstract;
using Product_Manager.Domain.Repositories.EntityFramework;
using Product_Manager.AppStart;

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
