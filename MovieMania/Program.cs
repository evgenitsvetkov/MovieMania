using Microsoft.AspNetCore.Mvc;
using MovieMania.ModelBinders;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);

    options.Cookie.HttpOnly = true;
});

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.WebHost.UseStaticWebAssets();
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "Areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

    endpoints.MapControllerRoute(
        name: "Movie Details",
        pattern: "/Movie/Details/{id}/{information}",
        defaults: new { Controller = "Movie", Action = "Details"}
    );

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();

});

await app.CreateAdminRoleAsync();

await app.RunAsync();
