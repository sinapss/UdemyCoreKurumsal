using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.Mvc.WebUI.Entities;
using Abc.Northwind.Mvc.WebUI.Middlewares;
using Abc.Northwind.Mvc.WebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddSingleton<ICartSessionService,CartSessionService>();
builder.Services.AddSingleton<ICartService,CartService>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true"));
builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();

builder.Services.AddSession();
//session aktifleþtirmek için(sunucu hafýzasý)
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseNodeModules(builder.Environment.ContentRootPath);
app.UseSession();

app.Run();
