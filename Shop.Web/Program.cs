using Shop.Infrastructure.Configurations;
using Shop.Infrastructure.Data.EFCore.Configurations;
using Shop.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Database service
builder.Services.AddShopDbConfiguration(builder.Configuration);

//Identity service
builder.Services.AddIdentityConfiguration(builder.Configuration);

//MediatR service
builder.Services.AddMediatRConfiguration();

builder.Services.AddInfrastructureServices();

//Razor Pages service
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.Run();
