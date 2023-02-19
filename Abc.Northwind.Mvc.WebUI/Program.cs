using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.Mvc.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();

app.UseStaticFiles();
app.UseNodeModules(builder.Environment.ContentRootPath);

app.Run();
