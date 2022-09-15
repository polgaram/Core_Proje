using BusinessLayer;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using DataAccsessLayer.IdentityConfigurations;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddIdentityLayer(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});

builder.Services.ConfigureApplicationCookie(cong =>
{
    cong.LoginPath = "/Writer/Login/Index/";
    cong.AccessDeniedPath = "/ErrorPage/Index/";
    cong.Cookie.HttpOnly = true;
    cong.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    cong.Cookie.MaxAge = cong.ExpireTimeSpan; // optional
    cong.SlidingExpiration = true;
});

builder.Services.AddScoped<InitialIdentityData, InitialIdentityData>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    InitialIdentityData ýnitialIdentityData = scope.ServiceProvider.GetRequiredService<InitialIdentityData>();
    await ýnitialIdentityData.Do();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
    );
});

app.Run();
