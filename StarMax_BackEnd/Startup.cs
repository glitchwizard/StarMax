using Microsoft.EntityFrameworkCore;
using StarMaxApp.Models; 
using StarMaxApp.Data;
using System.Net.Http.Json;  

namespace StarMaxApp
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
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Seed database
            InitializeDatabase(app);
        }

        private async void InitializeDatabase(IApplicationBuilder app)
        {
            var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            if (serviceScopeFactory != null)   
            {
                var context = serviceScopeFactory.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var client = serviceScopeFactory.ServiceProvider.GetRequiredService<HttpClient>();

                if (context.Database.EnsureCreated())
                {
                    // Use HttpClient to fetch data from the Starship API and seed the database
                    var response = await client.GetAsync("https://swapi.dev/api/starships/");
                    if (response.IsSuccessStatusCode)
                    {
                        var starships = await response.Content.ReadFromJsonAsync<Starship[]>();
                        if (starships != null && !context.Starships?.Any() == true)
                            {
                                context.Starships.AddRange(starships);
                                await context.SaveChangesAsync();
                            }
                    }
                }
            }
        }
    }
}
