using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace stripboeken
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfiguration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static IConfiguration StaticConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddRazorPages();
            services.AddRouting(options =>
            {
                //options.ConstraintMap.Add("categoryConstraint", typeof(CategoryConstraint));
            });
            services.AddDbContext<AuthDbUtils>(options =>
            {
                var connetionString = Configuration.GetConnectionString("ConnectionString");
                options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbUtils>();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}