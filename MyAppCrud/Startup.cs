
using Microsoft.EntityFrameworkCore;
using MyApp.Data;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=app.db"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
    }
}
